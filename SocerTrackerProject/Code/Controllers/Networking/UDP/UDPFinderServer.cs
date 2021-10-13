using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Threading;

namespace SocerTrackerProject.Code.Controllers.Networking.UDP
{
    //this server will constanly send finder packets to LAN
    class UDPFinderServer
    {
        private const int port = 64459;
        public UDPFinderServer()
        {
            
        }

        private static string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }

        private static string SwapToBroadcast(string ip)
        {
            char[] characterArr = ".".ToCharArray();
            for(int i = ip.Length - 1; i > 0; i--)
            {
                if(ip[i] == characterArr[0])
                {
                    ip = ip.Substring(0, i + 1) + "255";
                    return ip;
                }
            }
            throw new Exception("IP adress cannot be translated into an BroadCast address");
        }

        private static void sendPacket()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string ip = SwapToBroadcast(GetLocalIPv4(NetworkInterfaceType.Ethernet));
            IPAddress broadcast = IPAddress.Parse(ip);

            string toSend = "SocerTrackerPing";

            byte[] sendbuf = Encoding.ASCII.GetBytes(toSend.ToCharArray());

            IPEndPoint ep = new IPEndPoint(broadcast, port);

            s.SendTo(sendbuf, ep);
        }
        
        public static void scanNetwork()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (true)
            {
                Thread.Sleep(30000);//ticks every 30 sec
                sendPacket();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocerTracker.Code.Controllers.Networking.UDP
{
    class UDPpingServer
    {
        private const int sendPort = 64459;
        private const int listenPort = 64459;

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
            for (int i = ip.Length - 1; i > 0; i--)
            {
                if (ip[i] == characterArr[0])
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

            IPEndPoint ep = new IPEndPoint(broadcast, sendPort);

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

        public static void startListener()
        {
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            try
            {
                while (true)
                {
                    byte[] bytes = listener.Receive(ref groupEP);

                    if (groupEP.Address.ToString() != GetLocalIPv4(NetworkInterfaceType.Ethernet))
                    {
                        if (Encoding.ASCII.GetString(bytes, 0, bytes.Length) == "SocerTrackerPing")
                        {
                            //Task.Run(() => UDPDataRequesterServer.RequestData(groupEP.Address.ToString()));
                            //Task.Run(() => UDPDataSender.sendData(groupEP.Address.ToString()));
                        }
                    }
                    //Console.WriteLine($"Received broadcast from {groupEP}");
                    //Console.WriteLine($"{Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }

        }
    }
}

using SocerTrackerProject.Code.Controllers.Networking.UDP;
using SocerTrackerProject.Code.Controllers.Shared;
using SocerTrackerProject.Code.Models.ActiveSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocerTracker.Code.Controllers.Networking.UDP
{
    public class UDPDataRequesterServer
    {
        private const int port = 64466;

        public UDPDataRequesterServer()
        {

        }

        public static void RequestData(string IP)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string toSend = "DataRequest";

            byte[] sendbuf = Encoding.ASCII.GetBytes(toSend.ToCharArray());

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            s.SendTo(sendbuf, ep);
        }
    }

    public class UDPDataSender
    {
        private const int ListenTriggerPort = 64466;
        private const int DataSenderPort = 64465;

        public UDPDataSender()
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

        public static void TriggerListener()
        {
            UdpClient listener = new UdpClient(ListenTriggerPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, ListenTriggerPort);

            try
            {
                while (true)
                {
                    byte[] bytes = listener.Receive(ref groupEP);

                    if (groupEP.Address.ToString() != GetLocalIPv4(NetworkInterfaceType.Ethernet))
                    {
                        if (Encoding.ASCII.GetString(bytes, 0, bytes.Length) == "SocerTrackerPing")
                        {
                            sendData(groupEP.Address.ToString());
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

        public static void sendData(string IP)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress ReceiverIP = IPAddress.Parse(IP);

            ActiveSessionClone sessionClone = new ActiveSessionClone();
            sessionClone.Account   = ActiveSession.Account;
            sessionClone.IPaddress = ActiveSession.IPaddress;
            sessionClone.SerializedCardModel = ActiveSession.SerializedCardModel;
            sessionClone.SerializedInfoModel = ActiveSession.SerializedInfoModel;

            string toSend = JsonController.SerializeFile<ActiveSessionClone>(sessionClone);

            byte[] sendbuf = Encoding.ASCII.GetBytes(toSend.ToCharArray());

            IPEndPoint ep = new IPEndPoint(ReceiverIP, DataSenderPort);

            s.SendTo(sendbuf, ep);
        }
    }

    public class UDPDataReceiver
    {
        private const int listenPort = 64465;

        public UDPDataReceiver()
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

        public static void startDataListener()
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
                        string test = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                            ActiveSessionClone JsonSessionClone = JsonController.DeserializeFile<ActiveSessionClone>(Encoding.ASCII.GetString(bytes, 0, bytes.Length));
                            if (!ActiveSession.CheckListForAccount(JsonSessionClone.Account))
                            {
                                ForeignSessions sessions = new ForeignSessions();
                                sessions.Account = JsonSessionClone.Account;
                                sessions.IPaddress = JsonSessionClone.IPaddress;
                                sessions.SerializedCardModel = JsonSessionClone.SerializedCardModel;
                                sessions.SerializedInfoModel = JsonSessionClone.SerializedInfoModel;

                                ActiveSession.ForeignSessionsList.Add(sessions);
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

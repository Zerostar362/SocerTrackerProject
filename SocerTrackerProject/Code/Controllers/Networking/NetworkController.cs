using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocerTrackerProject.Code.Controllers.Networking
{
    class NetworkController
    {
        //goals with network
        //User file and cards sharing
        //Online player detection
        //basic chat

        //sending user files will be possible only on local network
        //online detection will be possible only on local network
        //chat will be established long term connection, wich can be via internet

        //First of all create file sharing via local network
        UdpClient client;
        public NetworkController()
        {
            client = new UdpClient(111);
        }

        public void sendRequestPackage()
        {
            
        }
    }
}

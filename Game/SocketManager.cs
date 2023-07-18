using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class SocketManager
    {
        #region Client
        Socket client;
        public bool ConnectServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP),PORT);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(iep);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        #endregion

        #region server

        Socket server;
        public void CreateServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), PORT);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(iep);
            server.Listen(10); // doi ket noi trong vong 10s


            Thread acceptClient = new Thread(() =>
            {
                client = server.Accept();
            });   
            acceptClient.IsBackground = true;
            acceptClient.Start();

           
        }
        #endregion

        #region Both
        public string IP = "127.0.0.1";
        public int PORT = 9999;
        public const int BUFFER = 1024; 
        public bool isServer = true;


        /// <summary>
        /// Kiem tra xem la thang nao la thang gui thang nao la nhan
        /// ? server ? client
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Send(object data)
        {
            byte[] sendData = SerializeData(data);
       
            return SendData(client, sendData);
        }
        public object Receive()
        {
            byte[] receiveData = new byte[BUFFER];
            bool isOk = ReceiveData(client,receiveData);
            return DeserializeData(receiveData);
        }

        private bool SendData(Socket target, byte[] data)
        {
            return target.Send(data) == 1 ? true:false ;
        }
        private bool ReceiveData(Socket target, byte[] data)
        {
            return target.Receive(data) == 1 ? true :false ;
        }

        /// <summary>
        /// Nén đối tượng vào thành 1 byte và giải nén 1 mạng byte thành 1 đối tượng
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream(); //luu tru va phan tich
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms,o);
            return ms.ToArray();
        }

        public object DeserializeData(byte[] theByteArray) {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }

        /// <summary>
        /// Lấy ra IP V4 của card mạng đang dùng(ethernet) 
        /// thay vì mình tự lấy ra ipv4 thì hàm sẽ lấy ra ipv4 của mình
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if(item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if(ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
        #endregion


    }
}

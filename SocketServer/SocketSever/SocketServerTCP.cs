using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Threading.Tasks;
namespace SocketServer.SocketServer
{
    public class SocketServerTCP
    {
		public static void ReceiveFile(Socket clientSocket, string n)
		{
			Console.WriteLine("getting file....");
			byte[] clientData = new byte[1024 * 5000];
			int receivedBytesLen = clientSocket.Receive(clientData);
			int fileNameLen = BitConverter.ToInt32(clientData, 0);
			string fileName = Encoding.ASCII.GetString(clientData, 4, fileNameLen);
			BinaryWriter bWrite = new BinaryWriter(File.Open( fileName + n, FileMode.Create));
			bWrite.Write(clientData, 4 + fileNameLen, receivedBytesLen - 4 - fileNameLen);
			bWrite.Close();
			clientSocket.Close();
			//[0]filenamelen[4]filenamebyte[*]filedata   
		}
		public  void Start()
		{
			//IPHostEntry iPHostEntry = Dns.GetHostEntry("127.");
			//IPAddress ipAddress = iPHostEntry.AddressList[0];
			IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
			Console.WriteLine("Starting TCP listener...");
			IPEndPoint ipEnd = new IPEndPoint(ipAddress, 5354);
			Socket serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.IP); 
			serverSocket.Bind(ipEnd);
			int counter = 0;

			serverSocket.Listen(5354); 

			Console.WriteLine(" >> " + "Server Started");
			while (true)
			{
				counter += 1;
				Socket clientSocket = serverSocket.Accept();
				Console.WriteLine(" >> " + "Client No:" + Convert.ToString(counter) + " started");
				new Thread(delegate ()
				{
					ReceiveFile(clientSocket, Convert.ToString(counter));
				}).Start();
			}
		}
	}
}
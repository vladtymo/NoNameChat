using BLL.DTOs;
using Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientObject
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream { get; private set; }
        TcpClient client;
        ServerObject server;

        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                MessageViewModel message = null;
                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        Console.WriteLine(message.Text);
                        server.BroadcastMessage(message, this.Id);
                    }
                    catch
                    {
                        //Console.WriteLine(message.From.Name + " has left chat");
                        Console.WriteLine("User left chat");
                        message.Text = "User left chat";
                        server.BroadcastMessage(message, this.Id);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                server.RemoveConnection(this.Id);
                Close();
            }
        }

        private MessageViewModel GetMessage()
        {
            BinaryFormatter bf = new BinaryFormatter();
            return (MessageViewModel)bf.Deserialize(Stream);
        }

        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }
    }
}

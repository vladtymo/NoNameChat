using AutoMapper;
using BLL.DTOs;
using Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class ServerObject
    {
        static TcpListener tcpListener;
        List<ClientObject> clients = new List<ClientObject>();
        private IMapper mapper = null;

        public ServerObject()
        {
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                //              forward

                cfg.CreateMap<UserDTO, UserViewModel>();
                cfg.CreateMap<MessageDTO, MessageViewModel>();

                //              backward

                cfg.CreateMap<UserViewModel, UserDTO>();
                cfg.CreateMap<MessageViewModel, MessageDTO>();
            });
            mapper = new Mapper(config);
        }
        protected internal void AddConnection(ClientObject clientObject)
        {
            clients.Add(clientObject);
        }
        protected internal void RemoveConnection(string id)
        {
            ClientObject client = clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
                clients.Remove(client);
        }
        protected internal void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8888);
                tcpListener.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();

                    ClientObject clientObject = new ClientObject(tcpClient, this);
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }

        //protected internal void SendMessage(MessageViewModel message)
        //{
        //    var user = clients.FirstOrDefault(c => c.User.Id == message.UserTo.Id);
        //    if (user == null) return;

        //    BinaryFormatter bf = new BinaryFormatter();

        //    var msg = ctx.AddMessage(mapper.Map<MessageDTO>(message));

        //    bf.Serialize(user.Stream, message);
        //}
        protected internal void BroadcastMessage(MessageViewModel message, string id)
        {
            BinaryFormatter bf = new BinaryFormatter();

            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id != id)
                {
                    bf.Serialize(clients[i].Stream, message);
                }
            }
        }
        protected internal void Disconnect()
        {
            tcpListener.Stop();

            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close();
            }
            Environment.Exit(0);
        }
    }
}

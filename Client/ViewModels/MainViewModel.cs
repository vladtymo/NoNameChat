using Client.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        private const string host = "127.0.0.1";
        private const int port = 8888;
        static TcpClient client;
        static NetworkStream stream;

        private string messageText;

        public string MessageText
        {
            get { return messageText; }
            set { SetProperty(ref messageText, value); }
        }


        private readonly ICommand startWorkCommand;
        private readonly ICommand sendMessageCommand;

        public ICommand SendMessageCommand => sendMessageCommand;
        public ICommand StartWorkCommand => startWorkCommand;

        private AsyncObservableCollection<MessageViewModel> messages = new AsyncObservableCollection<MessageViewModel>();
        public AsyncObservableCollection<MessageViewModel> Messages => messages;


        public MainViewModel()
        {
            sendMessageCommand = new DelegateCommand(f => SendMessage());
            startWorkCommand = new DelegateCommand(f => StartWork());

        }

        public void StartWork()
        {
            client = new TcpClient();
            try
            {
                client.Connect(host, port);
                stream = client.GetStream();

                Task.Run(() => ReceiveMessage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Disconnect();
            }
        }

        private void SendMessage()
        {
            if (messageText == null)
                return;
            MessageViewModel m = new MessageViewModel()
            {
                Text = messageText
            };
            SendMessage(m);
            Messages.Add(m);
            MessageText = "";
        }

        private void SendMessage(MessageViewModel message)
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, message);
        }

        void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    MessageViewModel message = (MessageViewModel)bf.Deserialize(stream);
                    Messages.Add(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection has been lost! " + ex.Message);
                    Disconnect();
                }
            }
        }

        void Disconnect()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
            //Thread.Sleep(3000);
            Environment.Exit(0);
        }
    }
}

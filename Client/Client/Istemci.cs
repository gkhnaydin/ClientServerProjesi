using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Timers;

namespace Server
{
    public partial class Client : Form
    {
        // Receiving byte array  
        private byte[] bytes = new byte[1024];
        private Socket senderSock;
        private IPEndPoint ipEndPoint;

        private System.Timers.Timer timer;
        public delegate void akisiDegistir(string text);

        public Client()
        {
            InitializeComponent();
            timer = new System.Timers.Timer();
            timer.Interval = 2000;
            timer.Elapsed += timer_Elapsed;
        }

        private void btConnectServer_Click(object sender, EventArgs e)
        {
            try
            {
                // Create one SocketPermission for socket access restrictions 
                SocketPermission permission = new SocketPermission(
                    NetworkAccess.Connect,    // Connection permission 
                    TransportType.Tcp,        // Defines transport types 
                    teIp.Text,                       // Gets the IP addresses 
                    int.Parse(tePortNumber.Value.ToString()) // All ports 
                    );

                // Ensures the code to have permission to access a Socket 
                permission.Demand();

                // Create one Socket object to setup Tcp connection 
                senderSock = new Socket(
                    AddressFamily.InterNetwork,// Specifies the addressing scheme 
                    SocketType.Stream,   // The type of socket  
                    ProtocolType.Tcp     // Specifies the protocols  
                    );

                senderSock.NoDelay = false;   // Using the Nagle algorithm 
                ipEndPoint = new IPEndPoint(IPAddress.Parse(teIp.Text), int.Parse(tePortNumber.Value.ToString()));

                // Establishes a connection to a remote host 
                senderSock.Connect(ipEndPoint);
                btConnectedState();
                listMessage.Items.Add($"{senderSock.RemoteEndPoint} sunucuya bağlanıldı.");
                timer.Start();

                var thread = new Thread(new ThreadStart(server_oku));
                thread.Start();
            }
            catch (Exception ex)
            {
                btNotConnectedState();
                listMessage.Items.Add(
                    $"Sunucuya bağlantı başarısız. Host: {teIp.Text} , Port: {tePortNumber.Value}" +
                    "\nHata:\n" + ex.Message + Environment.NewLine + ex.InnerException?.Message);
                return;
            }
        }

        private void btConnectedState()
        {
            btConnectServer.Enabled = false;
            btNotConnected.Enabled = true;
        }
        private void btNotConnectedState()
        {
            btConnectServer.Enabled = true;
            btNotConnected.Enabled = false;
        }
        private void server_oku()
        {
            while (true)
            {
                //string sunucuMesaj = streamReader.ReadLine();
                //ekranayaz("Sunucudan mesaj geldi.\n" + sunucuMesaj);
            }
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                var random = new Random();
                var r_int = random.Next();
                var r_float = (float)random.NextDouble();
                var r_string = RandomString(5, false);

                var send_data = $"{r_int.ToString()},{r_float.ToString()},{r_string}";
                listMessage.Invoke(new MethodInvoker(delegate
                {
                    listMessage.Items.Add(send_data);
                }));

                if (senderSock.Connected)
                {
                    // Sending message 
                    //<Client Quit> is the sign for end of data                     
                    byte[] msg = Encoding.ASCII.GetBytes(send_data);

                    // Sends data to a connected Socket. 
                    int bytesSend = senderSock.Send(msg);
                }
                else
                {
                    listMessage.Invoke(new MethodInvoker(delegate
                    {
                        listMessage.Items.Add("Sunucuya bağlantı sağlanamıyor!");
                    }));
                    timer.Stop();
                }
            }
            catch (Exception ex)
            {
                listMessage.Invoke(new MethodInvoker(delegate
                {
                    listMessage.Items.Add("Hata:\n" + ex.Message + Environment.NewLine +
                    ex.InnerException?.Message);
                }));
                timer.Stop();
            }
        }

        // Generate a random string with a given size   
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        private void btNotConnectServer_Click(object sender, EventArgs e)
        {
            try
            {
                if (null != senderSock)
                {
                    // Disables sends and receives on a Socket. 
                    senderSock.Shutdown(SocketShutdown.Both);
                    //Closes the Socket connection and releases all resources 
                    senderSock.Close();
                }
                btNotConnectedState();
                timer.Stop();
            }
            catch (Exception ex)
            {
                listMessage.Items.Add(ex.Message + ex.InnerException?.Message);
            }
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (null != senderSock)
                {
                    // Disables sends and receives on a Socket. 
                    senderSock.Shutdown(SocketShutdown.Both);
                    //Closes the Socket connection and releases all resources 
                    senderSock.Close();
                    senderSock = null;
                }
                timer.Stop();
            }
            catch (Exception)
            {
            }
        }

        private void btGonder_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(teMessage.Text))
                    return;

                byte[] msg = Encoding.ASCII.GetBytes(teMessage.Text);
                senderSock.Send(msg);
                listMessage.Items.Add(teMessage.Text);
            }
            catch (Exception ex)
            {
                listMessage.Items.Add("Hata oluştu!\n"+ex.Message+Environment.NewLine+
                   ex.InnerException?.Message );
            }
        }
    }
}

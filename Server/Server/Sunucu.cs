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
using System.Windows.Threading;

namespace Server
{
    public partial class Sunucu : Form
    {
        private IPEndPoint ipEndPoint;
        private Socket handler;
        private Socket sListener;
        private SocketPermission permission;
        public delegate void akisiDegistir(string text);

        public Sunucu()
        {
            InitializeComponent();
        }
        private void Sunucu_Load(object sender, EventArgs e)
        {
            listMessage.Items.Add("************Sunucu Programı************");
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            // Creates one SocketPermission object for access restrictions
            permission = new SocketPermission(
            NetworkAccess.Accept,     // Allowed to accept connections 
            TransportType.Tcp,        // Defines transport types 
            teIp.Text,                       // The IP addresses of local host 
            Int32.Parse(tePort.Value.ToString()) // Specifies all ports 
            );

            // Ensures the code to have permission to access a Socket 
            permission.Demand();

            ipEndPoint = null;
            ipEndPoint = new IPEndPoint(IPAddress.Parse(teIp.Text), Int32.Parse(tePort.Value.ToString()));
            sListener = null;
            sListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sListener.Bind(ipEndPoint);
            sListener.Listen(10);

            // Begins an asynchronous operation to accept an attempt 
            AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
            sListener.BeginAccept(aCallback, sListener);

            try
            {
                listMessage.Items.Add("Sunucu başlatıldı.");
                btStateStartedServer();
            }
            catch (Exception ex)
            {
                btStateStoppedServer();
                sListener.Shutdown(SocketShutdown.Both);
                listMessage.Items.Add("Sunucu başlatılamadı." + Environment.NewLine + ex.Message + ex.InnerException?.Message);
            }
        }

        private void btStateStartedServer()
        {
            btStart.Enabled = false;
            btStop.Enabled = true;
        }

        private void btStateStoppedServer()
        {
            btStart.Enabled = true;
            btStop.Enabled = false;
        }
        public void AcceptCallback(IAsyncResult ar)
        {
            Socket listener = null;

            // A new Socket to handle remote host communication 
            //Socket handler = null;
            try
            {
                // Receiving byte array 
                byte[] buffer = new byte[1024];
                // Get Listening Socket object 
                listener = (Socket)ar.AsyncState;
                // Create a new socket 
                handler = listener.EndAccept(ar);

                // Using the Nagle algorithm 
                handler.NoDelay = false;

                // Creates one object array for passing data 
                object[] obj = new object[2];
                obj[0] = buffer;
                obj[1] = handler;

                // Begins to asynchronously receive data 
                handler.BeginReceive(
                    buffer,        // An array of type Byt for received data 
                    0,             // The zero-based position in the buffer  
                    buffer.Length, // The number of bytes to receive 
                    SocketFlags.None,// Specifies send and receive behaviors 
                    new AsyncCallback(ReceiveCallback),//An AsyncCallback delegate 
                    obj            // Specifies infomation for receive operation 
                    );

                // Begins an asynchronous operation to accept an attempt 
                AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
                listener.BeginAccept(aCallback, listener);
            }
            catch (Exception ex)
            {
                listMessage.Invoke(new MethodInvoker(delegate { listMessage.Items.Add("Hata." + ex.Message + Environment.NewLine + ex.InnerException?.Message); }));
            }
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                if (!handler.Connected)
                    return;
                // Fetch a user-defined object that contains information 
                object[] obj = new object[2];
                obj = (object[])ar.AsyncState;

                // Received byte array 
                byte[] buffer = (byte[])obj[0];

                // A Socket to handle remote host communication. 
                handler = (Socket)obj[1];

                // Received message 
                string content = string.Empty;


                // The number of bytes received. 
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    content += Encoding.ASCII.GetString(buffer, 0,
                        bytesRead);

                    // If message contains "<Client Quit>", finish receiving
                    if (content.IndexOf("<Client Quit>") > -1)
                    {
                        // Convert byte array to string
                        string str = content.Substring(0, content.LastIndexOf("<Client Quit>"));

                        //this is used because the UI couldn't be accessed from an external Thread
                        listMessage.Invoke(new MethodInvoker(delegate { listMessage.Items.Add("Read " + str.Length * 2 + " bytes from client.\n Data: " + str); }));

                    }
                    else
                    {
                        // Continues to asynchronously receive data
                        byte[] buffernew = new byte[1024];
                        obj[0] = buffernew;
                        obj[1] = handler;
                        handler.BeginReceive(buffernew, 0, buffernew.Length,
                            SocketFlags.None,
                            new AsyncCallback(ReceiveCallback), obj);
                    }

                    listMessage.Invoke(new MethodInvoker(delegate
                    {
                        listMessage.Items.Add("Client:" + handler.RemoteEndPoint.ToString() + "-->" + content);
                        listMessage.TopIndex = listMessage.Items.Count;
                    }));
                }

            }
            catch (Exception ex)
            {
                listMessage.Invoke(new MethodInvoker(delegate { listMessage.Items.Add("Hata." + ex.Message + Environment.NewLine + ex.InnerException?.Message); }));
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (null != handler)
                {
                    if (handler.Connected)
                        handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
                if (null != sListener)
                {
                    if (sListener.Connected)
                        sListener.Shutdown(SocketShutdown.Both);

                    sListener.Close();
                }

                permission.Deny();
                btStateStoppedServer();
                listMessage.Items.Add("Sunucu durduruldu.");
            }
            catch (Exception ex)
            {
                listMessage.Items.Add("Hata." + ex.Message + Environment.NewLine + ex.InnerException?.Message);
            }
        }
    }
}

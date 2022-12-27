using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw1
{
    public partial class Form1 : Form
    {

        bool terminating = false;
        bool connected = false;
        Socket clientsocket;
        String uname = "";
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }



        private void setToDC()
        {
            connected = false;
            button2_disconnect.Enabled = false;
            button1_connect.Enabled = true;
            postbutton.Enabled = false;
            Allpostsbutton.Enabled = false;
            Ipbox.Enabled = true;
            Usernamebox.Enabled = true;
            Portbox.Enabled = true;
            postbox.Enabled = false;
            username2textbox.Enabled = false;
            addfriendbutton.Enabled = false;
            removefriendbutton.Enabled = false;
            myposts.Enabled = false;
            friendposts.Enabled = false;
            showfriendsbutton.Enabled = false;
            postidbox.Enabled = false;
            removepostbutton.Enabled = false;
        }
        private void setToC()
        {
            connected = true;
            button2_disconnect.Enabled = true;
            button1_connect.Enabled = false;
            postbox.Enabled = true;
            postbutton.Enabled = true;
            Allpostsbutton.Enabled = true;
            Ipbox.Enabled = false;
            Usernamebox.Enabled = false;
            Portbox.Enabled = false;
            username2textbox.Enabled = true;
            addfriendbutton.Enabled = true;
            removefriendbutton.Enabled = true;
            myposts.Enabled=true;
            friendposts.Enabled = true;
            showfriendsbutton.Enabled = true;
            postidbox.Enabled = true;
            removepostbutton.Enabled = true;
        }

        private void button1_connect_Click(object sender, EventArgs e)
        {
            clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            String IP = Ipbox.Text;
            int portNum;
            uname = Usernamebox.Text;
            terminating = false;
            if(Int32.TryParse(Portbox.Text, out portNum) && IP != null && uname != null && IP != "" && uname!="")
            {
                try
                {
                    
                    clientsocket.Connect(IP, portNum);
                    Thread receivethread = new Thread(Receive);
                    receivethread.Start();
                    connected = true;
                    string msge= uname + ";";
                    Byte[] buffer2 = Encoding.Default.GetBytes(uname + ";");
                    clientsocket.Send(buffer2);
                    



                }
                catch
                {
                    clientlogs.AppendText("Couldn't connect to the server\n");
                }

            }
            else
            {
                clientlogs.AppendText("Check your username, IP Address or port number\n");
            }

        }

        private void Receive()
        {
            while (connected)
            {
                //clientlogs.AppendText("denioz!\n");//sil
                try {


                    //clientlogs.AppendText("Yolluyoz!\n");//sil
                    Byte[] buffer = new Byte[1024];
                    clientsocket.Receive(buffer);
                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    //incomingMessage = incomingMessage.Trim('\0');
                    //string[] msgArr = incomingMessage.Split(';');
                    //clientlogs.AppendText("a\n");
                    //clientlogs.AppendText("Yolladk aldik maldik!\n");//sil
                    if (incomingMessage == "Please enter a valid username\n" || incomingMessage == "There is another connected with this name.\n")
                    {
                            clientlogs.AppendText(incomingMessage);
    
                    }
                    else
                    {
                        setToC();
                        clientlogs.AppendText(incomingMessage);

                    }
                }
                catch
                {
                    if (!terminating)
                    {
                        clientlogs.AppendText("The server has disconnected.\n");
                        button1_connect.Enabled = true;
                        //textBox3_message.Enabled = false;
                        //button2_send.Enabled = false;
                    }
                    clientsocket.Close();
                    connected = false;
                    button2_disconnect.Enabled = false;
                    button1_connect.Enabled = true;
                    postbutton.Enabled = false;
                    Allpostsbutton.Enabled = false;
                    Ipbox.Enabled = true;
                    Usernamebox.Enabled = true;
                    Portbox.Enabled = true;
                    postbox.Enabled = false;
                    username2textbox.Enabled = false;
                    addfriendbutton.Enabled = false;
                    removefriendbutton.Enabled = false;
                    myposts.Enabled = false;
                    friendposts.Enabled = false;
                    showfriendsbutton.Enabled = false;
                    postidbox.Enabled = false;
                    removepostbutton.Enabled = false;
                }
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);

        }


        private void button2_disconnect_Click(object sender, EventArgs e)
        {
            connected = false;
            button2_disconnect.Enabled = false;
            button1_connect.Enabled = true;
            Allpostsbutton.Enabled = false;
            postbutton.Enabled = false;
            Ipbox.Enabled = true;
            Usernamebox.Enabled = true;
            Portbox.Enabled = true;
            postbox.Enabled = false;
            username2textbox.Enabled = false;
            addfriendbutton.Enabled = false;
            removefriendbutton.Enabled = false;
            myposts.Enabled = false;
            friendposts.Enabled = false;
            showfriendsbutton.Enabled = false;
            postidbox.Enabled = false;
            removepostbutton.Enabled = false;
            clientlogs.AppendText("Successfully disconnected.\n");
            terminating = true;
            string username = Usernamebox.Text;
            string userinfos = username + ";requesttoDC";
            Byte[] buffer = Encoding.Default.GetBytes(userinfos);
            clientsocket.Send(buffer);
            clientsocket.Close();
        }

        private void postbutton_Click(object sender, EventArgs e)
        {
            string post = postbox.Text;
            string username = Usernamebox.Text;
            if (post == "")
                clientlogs.AppendText("Please enter a message!\n");
            else if (post != "")
            {
                string userinfos = username + ";requesttopostapost;" + post;
                Byte[] buffer = Encoding.Default.GetBytes(userinfos);
                clientsocket.Send(buffer);
            }

        }

        private void Allpostsbutton_Click(object sender, EventArgs e)
        {
            string requestallpostsstring = uname+";ReQueStdummystringasdf:*-";
            Byte[] buffer = Encoding.Default.GetBytes(requestallpostsstring);
            clientsocket.Send(buffer);
        }


        private void myposts_Click(object sender, EventArgs e)
        {
            string requestmypostsstring = uname + ";ReQueStdummystringasdf:*-my";
            Byte[] buffer = Encoding.Default.GetBytes(requestmypostsstring);
            clientsocket.Send(buffer);
        }

        private void friendposts_Click(object sender, EventArgs e)
        {
            string requestfriendpostsstring = uname + ";ReQueStdummystringasdf:*-friend";
            Byte[] buffer = Encoding.Default.GetBytes(requestfriendpostsstring);
            clientsocket.Send(buffer);
        }

        private void removepostbutton_Click(object sender, EventArgs e)
        {
            string postid = postidbox.Text;
            string username = Usernamebox.Text;
            int postNum;
            if (postid == null || postid == "" || !(Int32.TryParse(postid, out postNum)))
                clientlogs.AppendText("Please enter a valid post id!\n");
            else
            {
                string postinfos = username + ";deletepostwithid;" + postid;
                Byte[] buffer = Encoding.Default.GetBytes(postinfos);
                clientsocket.Send(buffer);
            }
        }

        private void removefriendbutton_Click(object sender, EventArgs e)
        {
            string friendid = username2textbox.Text;
            string username = Usernamebox.Text;
            if (friendid == null || friendid == "" )
                clientlogs.AppendText("Please enter a valid friend name!\n");
            else
            {
                string friendinfos = username + ";removefriendwithid;" + friendid;
                Byte[] buffer = Encoding.Default.GetBytes(friendinfos);
                clientsocket.Send(buffer);
            }
        }

        private void addfriendbutton_Click(object sender, EventArgs e)
        {
            string friendid = username2textbox.Text;
            string username = Usernamebox.Text;
            if (friendid == null || friendid == "")
                clientlogs.AppendText("Please enter a valid friend name!\n");
            else
            {
                string friendinfos = username + ";addfriendwithid;" + friendid;
                Byte[] buffer = Encoding.Default.GetBytes(friendinfos);
                clientsocket.Send(buffer);
            }
        }

        private void showfriendsbutton_Click(object sender, EventArgs e)
        {
            string username = Usernamebox.Text;
            string friendshow = username + ";requestfriendsstring";
            Byte[] buffer = Encoding.Default.GetBytes(friendshow);
            clientsocket.Send(buffer);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw1sv
{
    public partial class Form1 : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();

        bool terminating = false;
        bool listening = false;
        string id = "0";
        string lastUser = "";
        List<String> connectedUsers = new List<String>();
        
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void Button_Listen_Click(object sender, EventArgs e)
        {
            int serverPort;

            if(Int32.TryParse(PorttextBox.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(15);

                listening = true;
                Button_Listen.Enabled = false;
                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                consolelogs.AppendText("Started listening on port: " + serverPort + "\n");

            }
            else
            {
                consolelogs.AppendText("Check the port number!\n");
            }



        }
        private void Accept()
        {
            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    clientSockets.Add(newClient);
                    //consolelogs.AppendText("A client has connected!\n");

                    Thread receiveThread = new Thread(() => Receive(newClient));
                    receiveThread.Start();

                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        consolelogs.AppendText("The socket stopped working.\n");
                    }
                }
                 
            }
        }

        private void Receive(Socket thisClient)
        {
            bool connected = true;

            while (connected && !terminating)
            {
                
                try
                {
                   
                    Byte[] buffer1 = new Byte[1024];
                    thisClient.Receive(buffer1);
                    string buffer1msg = Encoding.Default.GetString(buffer1);
                    buffer1msg = buffer1msg.Substring(0, buffer1msg.IndexOf("\0"));
                    //consolelogs.AppendText("Client: " + buffer1msg + "\n");
                    string[] bufferline = buffer1msg.Split(';');
                    string userinfos = buffer1msg;
                    string username = bufferline[0];
                    lastUser = bufferline[0];
                    if (!File.Exists("../../user-db.txt"))
                    {
                        File.Create("../../user-db.txt").Close();
                    }
                    if (!File.Exists("../../friends.txt"))
                    {
                        File.Create("../../friends.txt").Close();
                    }
                    if (!File.Exists("../../posts.txt"))
                    {
                        File.Create("../../posts.txt").Close();
                    }
                    var lines = File.ReadAllLines("../../user-db.txt");
                    bool Notinfile = true;
                    
                    if (buffer1msg[buffer1msg.Length-1] == ';')
                    {
                        lines = File.ReadAllLines("../../user-db.txt");
                        foreach (string line in lines)
                        {
                            if (line == username)
                            {
                                Notinfile = false;
                            }
                        }
                        
                        if (Notinfile)
                        {
                            /*using (StreamWriter file = new StreamWriter("../../database.txt", append: true))
                            {
                                file.WriteLine(userinfos);
                                Notinfile = true;
                            }*/
                            consolelogs.AppendText(username + " tried to connect to the server but cannot!\n");
                            string message = "Please enter a valid username\n";
                            Byte[] buffer = Encoding.Default.GetBytes(message);
                            thisClient.Send(buffer);
                        }
                        
                        else
                        {
                            //user already exists
                            if (connectedUsers.Contains(username))
                            {
                                consolelogs.AppendText(username + " tried to connect but there is another of same name.\n");
                                string message = "There is another connected with this name.\n";
                                Byte[] buffer = Encoding.Default.GetBytes(message);
                                thisClient.Send(buffer);
                            }
                            else
                            {
                                connectedUsers.Add(username);
                                consolelogs.AppendText(username + " has connected.\n");
                                string message = "Hello " + username + "! You are connected to server.\n";
                                Byte[] buffer = Encoding.Default.GetBytes(message);
                                thisClient.Send(buffer);
                            }
                            
                        }
                    }
                    else
                    {
                        string requestcode = bufferline[1];
                        if (requestcode == "ReQueStdummystringasdf:*-")
                        {

                            var posts = File.ReadAllLines("../../posts.txt");
                            var friends = File.ReadAllLines("../../friends.txt");
                            consolelogs.AppendText("Showed all posts for " + username + ".\n");
                            string msg = "\nShowing all posts from clients:\n";
                            if (posts.Count() == 0)
                            {
                                string asd = "No posts available from other users\n.";
                                Byte[] buffer = Encoding.Default.GetBytes(asd);
                                thisClient.Send(buffer);
                                consolelogs.AppendText(username + " requested all posts but " + asd);
                            }
                            posts = File.ReadAllLines("../../posts.txt");
                            foreach (string post in posts)
                            {
                                if (msg != "\nShowing all posts from clients:\n")
                                {
                                    msg = "";
                                }
                                string[] postline = post.Split(';');

                                if (postline[0] != username)
                                {
                                    //DateTime.Now.ToString("dd/MM/yyyy h:mm")
                                    msg = msg + "Username: " + postline[0] + "\n" + "PostID: " + postline[1] + "\n" + "Post: " + postline[2] + "\n" + "Time: " + postline[3] + "\n\n";
                                    Byte[] buffer = Encoding.Default.GetBytes(msg);
                                    thisClient.Send(buffer);

                                }
                            }
                        }
                        else if (requestcode == "ReQueStdummystringasdf:*-my")
                        {//request my posts

                            var posts = File.ReadAllLines("../../posts.txt");
                            var friends = File.ReadAllLines("../../friends.txt");
                            consolelogs.AppendText("Showed their posts for " + username + ".\n");
                            string msg = "\nShowing all posts from you:\n";
                            bool isexisting = false;
                            posts = File.ReadAllLines("../../posts.txt");
                            foreach (string post in posts)
                            {
                                if (msg != "\nShowing all posts from you:\n")
                                {
                                    msg = "";
                                }
                                string[] postline = post.Split(';');

                                if (postline[0] == username)
                                {
                                    //DateTime.Now.ToString("dd/MM/yyyy h:mm")
                                    isexisting = true;

                                    msg = msg + "Username: " + postline[0] + "\n" + "PostID: " + postline[1] + "\n" + "Post: " + postline[2] + "\n" + "Time: " + postline[3] + "\n\n";
                                    Byte[] buffer = Encoding.Default.GetBytes(msg);
                                    thisClient.Send(buffer);

                                }
                            }
                            if (!isexisting)
                            {
                                string mssg = "You have no posts!\n";
                                Byte[] buffer = Encoding.Default.GetBytes(mssg);
                                thisClient.Send(buffer);
                            }

                        }
                        else if (requestcode == "ReQueStdummystringasdf:*-friend")
                        {//request friend posts

                            var posts = File.ReadAllLines("../../posts.txt");
                            var friends = File.ReadAllLines("../../friends.txt");
                            consolelogs.AppendText("Showed friends posts for " + username + ".\n");
                            string msg = "\nShowing all friend posts of you:\n";
                            int x = 0;
                            bool friendpostexists = false;
                            List<string> friendarr = new List<string>(); ;
                            friends = File.ReadAllLines("../../friends.txt");
                            foreach (string friend in friends)
                            {

                                string[] friendline = friend.Split(';').Where(j => !string.IsNullOrWhiteSpace(j)).ToArray();

                                if (friendline[0] == username)
                                {
  
                                     friendarr.Add(friendline[1]);

                                }
                                
                            }
                            foreach (string usernam in friendarr)
                            {
                                posts = File.ReadAllLines("../../posts.txt");
                                foreach (string post in posts)
                                {
                                    if (msg != "\nShowing all friend posts of you:\n")
                                    {
                                        msg = "";
                                    }
                                    string[] postline = post.Split(';');

                                    if (postline[0] == usernam)
                                    {
                                        friendpostexists = true;
                                        msg = msg + "Username: " + postline[0] + "\n" + "PostID: " + postline[1] + "\n" + "Post: " + postline[2] + "\n" + "Time: " + postline[3] + "\n\n";
                                        Byte[] buffer = Encoding.Default.GetBytes(msg);
                                        thisClient.Send(buffer);

                                    }
                                }
                            }
                            if (!friendpostexists)
                            {
                                string mssg = "You have no friend posts!\n";
                                Byte[] buffer = Encoding.Default.GetBytes(mssg);
                                thisClient.Send(buffer);
                            }
                        }
                        else if (requestcode == "deletepostwithid")
                        {//delete post

                            var posts = File.ReadAllLines("../../posts.txt");
                            var friends = File.ReadAllLines("../../friends.txt");
                            string postowner="";
                            string posttodelete = "";
                            bool isexists = false;
                            posts = File.ReadAllLines("../../posts.txt");
                            foreach (string post in posts)
                            {
                                string[] postline = post.Split(';');
                                if (postline[1] == bufferline[2])
                                {
                                    posttodelete = post;
                                    postowner = postline[0];
                                    isexists = true;
                                }
                            }
                            if (!isexists)
                            {
                                consolelogs.AppendText(username + " tried to delete a post that doesn't exist.\n");
                                string msg = "This post doesn't exist.\n";
                                Byte[] buffer = Encoding.Default.GetBytes(msg);
                                thisClient.Send(buffer);
                            }
                            else
                            {
                                if(username != postowner)
                                {
                                    consolelogs.AppendText(username + " tried to delete "+postowner+"'s post.\n");
                                    string msg = "You can't delete post of "+ postowner +".\n";
                                    Byte[] buffer = Encoding.Default.GetBytes(msg);
                                    thisClient.Send(buffer);
                                }
                                else
                                {
                                    //s
                                    //s
                                    //BURAYA POST SILMEYI YAP
                                    File.WriteAllLines("../../posts.txt", File.ReadAllLines("../../posts.txt").Where(l => l != posttodelete).ToList());

                                    consolelogs.AppendText(username + " deleted post with id "+ bufferline[2] +".\n");
                                    string msg = "You deleted post with id "+ bufferline[2] +".\n";
                                    Byte[] buffer = Encoding.Default.GetBytes(msg);
                                    thisClient.Send(buffer);
                                }
                            }
                        }
                        else if (requestcode == "removefriendwithid")
                        {//remove friend
                         //read all file to list, process the list, write to file, empty the string

                            var posts = File.ReadAllLines("../../posts.txt");
                            var friends = File.ReadAllLines("../../friends.txt");
                            if (bufferline[0] == bufferline[2])
                            {
                                consolelogs.AppendText(username + " tried to remove theirself as a friend!\n");
                                string message = "You can't remove yourself as a friend!\n";
                                Byte[] buffer = Encoding.Default.GetBytes(message);
                                thisClient.Send(buffer);
                            }
                            else
                            {
                                var lines2 = File.ReadAllLines("../../user-db.txt");
                                bool Notinfile2 = true;
                                lines2 = File.ReadAllLines("../../user-db.txt");
                                foreach (string line2 in lines2)
                                {
                                    if (line2 == bufferline[2])
                                    {
                                        Notinfile2 = false;
                                    }
                                }

                                if (Notinfile2)
                                {
                                    consolelogs.AppendText(username + " tried to remove " + bufferline[2] + " but no such user!\n");
                                    string message = "Please enter a valid username to remove as friend!\n";
                                    Byte[] buffer = Encoding.Default.GetBytes(message);
                                    thisClient.Send(buffer);
                                }
                                else
                                {
                                    string linetodelete1 = "", linetodelete2 = "";
                                    bool alreadyadded = false;
                                    friends = File.ReadAllLines("../../friends.txt");
                                    foreach (string friend in friends)
                                    {

                                        string[] friendline = friend.Split(';').Where(j => !string.IsNullOrWhiteSpace(j)).ToArray();
                                        if ((friendline[0] == username && friendline[1] == bufferline[2]) || (friendline[0] == bufferline[2] && friendline[1] == username))
                                        {
                                            if (linetodelete1 == "")
                                            {
                                                linetodelete1 = friend;
                                            }
                                            else
                                            {
                                                linetodelete2 = friend;
                                            }
                                            alreadyadded = true;
                                        }
                                    }
                                    if (!alreadyadded)
                                    {
                                        consolelogs.AppendText(username + " tried to remove " + bufferline[2] + " but they are not friends!\n");
                                        string message = "You can't remove someone who already is not your friend!\n";
                                        Byte[] buffer = Encoding.Default.GetBytes(message);
                                        thisClient.Send(buffer);
                                    }
                                    else
                                    {
                                        //ekle

                                        File.WriteAllLines("../../friends.txt", File.ReadAllLines("../../friends.txt").Where(l => (l != linetodelete1 && l != linetodelete2)).ToList());

                                        consolelogs.AppendText(username + " removed " + bufferline[2] + " from friends\n");
                                        string message = "You removed " + bufferline[2] + " from friends!\n";
                                        Byte[] buffer = Encoding.Default.GetBytes(message);
                                        thisClient.Send(buffer);
                                        linetodelete1 = "";
                                        linetodelete2 = "";
                                    }
                                }
                            }

                        }
                        else if (requestcode == "addfriendwithid")
                        {//add friend

                            var posts = File.ReadAllLines("../../posts.txt");
                            var friends = File.ReadAllLines("../../friends.txt");
                            if (bufferline[0] == bufferline[2])
                            {
                                consolelogs.AppendText(username + " tried to add theirself as a friend!\n");
                                string message = "You can't add yourself as a friend!\n";
                                Byte[] buffer = Encoding.Default.GetBytes(message);
                                thisClient.Send(buffer);
                            }
                            else
                            {
                                var lines2 = File.ReadAllLines("../../user-db.txt");
                                bool Notinfile2 = true;
                                lines2 = File.ReadAllLines("../../user-db.txt");
                                foreach (string line2 in lines2)
                                {
                                    if (line2 == bufferline[2])
                                    {
                                        Notinfile2 = false;
                                    }
                                }

                                if (Notinfile2)
                                {
                                    consolelogs.AppendText(username + " tried to add " + bufferline[2] + " but no such user!\n");
                                    string message = "Please enter a valid username to add as friend!\n";
                                    Byte[] buffer = Encoding.Default.GetBytes(message);
                                    thisClient.Send(buffer);
                                }
                                else
                                {
                                    bool alreadyadded = false;
                                    friends = File.ReadAllLines("../../friends.txt");
                                    foreach (string friend in friends)
                                    {
                                        string[] friendline = friend.Split(';').Where(j => !string.IsNullOrWhiteSpace(j)).ToArray();
                                        if (friendline[0] == username && friendline[1] == bufferline[2])
                                        {
                                            alreadyadded = true;
                                        }
                                    }
                                    if (alreadyadded)
                                    {
                                        consolelogs.AppendText(username + " tried to add " + bufferline[2] + " but they are already friends!\n");
                                        string message = "You can't add someone who already is a friend!\n";
                                        Byte[] buffer = Encoding.Default.GetBytes(message);
                                        thisClient.Send(buffer);
                                    }
                                    else
                                    {
                                        //ekle
                                        string friendline1 = username + ";" + bufferline[2];
                                        string friendline2 = bufferline[2] + ";" + username;
                                        using (StreamWriter filex = new StreamWriter("../../friends.txt", append: true))
                                        {
                                            filex.WriteLine(friendline1);
                                            filex.WriteLine(friendline2);
                                        }

                                        consolelogs.AppendText(username + " added " + bufferline[2] + " as a friend!\n");
                                        string message = "You added " + bufferline[2] + " as a friend!\n";
                                        Byte[] buffer = Encoding.Default.GetBytes(message);
                                        thisClient.Send(buffer);
                                    }
                                }

                            }

                        }
                        else if (requestcode == "requestfriendsstring")
                        {//show friends

                            var posts = File.ReadAllLines("../../posts.txt");
                            var friends = File.ReadAllLines("../../friends.txt");
                            consolelogs.AppendText("Showed their friends for " + username + ".\n");
                            string msg = "\nShowing all friends of you:\n";
                            int x = 0;
                            bool hasfriends = false;
                            friends = File.ReadAllLines("../../friends.txt");
                            foreach (string friend in friends)
                            {
                                x = 0;
                                if (msg != "\nShowing all friends of you:\n")
                                {
                                    msg = "";
                                }
                                string[] friendline = friend.Split(';').Where(j => !string.IsNullOrWhiteSpace(j)).ToArray();

                                if (friendline[0] == username)
                                {

                                    msg = msg + friendline[1] + "\n";
                                    hasfriends = true;

                                    
                                    Byte[] buffer = Encoding.Default.GetBytes(msg);
                                    thisClient.Send(buffer);

                                }
                            }
                            if (hasfriends)
                            {
                            }
                            else
                            {
                                string mssg = "You have no friends!\n";
                                Byte[] buffer = Encoding.Default.GetBytes(mssg);
                                thisClient.Send(buffer);
                                
                            }
                        }
                        else if(requestcode=="requesttopostapost")
                        {

                            var posts = File.ReadAllLines("../../posts.txt");
                            var friends = File.ReadAllLines("../../friends.txt");
                            int i = 0;
                            int id = 0;
                            int ij = posts.Count();
                            posts = File.ReadAllLines("../../posts.txt");
                            foreach (string posta in posts)
                            {
                                i++;
                                if (i == ij)
                                {
                                    string[] line = posta.Split(';');
                                    Int32.TryParse(line[1], out id);
                                    id++;
                                }
                            }
                            
                            string postline = username + ";" + id + ";" + bufferline[2] + ";" + DateTime.Now.ToString("dd/MM/yyyy h:mm");

                            using (StreamWriter filex = new StreamWriter("../../posts.txt", append: true))
                            {
                                filex.WriteLine(postline);
                            }
                            
                            consolelogs.AppendText(username + " has sent a post:\n" + bufferline[2] + "\n");
                            string messag = "You have successfully sent a post!\n" + username + ": " + bufferline[2] + "\n";
                            Byte[] buffer = Encoding.Default.GetBytes(messag);
                            thisClient.Send(buffer);
                        }
                        else if (requestcode == "requesttoDC")
                        {
                            connectedUsers.Remove(username);
                        }
                    }
                   
                    
                }
                 catch(Exception)
                {
                    if (!terminating)
                    {
                        if (connectedUsers.Contains(lastUser))
                        {
                            connectedUsers.Remove(lastUser);
                        }
                        consolelogs.AppendText(lastUser + " has disconnected!\n");
                    }
                    thisClient.Close();
                    clientSockets.Remove(thisClient);
                    connected = false;
                }
            }
        }
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }


    }
}

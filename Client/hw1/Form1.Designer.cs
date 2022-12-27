namespace hw1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Ipbox = new System.Windows.Forms.TextBox();
            this.Usernamebox = new System.Windows.Forms.TextBox();
            this.Portbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.clientlogs = new System.Windows.Forms.RichTextBox();
            this.button1_connect = new System.Windows.Forms.Button();
            this.button2_disconnect = new System.Windows.Forms.Button();
            this.postbox = new System.Windows.Forms.TextBox();
            this.postbutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Allpostsbutton = new System.Windows.Forms.Button();
            this.friendposts = new System.Windows.Forms.Button();
            this.myposts = new System.Windows.Forms.Button();
            this.username2textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addfriendbutton = new System.Windows.Forms.Button();
            this.removefriendbutton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.postidbox = new System.Windows.Forms.TextBox();
            this.removepostbutton = new System.Windows.Forms.Button();
            this.showfriendsbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Ipbox
            // 
            this.Ipbox.Location = new System.Drawing.Point(99, 103);
            this.Ipbox.Name = "Ipbox";
            this.Ipbox.Size = new System.Drawing.Size(170, 20);
            this.Ipbox.TabIndex = 0;
            this.Ipbox.Text = "127.0.0.1";
            // 
            // Usernamebox
            // 
            this.Usernamebox.Location = new System.Drawing.Point(99, 181);
            this.Usernamebox.Name = "Usernamebox";
            this.Usernamebox.Size = new System.Drawing.Size(170, 20);
            this.Usernamebox.TabIndex = 3;
            // 
            // Portbox
            // 
            this.Portbox.Location = new System.Drawing.Point(99, 140);
            this.Portbox.Name = "Portbox";
            this.Portbox.Size = new System.Drawing.Size(170, 20);
            this.Portbox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Username:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Port:";
            // 
            // clientlogs
            // 
            this.clientlogs.Location = new System.Drawing.Point(288, 103);
            this.clientlogs.Name = "clientlogs";
            this.clientlogs.Size = new System.Drawing.Size(362, 413);
            this.clientlogs.TabIndex = 12;
            this.clientlogs.Text = "";
            // 
            // button1_connect
            // 
            this.button1_connect.Location = new System.Drawing.Point(185, 237);
            this.button1_connect.Name = "button1_connect";
            this.button1_connect.Size = new System.Drawing.Size(84, 30);
            this.button1_connect.TabIndex = 13;
            this.button1_connect.Text = "Connect";
            this.button1_connect.UseVisualStyleBackColor = true;
            this.button1_connect.Click += new System.EventHandler(this.button1_connect_Click);
            // 
            // button2_disconnect
            // 
            this.button2_disconnect.Enabled = false;
            this.button2_disconnect.Location = new System.Drawing.Point(185, 287);
            this.button2_disconnect.Name = "button2_disconnect";
            this.button2_disconnect.Size = new System.Drawing.Size(84, 35);
            this.button2_disconnect.TabIndex = 14;
            this.button2_disconnect.Text = "Disconnect";
            this.button2_disconnect.UseVisualStyleBackColor = true;
            this.button2_disconnect.Click += new System.EventHandler(this.button2_disconnect_Click);
            // 
            // postbox
            // 
            this.postbox.Enabled = false;
            this.postbox.Location = new System.Drawing.Point(74, 548);
            this.postbox.Name = "postbox";
            this.postbox.Size = new System.Drawing.Size(195, 20);
            this.postbox.TabIndex = 15;
            // 
            // postbutton
            // 
            this.postbutton.Enabled = false;
            this.postbutton.Location = new System.Drawing.Point(288, 548);
            this.postbutton.Name = "postbutton";
            this.postbutton.Size = new System.Drawing.Size(75, 20);
            this.postbutton.TabIndex = 16;
            this.postbutton.Text = "Send";
            this.postbutton.UseVisualStyleBackColor = true;
            this.postbutton.Click += new System.EventHandler(this.postbutton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 552);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Post:";
            // 
            // Allpostsbutton
            // 
            this.Allpostsbutton.Enabled = false;
            this.Allpostsbutton.Location = new System.Drawing.Point(380, 547);
            this.Allpostsbutton.Name = "Allpostsbutton";
            this.Allpostsbutton.Size = new System.Drawing.Size(75, 23);
            this.Allpostsbutton.TabIndex = 18;
            this.Allpostsbutton.Text = "All Posts";
            this.Allpostsbutton.UseVisualStyleBackColor = true;
            this.Allpostsbutton.Click += new System.EventHandler(this.Allpostsbutton_Click);
            // 
            // friendposts
            // 
            this.friendposts.Enabled = false;
            this.friendposts.Location = new System.Drawing.Point(575, 547);
            this.friendposts.Name = "friendposts";
            this.friendposts.Size = new System.Drawing.Size(75, 23);
            this.friendposts.TabIndex = 19;
            this.friendposts.Text = "Friend Posts";
            this.friendposts.UseVisualStyleBackColor = true;
            this.friendposts.Click += new System.EventHandler(this.friendposts_Click);
            // 
            // myposts
            // 
            this.myposts.Enabled = false;
            this.myposts.Location = new System.Drawing.Point(475, 547);
            this.myposts.Name = "myposts";
            this.myposts.Size = new System.Drawing.Size(75, 23);
            this.myposts.TabIndex = 20;
            this.myposts.Text = "My Posts";
            this.myposts.UseVisualStyleBackColor = true;
            this.myposts.Click += new System.EventHandler(this.myposts_Click);
            // 
            // username2textbox
            // 
            this.username2textbox.Enabled = false;
            this.username2textbox.Location = new System.Drawing.Point(105, 419);
            this.username2textbox.Name = "username2textbox";
            this.username2textbox.Size = new System.Drawing.Size(170, 20);
            this.username2textbox.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 422);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Username2:";
            // 
            // addfriendbutton
            // 
            this.addfriendbutton.Enabled = false;
            this.addfriendbutton.Location = new System.Drawing.Point(99, 461);
            this.addfriendbutton.Name = "addfriendbutton";
            this.addfriendbutton.Size = new System.Drawing.Size(75, 20);
            this.addfriendbutton.TabIndex = 23;
            this.addfriendbutton.Text = "Add";
            this.addfriendbutton.UseVisualStyleBackColor = true;
            this.addfriendbutton.Click += new System.EventHandler(this.addfriendbutton_Click);
            // 
            // removefriendbutton
            // 
            this.removefriendbutton.Enabled = false;
            this.removefriendbutton.Location = new System.Drawing.Point(185, 461);
            this.removefriendbutton.Name = "removefriendbutton";
            this.removefriendbutton.Size = new System.Drawing.Size(75, 20);
            this.removefriendbutton.TabIndex = 24;
            this.removefriendbutton.Text = "Remove";
            this.removefriendbutton.UseVisualStyleBackColor = true;
            this.removefriendbutton.Click += new System.EventHandler(this.removefriendbutton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 631);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "PostId:";
            // 
            // postidbox
            // 
            this.postidbox.Enabled = false;
            this.postidbox.Location = new System.Drawing.Point(74, 628);
            this.postidbox.Name = "postidbox";
            this.postidbox.Size = new System.Drawing.Size(195, 20);
            this.postidbox.TabIndex = 26;
            // 
            // removepostbutton
            // 
            this.removepostbutton.Enabled = false;
            this.removepostbutton.Location = new System.Drawing.Point(194, 664);
            this.removepostbutton.Name = "removepostbutton";
            this.removepostbutton.Size = new System.Drawing.Size(75, 20);
            this.removepostbutton.TabIndex = 27;
            this.removepostbutton.Text = "Remove";
            this.removepostbutton.UseVisualStyleBackColor = true;
            this.removepostbutton.Click += new System.EventHandler(this.removepostbutton_Click);
            // 
            // showfriendsbutton
            // 
            this.showfriendsbutton.Enabled = false;
            this.showfriendsbutton.Location = new System.Drawing.Point(552, 621);
            this.showfriendsbutton.Name = "showfriendsbutton";
            this.showfriendsbutton.Size = new System.Drawing.Size(98, 23);
            this.showfriendsbutton.TabIndex = 28;
            this.showfriendsbutton.Text = "Show Friends";
            this.showfriendsbutton.UseVisualStyleBackColor = true;
            this.showfriendsbutton.Click += new System.EventHandler(this.showfriendsbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 739);
            this.Controls.Add(this.showfriendsbutton);
            this.Controls.Add(this.removepostbutton);
            this.Controls.Add(this.postidbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.removefriendbutton);
            this.Controls.Add(this.addfriendbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.username2textbox);
            this.Controls.Add(this.myposts);
            this.Controls.Add(this.friendposts);
            this.Controls.Add(this.Allpostsbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.postbutton);
            this.Controls.Add(this.postbox);
            this.Controls.Add(this.button2_disconnect);
            this.Controls.Add(this.button1_connect);
            this.Controls.Add(this.clientlogs);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Portbox);
            this.Controls.Add(this.Usernamebox);
            this.Controls.Add(this.Ipbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Ipbox;
        private System.Windows.Forms.TextBox Usernamebox;
        private System.Windows.Forms.TextBox Portbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox clientlogs;
        private System.Windows.Forms.Button button1_connect;
        private System.Windows.Forms.Button button2_disconnect;
        private System.Windows.Forms.TextBox postbox;
        private System.Windows.Forms.Button postbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Allpostsbutton;
        private System.Windows.Forms.Button friendposts;
        private System.Windows.Forms.Button myposts;
        private System.Windows.Forms.TextBox username2textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addfriendbutton;
        private System.Windows.Forms.Button removefriendbutton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox postidbox;
        private System.Windows.Forms.Button removepostbutton;
        private System.Windows.Forms.Button showfriendsbutton;
    }
}


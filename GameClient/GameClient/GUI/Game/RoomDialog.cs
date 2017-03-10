﻿using GameClient.API.Networking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    public partial class RoomDialog : Form
    {
       
        public RoomDialog()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            ResponseHandler.end += End;
        }
        public void Init()
        {
            username.Text = "Name: "+ Client.Username;
        }
      

        public void End()
        {
            MessageBox.Show("Game over");
            Close();
        }

        private void btn_xo_Click(object sender, EventArgs e)
        {
        //    string tag = (sender as Button).Tag.ToString();
            
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocket4Net;

namespace MultiRoomChatClient.API.Networking
{
    public class WSClient : IClient
    {
        WebSocket socket = null;
        string wsURI = null;
        LinkedList<string> messageQue = new LinkedList<string>();

        public event responseHandler responseReceived;
        public event errorMessage NewErrorMessage;

        public WSClient(string wsURI)
        {
            this.wsURI = wsURI;
        }

        public void StartClient()
        {
            socket = new WebSocket(wsURI);            //Инициализация веб сокет клиента 
            socket.Open();                                //Открытие соединения
            socket.MessageReceived += InvokeMessageReceived;

            socket.Closed += (sender, args) => ACHTUNG();

            socket.Error += (sender, args) => NewErrorMessage?.Invoke(args.Exception.Message);
        }

        private void ACHTUNG()
        {
            //throw new NotImplementedException();
        }

        private void InvokeMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            string message = e.Message;
            responseReceived(message);
        }

        public void AddRequest(string message)
        {
            socket.Send(message);
        }

        public void Disconnect()
        {
            socket.Close();
        }
    }
}

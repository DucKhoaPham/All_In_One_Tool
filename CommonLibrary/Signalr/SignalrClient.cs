using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using QI.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QI.Core.Signalr
{
    public interface ISignalrClient
    {
        Task<bool> SendMessage(params object[] message);
        void ReceiveMessage(string method, Action<string> action);
    }
    public class SignalrClient : ISignalrClient
    {
        private HubConnection connection;
        public SignalrClient(IOptions<AppConfigs> appConfigs)
        {
            ConnectAsync();
        }
        public async Task<bool> ConnectAsync()
        {
            if (connection != null && connection.State == HubConnectionState.Connected)
            {
                return true;
            }
            else
            {
                try
                {
                    connection = new HubConnectionBuilder().WithUrl("http://localhost:19277").Build();
                    await connection.StartAsync();
                    return true;
                }
                catch
                {
                    //log lại xem bị lỗi không connect được
                    return false;
                }
            }
        }
        public async Task<bool> SendMessage(params object[] message)
        {
            if (ConnectAsync().Result)
            {
                await connection.InvokeAsync("SendMessage", message);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ReceiveMessage(string method, Action<string> action)
        {
            connection.On<string>(method, (message) =>
            {
                action(message);
            });
        }
    }
}

using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.RealTime
{
    public class CommentProductRealTime:Hub
    {
        public async Task SendMessage(string user, string message, string avatar)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, avatar);
        }
    }
}

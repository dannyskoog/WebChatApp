using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using WebChatApp.Models;

namespace WebChatApp.Hubs
{
    public class ChatHub : Hub
    {
        private static List<HubUser> users = new List<HubUser>();

        public void InitializeConnection(string userName)
        {
            string userID = Context.ConnectionId;

            if (!users.Exists(u => u.ID.Equals(userID)))
            {
                HubUser user = new HubUser(userID, userName);
                users.Add(user);

                Clients.Caller.onConnectionInitialized(users, user);
                Clients.Others.onUserConnected(user);
            }
            else
            {
                throw new Exception();
            }
        }

        public override System.Threading.Tasks.Task OnDisconnected()
        {
            string userID = Context.ConnectionId;

            HubUser user = null;

            if ((user = users.FirstOrDefault(u => u.ID.Equals(Context.ConnectionId))) != null)
            {
                Clients.Caller.onConnectionDeinitialized();
                Clients.Others.onUserDisconnected(user.ID);
                users.Remove(user);
            }

            return base.OnDisconnected();
        }


        public void PostChatMessage(HubUser user, string chatMessage)
        {
            Clients.All.onNewChatMessage(user, chatMessage);

            user.IsTyping = false;
            Clients.Others.onIsUserTypingChanged(user);
        }

        public void IsUserTypingChanged(bool isUserTyping)
        {
            string userID = Context.ConnectionId;

            HubUser user = null;

            if ((user = users.FirstOrDefault(u => u.ID.Equals(Context.ConnectionId))) != null)
            {
                user.IsTyping = isUserTyping;
                Clients.Others.onIsUserTypingChanged(user);
            }
        }
    }
}
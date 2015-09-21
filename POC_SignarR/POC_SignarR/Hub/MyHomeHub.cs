namespace POC_SignarR
{
    using Microsoft.AspNet.SignalR;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;

    public class MyHomeHub : Hub
    {
        static ConcurrentDictionary<string, string> conexiones = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// On connected event.
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        /// <summary>
        /// On disconnected event.
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            string removeName;
            this.SendMessageToClients("<div class='user-disconnected'>es desconecta</div>", conexiones[Context.ConnectionId]);
            conexiones.TryRemove(Context.ConnectionId, out removeName);
            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// Send a message to all clients.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="userName"></param>
        public void SendMessageToClients(string message, string userName)
        {
            Clients.All.OnMessageReceived(message, userName);
        }

        /// <summary>
        /// Send user's names connected to all clients.
        /// </summary>
        /// <param name="userName"></param>
        public void SendUserNameConnectToClients(string userName)
        {
            conexiones.TryAdd(Context.ConnectionId, userName);
            Clients.All.OnUserNameConnect(userName);
        }
    }
}
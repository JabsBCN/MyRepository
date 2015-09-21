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

        public override Task OnDisconnected(bool stopCalled)
        {
            string removeName;
            this.SendMessageToClients("<div class='user-disconnected'>es desconecta</div>", conexiones[Context.ConnectionId]);
            conexiones.TryRemove(Context.ConnectionId, out removeName);
            return base.OnDisconnected(stopCalled);
        }

        public void SendMessageToClients(string message, string userName)
        {
            Clients.All.OnMessageReceived(message, userName);66
        }

        public void SendUserNameConnectToClients(string userName)
        {
            conexiones.TryAdd(Context.ConnectionId, userName);
            Clients.All.OnUserNameConnect(userName);
        }
    }
}
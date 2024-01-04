using Microsoft.AspNetCore.SignalR;

namespace EntityPresentor
{
    public class MyHub: Hub
    {
        public void SendCoordinates(CoordinatesEntity newCoordinates)
        {
            Clients.All.SendAsync("broadcastMessage", newCoordinates);
        }
    }
}
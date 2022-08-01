using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebsocktChatRoom
{
    public class WebsocketClient
    {
        public WebSocket WebSocket { get; set; }

        public string Id { get; set; }

        public string RoomNo { get; set; }

        public Task SendMessageAsync(string message)
        {
            var msg = Encoding.UTF8.GetBytes(message);
            //return webSocket.SendAsync(new ArraySegment<byte>(msg, 0, msg.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);
            return WebSocket.SendAsync(new ArraySegment<byte>(msg, 0, msg.Length), WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}

using System.Net;
using System.Net.Sockets;
using System.Text;
using UDP_Demo.Server;

var server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
var endPoint = new IPEndPoint(IPAddress.Loopback, 55555);
server.Bind(endPoint);

while (true)
{
    var buffer = new byte[1024];
    EndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
    var bytes = server.ReceiveFrom(buffer, ref clientEndPoint);
    var message = Encoding.UTF8.GetString(buffer, 0, bytes);
    var text = message.Split(":");
    User user = new User(text[0], text[1], text[2], text[3]);
    var word = text[4];

    var ip = ((IPEndPoint)clientEndPoint).Address;
    var port = ((IPEndPoint)clientEndPoint).Port;
    Console.WriteLine($"[{ip}:{port}]:{user.ToString()}:{word}");
}
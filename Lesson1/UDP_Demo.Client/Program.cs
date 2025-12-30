using System.Net;
using System.Net.Sockets;
using System.Text;
using UDP_Demo.Client;

var serverIp = IPAddress.Parse("127.0.0.1");
var serverEndPoint = new IPEndPoint(serverIp, 55555);
var server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

var id = Guid.NewGuid();
var data = Encoding.UTF8.GetBytes(id.ToString());
server.SendTo(data, serverEndPoint);

User user = new User(1, "Jack", "Nickolson", "Fiodorovich");

while (true)
{
    Console.Write("> ");
    var message = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(message)) continue; 
    
    data = Encoding.UTF8.GetBytes(user.ToString() + ":" + message);
    server.SendTo(data, serverEndPoint);
}
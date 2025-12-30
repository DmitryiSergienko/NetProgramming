using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

var ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 55555);
var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
server.Connect(ipEndPoint);

var buffer = new byte[1024];
var bytes = server.Receive(buffer);
var message = Encoding.UTF8.GetString(buffer, 0, bytes);
var token = GenerateToken(16);
var fio = Console.ReadLine();

//List<string> body = [token, message];
//var jsonBody = JsonSerializer.Serialize(body);

buffer = Encoding.UTF8.GetBytes("token " + token + " " + fio + ": " + " client connected");
server.Send(buffer);

while (true)
{
    Console.Write("> ");
    message = Console.ReadLine();

    buffer = Encoding.UTF8.GetBytes(fio + ": " + message);
    server.Send(buffer);
    if (message == "exit") break;
}

server.Shutdown(SocketShutdown.Both);
server.Close();

static string GenerateToken(int length = 32)
{
    using var rng = RandomNumberGenerator.Create();
    byte[] tokenData = new byte[length];
    rng.GetBytes(tokenData);
    return Convert.ToHexString(tokenData);
}
using System.Net;
using System.Net.Sockets;
using System.Text;

var ipEndPoint = new IPEndPoint(IPAddress.Loopback, 55555);
var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
listener.Bind(ipEndPoint);
listener.Listen(10);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Server started");
Console.ResetColor();

Dictionary<string, string> users = new Dictionary<string, string>();

while (true)
{
    var client = listener.Accept();
    _ = Task.Run(() =>
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Client connected");
        Console.ResetColor();

        var buffer = new byte[1024];
        client.Send(buffer);

        string textDisconection = "";
        string token = "";
        string fio = "";

        while (true)
        {
            var bytes = client.Receive(buffer);
            var message = Encoding.UTF8.GetString(buffer, 0, bytes);
            var list = message.Split(" ");
            
            if (list[0] == "token")
            {
                token = list[1];
                fio = list[2];

                Console.WriteLine(token);
                Console.WriteLine(fio);
                users.Add(token, fio);
            }

            if (list[1] == "exit")
            {
                textDisconection = token + " " + fio;
                break;
            }

            Console.WriteLine(list[0] + " " + list[1]);
        }

        client.Shutdown(SocketShutdown.Both);
        client.Close();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Client " + textDisconection + " disconnected");
        Console.ResetColor();
    });
}
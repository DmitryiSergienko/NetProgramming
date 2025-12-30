using System.Text.Json.Serialization;

var client = new HttpClient();
var post = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/1");
//var posts = await client.GetFromJsonAsync<IEnumerable<Post>>("https://jsonplaceholder.typicode.com/posts");
//var post = await client.GetFromJsonAsync<Post>("https://jsonplaceholder.typicode.com/posts?id=1");
Console.WriteLine(post);
return;

public record Post(
    [property: JsonPropertyName("userId")] int UserId,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("body")] string Body
);

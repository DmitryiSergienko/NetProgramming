using HTTP.Models;
using System.Net.Http.Json;

var client = new HttpClient();
const string url = "http://localhost:8080/persons";
//var persons = client.GetFromJsonAsAsyncEnumerable<Person>(url);

//await foreach(var person in persons)
//{
//    Console.WriteLine(person);
//}

var response = await client.GetAsync(url);
if(response.IsSuccessStatusCode)
{
    var persons = await response.Content.ReadFromJsonAsync<Person[]>();
    if(persons == null)
    {
        Console.WriteLine("No persons found");
        return;
    }
    foreach(var person in persons) 
    {  
        Console.WriteLine(person); 
    }
}
else
{
    Console.WriteLine(response.StatusCode);
}
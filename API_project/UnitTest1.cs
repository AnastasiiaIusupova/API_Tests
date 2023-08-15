using RestSharp;

namespace API_project;

public class Tests
{
    private RestClient client;
    [SetUp]
    public void Setup()
    {
         client = new RestClient("https://reqres.in/api");
    }

    [Test]
    public void GetUserById()
    {
        
        var request = new RestRequest("/users/2", Method.Get);
        var response = client.Execute(request);
        if (response.IsSuccessful)
        {
            Console.WriteLine(response.Content.ToString());
        }
        else
        {
            Console.WriteLine("Failed: " + response.ErrorMessage);
        }
    
    }

    [Test]
    public void CreateUser_Hardcode()
    {
        var request = new RestRequest("/users", Method.Post);
        var body = "{\r\n  \"name\": \"morpheus\",\r\n   \"job\": \"leader\"\r\r}";
        request.AddBody(body);
        var response = client.Execute(request);

        if (response.IsSuccessful)
        {
            Console.WriteLine(response.Content.ToString());
        }
        else
        {
            Console.WriteLine("Failed: " + response.ErrorMessage);
        }
    }
    
    [Test]
    public void CreateUser()
    {
        var request = new RestRequest("/users", Method.Post);
        var body = new
        {
            Name = "Ivan",
            Password = "QWERT344",
        };
        request.AddBody(body);
        var response = client.Execute(request);

        if (response.IsSuccessful)
        {
            Console.WriteLine(response.Content.ToString());
        }
        else
        {
            Console.WriteLine("Failed: " + response.ErrorMessage);
        }
    }
    
    [Test]
    public void CreateUser_Dictionry()
    {
        var request = new RestRequest("/users", Method.Post);
        var body = new Dictionary<string, object>()
        {
            { "Name", "Ivan" },
            { "Password", "WERT543" }
        };
        request.AddBody(body);
        var response = client.Execute(request);

        if (response.IsSuccessful)
        {
            Console.WriteLine(response.Content.ToString());
        }
        else
        {
            Console.WriteLine("Failed: " + response.ErrorMessage);
        }
    }
    
    
    [Test]
    public void CreateUser_File()
    {
        var request = new RestRequest("/users", Method.Post);
        var body = File.ReadAllText("User.json");
        request.AddBody(body);
        var response = client.Execute(request);

        if (response.IsSuccessful)
        {
            Console.WriteLine(response.Content.ToString());
        }
        else
        {
            Console.WriteLine("Failed: " + response.ErrorMessage);
        }
    }
}
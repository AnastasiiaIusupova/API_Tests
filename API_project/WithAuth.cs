using RestSharp;

namespace API_project;

public class WithAuth
{
    private RestClient client;

    [SetUp]
    public void Setup()
    {
        client = new RestClient("https://api.qase.io/v1");
    }

    [Test]
    public void GetProjects()
    {
        var request = new RestRequest("/projects", Method.Post);
        request.AddHeader("Token", "");
        
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
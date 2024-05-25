using NCMDotNetCore.ConsoleAppHttpClientExamples;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NCMDotNetCore.ConsoleAppRestClientExamples;

internal class RestClientExample
{
    private readonly RestClient _client = new RestClient(new Uri("https://localhost:7271")) ;
    private readonly string _endpoint = "/api/blog";

    public async Task RunAsync()
    {
        await ReadAsync();
        //await EditAsync(1);
        //await EditAsync(100);
        //await CreateAsync("title 1", "author 1", "content 1");
        //await UpdateAsync(12, "title 2", "author 2", "content 2");
    }

    public async Task ReadAsync()
    {
        RestRequest resRequest = new RestRequest(_endpoint, Method.Get);
        var response = await _client.ExecuteAsync(resRequest);

        if (response.IsSuccessStatusCode)
        {
            string jsonStr =  response.Content!;
            List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;

            foreach (var item in lst)
            {
                Console.WriteLine($"BlogId => {JsonConvert.SerializeObject(item.BlogId)}");
                Console.WriteLine($"BlogTitle => {JsonConvert.SerializeObject(item.BlogTitle)}");
                Console.WriteLine($"BlogAuthor => {JsonConvert.SerializeObject(item.BlogAuthor)}");
                Console.WriteLine($"BlogContent => {JsonConvert.SerializeObject(item.BlogContent)}");
                Console.WriteLine("*************************");
            }
            Console.ReadKey();
        }
    }
    private async Task EditAsync(int id)
    {
        RestRequest resRequest = new RestRequest($"{_endpoint}/{id}", Method.Get);
        var response = await _client.ExecuteAsync(resRequest);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;
            var item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
            Console.WriteLine(JsonConvert.DeserializeObject<object>(jsonStr));
            Console.WriteLine($"BlogId => {JsonConvert.SerializeObject(item.BlogId)}");
            Console.WriteLine($"BlogTitle => {JsonConvert.SerializeObject(item.BlogTitle)}");
            Console.WriteLine($"BlogAuthor => {JsonConvert.SerializeObject(item.BlogAuthor)}");
            Console.WriteLine($"BlogContent => {JsonConvert.SerializeObject(item.BlogContent)}");
            Console.WriteLine("*************************");

        }
        else
        {
            string message =  response.Content!;
            Console.WriteLine(message);
        }
    }
    private async Task CreateAsync(string title, string author, string content)
    {
        BlogModel blogModel = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        var restRequest = new RestRequest(_endpoint, Method.Post);
        restRequest.AddJsonBody(blogModel);
        var response = await _client.ExecuteAsync(restRequest);

        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }
    private async Task UpdateAsync(int id, string title, string author, string content)
    {
        BlogModel blogModel = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        var restRequest = new RestRequest($"{_endpoint}/{id}", Method.Put);
        restRequest.AddJsonBody(blogModel);
        var response = await _client.PutAsync(restRequest);

        if (response.IsSuccessStatusCode)
        {
            string message =  response.Content!;
            Console.WriteLine(message);
        }
    }
    private async Task DeleteAsync(int id)
    {
        RestRequest resRequest = new RestRequest($"{_endpoint}/{id}", Method.Delete);
        var response = await _client.ExecuteAsync(resRequest);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }
}

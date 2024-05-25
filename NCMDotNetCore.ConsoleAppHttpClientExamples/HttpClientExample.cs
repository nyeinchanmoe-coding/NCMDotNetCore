using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NCMDotNetCore.ConsoleAppHttpClientExamples
{
    internal class HttpClientExamplt
    {
        HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7271") };
        string _endpoint = "/api/blog";

        public async Task RunAsync()
        {
           // await ReadAsync();
            //await EditAsync(1);
            //await EditAsync(100);
            //await CreateAsync("title 1", "author 1", "content 1");
            await UpdateAsync(12, "title 2", "author 2", "content 2");
        }

        public async Task ReadAsync()
        {
            HttpResponseMessage response = await _client.GetAsync(_endpoint);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
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
            var response = await _client.GetAsync($"{_endpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
                Console.WriteLine(JsonConvert.DeserializeObject<Object>(jsonStr));
                Console.WriteLine($"BlogId => {JsonConvert.SerializeObject(item.BlogId)}");
                Console.WriteLine($"BlogTitle => {JsonConvert.SerializeObject(item.BlogTitle)}");
                Console.WriteLine($"BlogAuthor => {JsonConvert.SerializeObject(item.BlogAuthor)}");
                Console.WriteLine($"BlogContent => {JsonConvert.SerializeObject(item.BlogContent)}");
                Console.WriteLine("*************************");

            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
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
            string blogJson = JsonConvert.SerializeObject(blogModel);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PostAsync(_endpoint, httpContent);

            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
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
            string blogJson = JsonConvert.SerializeObject(blogModel);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PutAsync($"{_endpoint}/{id}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
        private async Task DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"{_endpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
    }   
}

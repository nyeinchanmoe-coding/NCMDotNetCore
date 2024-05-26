using NCMDotNetCore.ConsoleAppRefitExamples;
using Refit;

//var service = RestService.For<IBlogApi>("https://localhost:7004");
//var lst = await service.GetBlogs();

//foreach (var item in lst)
//{
//    Console.WriteLine($"BlogId => {(item.BlogId)}");
//    Console.WriteLine($"BlogTitle => {(item.BlogTitle)}");
//    Console.WriteLine($"BlogAuthor => {(item.BlogAuthor)}");
//    Console.WriteLine($"BlogContent => {(item.BlogContent)}");
//    Console.WriteLine("*************************");
//}

RefitExample refitExample = new RefitExample();
await refitExample.RunAsync();
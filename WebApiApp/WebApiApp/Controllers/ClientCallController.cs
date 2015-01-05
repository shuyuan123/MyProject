using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    public class ClientCallController : Controller
    {
        // GET: ClientCall
        public ActionResult Index()
        {
            Product product = new Product();
            RunAsync(product).Wait();
            return View();
        }

        async Task RunAsync(Product product)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://test.local.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/product/1");
                    response.EnsureSuccessStatusCode();
                    product = await response.Content.ReadAsAsync<Product>();
                }
                catch (HttpRequestException e)
                {
                    
                }
            }
        }
    }
}
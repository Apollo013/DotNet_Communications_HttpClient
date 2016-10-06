using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApiExample.Entities;

namespace WebApiExample.Client
{
    class Program
    {
        private static HttpClient client = GetClient();

        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        private static async Task RunAsync()
        {
            await GetProductsAsync();

            var prod = await GetProductAsync(2);

            await UpdateProduct(prod);

            var prodToDelete = await GetProductAsync(5);

            await Delete(prodToDelete);

            await GetProductsAsync();
        }

        /// <summary>
        /// Creates a new HttpClient
        /// </summary>
        /// <returns></returns>
        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:62094/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns></returns>
        private static async Task GetProductsAsync()
        {
            PrintTitle("Get Products Async");

            List<Product> prods = null;
            HttpResponseMessage res = await client.GetAsync("products");
            if (res.IsSuccessStatusCode)
            {
                var str = res.Content.ReadAsStringAsync().Result;
                prods = JsonConvert.DeserializeObject<List<Product>>(str);
                foreach (var prod in prods)
                {
                    PrintProduct(prod);
                }
            }
        }

        /// <summary>
        /// Gets a single product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static async Task<Product> GetProductAsync(int id)
        {
            PrintTitle($"Get Product Async: {id}");

            HttpResponseMessage res = await client.GetAsync($"products/{id}");
            if (res.IsSuccessStatusCode)
            {
                var str = res.Content.ReadAsStringAsync().Result;
                var prod = JsonConvert.DeserializeObject<Product>(str);
                PrintProduct(prod);
                return prod;
            }
            return null;
        }

        /// <summary>
        /// Updates a single product
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        private static async Task UpdateProduct(Product prod)
        {
            PrintTitle($"Update Product: {prod.Id}");
            Console.Write("Original: ");
            PrintProduct(prod);

            // Change
            prod.Name = "New Name";
            prod.Category = "New Category";

            // Update
            HttpResponseMessage res = await client.PutAsJsonAsync($"products/{prod.Id}", prod);
            res.EnsureSuccessStatusCode();

            // Print new
            Console.Write("New: ");
            PrintProduct(prod);
        }

        /// <summary>
        /// Deletes a single products
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static async Task Delete(Product prod)
        {
            PrintTitle($"Delete Product: {prod.Id}");
            HttpResponseMessage res = await client.DeleteAsync($"products/{prod.Id}");
            res.EnsureSuccessStatusCode();

            // Print deleted
            Console.Write("Deleted: ");
            PrintProduct(prod);
        }

        /// <summary>
        /// Prints an arbirary string
        /// </summary>
        /// <param name="title"></param>
        private static void PrintTitle(string title)
        {
            string divider = new string('-', 100);
            Console.WriteLine();
            Console.WriteLine(divider);
            Console.WriteLine(title);
            Console.WriteLine(divider);
        }

        /// <summary>
        /// Prints a product's details
        /// </summary>
        /// <param name="prod"></param>
        private static void PrintProduct(Product prod)
        {
            Console.WriteLine($"({prod.Id})\t{prod.Name,-20}\t{prod.Category,-20}\t{prod.Price}");
        }
    }
}

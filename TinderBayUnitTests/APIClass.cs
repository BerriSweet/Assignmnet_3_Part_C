using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TinderBayUnitTests
{
    /// <summary>
    /// handels all the methods related to the API
    /// </summary>
    class APIClass
    {
        public static Products[] ProductArray { get; set; }
        //public static Users[] UserArray { get; set; }
        public static Sales[] SaleArray { get; set; }
        public static List<string> SelectedTagsList { get; set; }

        /// <summary>
        /// Pulls all the data from the products database and adds it to first a list then an array
        /// </summary>
        /// <returns>List of Products "purchases"</returns>
        public static async Task<List<Products>> GetProductsAsync()
        {

            //Instantiating HTTPClient
            HttpClient client = new HttpClient();
            //String address (URL)
            var address = "http://profferapi20171114093444.azurewebsites.net/api/ProductsModels";
            //Awaiting Response
            var response = await client.GetAsync(address);
            string PurchaseJson = response.Content.ReadAsStringAsync().Result;
            List<Products> purchases = JsonConvert.DeserializeObject<List<Products>>(PurchaseJson);
            ProductArray = purchases.ToArray();
            return purchases;
        }
        /// <summary>
        /// Pulls all the data from the sales database and adds it to first a list then an array
        /// </summary>
        /// <returns>List of sales "sales"</returns>
        public static async Task<List<Sales>> GetSalesAsync()
        {
            //Instantiating HTTPClient
            HttpClient client = new HttpClient();
            //String address (URL)
            var address = "http://profferapi20171114093444.azurewebsites.net/api/SalesModels";
            //Awaiting Response
            var response = await client.GetAsync(address);
            string PurchaseJson = response.Content.ReadAsStringAsync().Result;
            List<Sales> sales = JsonConvert.DeserializeObject<List<Sales>>(PurchaseJson);
            SaleArray = sales.ToArray();
            return sales;
        }
    }
    /// <summary>
    /// Class for Products
    /// </summary>
    class Products
    {
        public string Product_id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public DateTime Upload_date { get; set; }
        public string ImageName { get; set; }
        public string User_id { get; set; }
    }
    /// <summary>
    /// class for Sales
    /// </summary>
    class Sales
    {
        public decimal Sales_price { get; set; }
        public DateTime Date_sold { get; set; }
        public string User_id { get; set; }
        public string Product_id { get; set; }
    }
}


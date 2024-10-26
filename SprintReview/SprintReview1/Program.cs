using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintReview1
{
    class Product
    {
        public string name { get; set; }
        private decimal price { get; set; }
        private int quantity { get; set; }
        protected string category { get; set; }
        internal string description { get; set; }
        public Product(string Name, decimal Price, int Quantity, string Category, string Description)
        {
            name = Name;
            price = Price;
            quantity = Quantity;
            category = Category;
            description = Description;
        }
        public decimal GetTotalPrice()
        {
            return (quantity * price);
        }
        public void UpdateQuantity(int amount)
        {
            quantity = amount;
        }
        public string GetProductInfo()
        {
            return ($"name: {name}, price: {price}, quantity: {quantity}, category: {category}, description: {description}");
        }
    }

    class Seller
    {
        public string name { get; set; }
        private string employeeld { get; set; }
        protected decimal salary { get; set; }
        internal string contactInfo { get; set; }
        public Seller(string Name, string Employeeld, decimal Salary, string ContactInfo)
        {
            name = Name;
            employeeld = Employeeld;
            salary = Salary;
            contactInfo = ContactInfo;
        }

        public void AddProduct(Product product)
        {
            Console.WriteLine($"product {product.name} added to {name}");
        }
        public void SellProduct(Product product, int quantity)
        {
            product.UpdateQuantity(quantity);
        }
        public string GetSellerInfo()
        {
            return ($"name: {name}, employeeld: {employeeld}, salary: {salary}, contact info: {contactInfo}");
        }
    }

    class Store
    {
        private string storeName { get; set; }
        private string location { get; set; }
        public string storeHours { get; set; }
        public Store(string StoreName, string Location, string StoreHours)
        {
            storeName = StoreName;
            location = Location;
            storeHours = StoreHours;
        }
        public void AddSeller(Seller seller)
        {
            Console.WriteLine($"seller {seller.name} added to {storeName}");
        }
        public void ListProducts(Product product)
        {
            Console.WriteLine($"list of products: {product.name}");
        }
        public string GetStoreInfo()
        {
            return ($"store name: {storeName}, location: {location}, store hours: {storeHours}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Milk", 10, 25, "Drinks", "description");
            Console.WriteLine("total price = " + product.GetTotalPrice());
            Console.WriteLine(product.GetProductInfo());
            Seller seller = new Seller("Andrey", "Seller", 5000, "contact info");
            seller.AddProduct(product);
            Console.WriteLine(seller.GetSellerInfo());
            Store store = new Store("Ashan", "Mendeleeva 1", "8");
            store.AddSeller(seller);
            store.ListProducts(product);
            Console.WriteLine(store.GetStoreInfo());
            Console.ReadKey();
        }
    }
}

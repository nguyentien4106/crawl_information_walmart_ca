using System;
using System.Collections.Generic;
using System.IO;
using CrawlWalmart.Data;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CrawlWalmart
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = GetAccounts();
            // Crawler crawler = new Crawler();
            var jsonInformations = new List<JsonInformation>();
            //crawler.Crawl(accounts[1], jsonInformations);
            jsonInformations = Fake();
            var json = JsonConvert.SerializeObject(jsonInformations, Formatting.Indented);
            File.WriteAllText(@"C:\Users\walter.nguyen\Desktop\Learning\output.json", json);
            Console.WriteLine("Json Success");
        }

        private static List<JsonInformation> Fake()
        {
            var res = new List<JsonInformation>();
            for (int i = 0; i < 10; i++)
            {
                res.Add(FakeInformation(i));
            }

            return res;
        }

        private static JsonInformation FakeInformation(int i)
        {
            return new JsonInformation()
            {
                Account = new Account()
                {
                    Username = $"Tien{i}",
                    Password = $"Tien{i}"

                },
                Address = $"Tan Chanh Hiep {i}",
                CreditCard = $"Fake Credit {i}",
                OrderInformations = new List<OrderInformation>
                {
                    new OrderInformation
                    {
                        OrderNumber = $"Order Number {i}",
                        PurchaseDate = $"Purchase Date {i}",
                        Status = i.ToString()
                    },
                    new OrderInformation
                    {
                        OrderNumber = $"Order Number {i + 1}",
                        PurchaseDate = $"Purchase Date {i + 1}",
                        Status = i.ToString()
                    },
                    new OrderInformation
                    {
                        OrderNumber = $"Order Number {i + 1}",
                        PurchaseDate = $"Purchase Date {i + 1}",
                        Status = i.ToString()
                    },
                }
            };
        }
        private static List<Account> GetAccounts()
        {
            return new List<Account>
            {
                new Account
                {
                    Username = "kf1998@lafasweets.com",
                    Password = "Lafa9924680"
                },
                new Account
                {
                    Username = "hadiddi@gmail.com",
                    Password = "Alger153"
                },
                new Account
                {
                    Username = "kostalapit406@hotmail.com",
                    Password = "kl050961"
                },
                new Account
                {
                    Username = "iossitom@gmail.com",
                    Password = "tomwalmarttom123"
                },
                new Account
                {
                    Username = "tony.alyazegi@gmail.com",
                    Password = "#8C&X7wkgen6F$B"
                },
                new Account
                {
                    Username = "patriiciia2502@outlook.com",
                    Password = "ayden2018"
                }
            };
        }

    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace SerializeJSON
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите Add,Get,exit");
            string data = Console.ReadLine().ToLower();
            switch (data)
            {
                case "add":
                    Console.WriteLine("Введите ID:");
                    int number = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите дату:");
                    Console.WriteLine("Формат даты dd/MM/yyyy:");
                    DateTime date = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Введите сумму:");
                    decimal dec = Convert.ToDecimal(Console.ReadLine());
                    Transaction transaction = new Transaction(number, date, dec);

                    var json = "file.json";
                    var received = File.ReadAllText(json);

                    if (String.IsNullOrEmpty(received))
                    {
                        List<Transaction> newObj = new();
                        newObj.Add(transaction);
                        File.WriteAllText("file.json", JsonConvert.SerializeObject(newObj));
                    }
                    else
                    {
                        var transactions = JsonConvert.DeserializeObject<List<Transaction>>(received);
                        transactions.Add(transaction);
                        File.WriteAllText("file.json", JsonConvert.SerializeObject(transactions));
                    }

                    break;

                case "get":
                    Console.WriteLine("Введите номер Id для чтения файла:");

                    using (StreamReader file = File.OpenText("file.json"))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        List<Transaction> forDeserialize = (List<Transaction>)serializer.Deserialize(file, typeof(List<Transaction>));

                        var one = Convert.ToInt32(Console.ReadLine());
                        foreach (var item in forDeserialize)
                        {
                            if (one == item.Id)
                            {
                                var jsonformat = JsonConvert.SerializeObject(item);
                                Console.WriteLine(jsonformat);
                            }
                        }
                    }
                    break;

                case "exit":
                    Console.WriteLine("Вы завершили выполнения программы");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
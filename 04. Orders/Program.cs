using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Dictionary<string, List<double>> output = new Dictionary<string, List<double>>();

            while (command != "buy")
            {
                string[] currentProduct = command.Split();
                string productName = currentProduct[0];
                double productPrice = double.Parse(currentProduct[1]);
                double quantity = double.Parse(currentProduct[2]);

                if (!output.ContainsKey(productName))
                {
                    List<double> priceAndQuantity = new List<double> { productPrice, quantity };
                    output.Add(productName, priceAndQuantity);
                }
                else
                {
                    output[productName][0] = productPrice;
                    output[productName][1] += quantity;
                }

                command = Console.ReadLine();
            }
            foreach (var item in output)
            {
                double totalPrice = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {totalPrice:F2}");
            }
        }
    }
}

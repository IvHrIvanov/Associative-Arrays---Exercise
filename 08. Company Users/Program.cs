using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(" -> ");

            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();

            while (input[0] != "End")
            {
                string company = input[0];
                string userId = input[1];

                if (!users.ContainsKey(company))
                {
                    users.Add(company, new List<string>());
                }
                if(!users[company].Contains(userId))
                {
                    users[company].Add(userId);
                }

                input = Console.ReadLine().Split(" -> ");
            }

            foreach (var currentCompany in users.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{currentCompany.Key}");
                foreach (var item in currentCompany.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }

        }
    }
}

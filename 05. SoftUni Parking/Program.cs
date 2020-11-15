using System;
using System.Collections.Generic;
using System.Text;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> register = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                StringBuilder message = new StringBuilder();

                string[] command = Console.ReadLine().Split(" ");

                string name = command[1];
                
                if (command[0] == "register")
                {
                    string license = command[2];

                    if (!register.ContainsKey(name))
                    {
                        register.Add(name, license);
                        message.AppendLine($"{name} registered {license} successfully");
                    }
                    else
                    {
                        message.AppendLine($"ERROR: already registered with plate number {register[name]}");
                    }
                }
                else if (command[0] == "unregister")
                {
                    if (register.ContainsKey(name))
                    {
                        message.AppendLine($"{name} unregistered successfully");
                        register.Remove(name);
                    }
                    else
                    {
                        message.AppendLine($"ERROR: user {name} not found");
                    }
                }
                Console.Write(message);
            }
            foreach (var item in register)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");

            }
        }
    }
}
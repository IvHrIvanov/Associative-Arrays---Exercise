using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary < string, List<double>> grades = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!grades.ContainsKey(name))
                {
                    grades[name] = new List<double>();
                }
                grades[name].Add(grade);
            }
            
            Console.WriteLine(string.Join($"{Environment.NewLine}", grades
               .Where(x => (x.Value.Sum() / x.Value.Count) >= 4.50)
               .OrderByDescending(x => x.Value.Sum() / x.Value.Count)
               .Select(x => $"{x.Key} -> {x.Value.Sum() / x.Value.Count():f2}")));

        }
    }
}
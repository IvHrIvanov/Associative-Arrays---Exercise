using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(" : ");

            Dictionary<string, List<string>> students = new Dictionary<string, List<string>>();

            while (input[0] != "end")
            {
                string course = input[0];

                string name = input[1];

                if (!students.ContainsKey(course))
                {
                    students.Add(course, new List<string>());
                }
                students[course].Add(name);

                input = Console.ReadLine().Split(" : ");
            }

            foreach (var currenCourse in students.OrderByDescending(x => x.Value.Count))
            {

                Console.WriteLine($"{currenCourse.Key}: {currenCourse.Value.Count}");
                foreach (var item in currenCourse.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
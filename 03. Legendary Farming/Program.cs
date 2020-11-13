using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            Dictionary<string, int> junk = new Dictionary<string, int>();

            keyMaterials["motes"] = 0;
            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;

            bool hasToBrak = false;
            while (true)
            {
                string[] input = Console.ReadLine()
                                        .ToLower()
                                        .Split(" ")
                                        .ToArray();

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string matterials = input[i + 1];

                    if (matterials == "shards" || matterials == "fragments" || matterials == "motes")
                    {
                        keyMaterials[matterials] += quantity;

                        if (keyMaterials[matterials] >= 250)
                        {
                            keyMaterials[matterials] -= 250;
                            if (matterials == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }
                            else if (matterials == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else if (matterials == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }
                            hasToBrak = true;
                            break;

                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(matterials))
                        {
                            junk.Add(matterials, 0);
                        }

                        junk[matterials] += quantity;
                    }
                }
                if (hasToBrak)
                {
                    break;
                }
            }

            Dictionary<string, int> filterMaterials = keyMaterials
                .OrderByDescending(v => v.Value)
                .ThenBy(k => k.Key)
                .ToDictionary(a => a.Key, a => a.Value);

            foreach (var item in filterMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junk.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extractor
{
    class Program
    {
        static void Main(string[] args)
        {

            string json = @"{
""id"": 192081,
""name"": ""Ironfur"",
""icon"": ""ability_druid_ironfur"",
""description"": ""Increases armor by 75% for 6 sec. Multiple uses of this ability may overlap."",
""powerCost"": ""45 Rage"",
""castTime"": ""Instant"",
""cooldown"": ""0.5 sec cooldown""
}";
            Spell s = JsonConvert.DeserializeObject<Spell>(json);
            Console.WriteLine(s.name.Trim());
            do
            {
                while (!Console.KeyAvailable)
                {
                    // Do something
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}

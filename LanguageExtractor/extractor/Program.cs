using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;

namespace extractor
{
    class Program
    {
        static string apikey = "apikey=ryksyb6993en4ptamrzan6yyvv28gzgt";


        static void Main(string[] args)
        {

            ApiLocales locales = new ApiLocales();
            List<Spell> spells = new List<Spell>();


            WebClient client = new WebClient() { Encoding = Encoding.UTF8 };

            //when doing this for real make this 300000
            for (int i = 192051; i < 192100; i++)
            {
                string downloadstring = "https://us.api.battle.net/wow/spell/";
                
                string locale = "locale=en_US";
                //int spellid = 192801;

                string compiledstring = $"{downloadstring}{i}?{apikey}&{locale}";

                // Download string.
                try
                {
                    string value = client.DownloadString(compiledstring);

                    //// Write values.
                    //Console.WriteLine("--- WebClient result ---");
                    //Console.WriteLine(value.Length);
                    //Console.WriteLine(value);

                    Spell tempSpell = JsonConvert.DeserializeObject<Spell>(value);
                    bool test = string.IsNullOrWhiteSpace(tempSpell.powerCost);
                    Console.WriteLine($"{tempSpell.id} has no Powercost {test.ToString()}");

                    if (isPlayerSpell(tempSpell))
                    {
                        spells.Add(tempSpell);
                    }
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    //do nothing with the spell.
                }
            }
            //process spells
            foreach (Spell p in spells)
            {
                Console.WriteLine($"{p.id} {p.name} {p.description}");

                foreach (ApiLocale l in locales.Info)
                {
                    string lstring = $"{l.Api}{p.id}?{apikey}&{l.Locale}";
                    string result = client.DownloadString(lstring);
                    Spell localspell = JsonConvert.DeserializeObject<Spell>(result);
                    Console.WriteLine($"{localspell.id} obtained from  {l.Locale}");
                    l.addSpell(localspell);
                }
            }
            pauseforkey();
        }

        private static void pauseforkey()
        {
            do
            {
                while (!Console.KeyAvailable)
                {
                    // Do something
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

        private static bool isPlayerSpell(Spell s)
        {
            bool result = false;
            Regex r = new Regex(".*?(artifact)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(s.icon);
            if (m.Success)
            {
                result = true;
            }
            else if (!(String.IsNullOrWhiteSpace(s.description))&& s.castTime != "Passive" && !(String.IsNullOrWhiteSpace(s.powerCost))){
                result = true;
            }

            return result;

        }

    }
}

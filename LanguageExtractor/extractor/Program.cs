using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;

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
            int z = 0; // used to throttle - need to do less that 36,000 per hour.
                       //when doing this for real make this 300000
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 250000; i++)
            {

                if (z > 35997)
                {
                    //wait for stopwatch to hit an hour
                    if (TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds).TotalHours >= 1)
                    {
                        z = 0;
                        watch.Restart();
                    }
                }
                else
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
                    ++z;
                }
            }
            //process spells
            foreach (Spell p in spells)
            {
                Console.WriteLine($"{p.id} {p.name} {p.description}");

                foreach (ApiLocale l in locales.Info)
                {
                    if (l.GameLocale != "enUS")
                    {
                        string lstring = $"{l.Api}{p.id}?{apikey}&{l.Locale}";
                        string result = client.DownloadString(lstring);
                        Spell localspell = JsonConvert.DeserializeObject<Spell>(result);
                        Console.WriteLine($"{localspell.id} obtained from  {l.Locale}");
                        l.addSpell(localspell);
                    } else
                    {
                        l.addSpellList(spells);
                    }
                }
            }

            //write files
            StreamWriter csv = File.CreateText("spellidlist.csv");
            foreach (ApiLocale l in locales.Info)
            {
                string forwardfilename = l.GameLocale + ".lua";
                string reversefilename = l.GameLocale + "HASH.lua";

                StreamWriter fw = File.CreateText(forwardfilename);
                StreamWriter rw = File.CreateText(reversefilename);

                if (l.GameLocale == "enUS") { 
                    csv.WriteLine("\"spellID\",\"Name\",\"Description\"");
                }

                fw.WriteLine("local GNOME, language = ...");
                rw.WriteLine("local GNOME, language = ...");
                fw.WriteLine("");
                rw.WriteLine("");
                fw.WriteLine("language[GSTRStaticKey][\"" + l.GameLocale + "\"] = {");
                rw.WriteLine("language[GSTRStaticHash][\"" + l.GameLocale + "\"] = {");

                foreach(Spell s in l.Spells)
                {
                    fw.WriteLine("	[" + s.id + "] = \"" + s.name + "\",");
                    rw.WriteLine("	[\"" + s.name + "\"] = " + s.id + ",");
                    if(l.GameLocale == "enUS")
                    {
                        csv.WriteLine($"{s.id},\"{s.name}\",\"{s.description}\"");
                    }
                }
                fw.WriteLine("}");
                rw.WriteLine("}");

                fw.Close();
                rw.Close();
            }
            csv.Close();



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


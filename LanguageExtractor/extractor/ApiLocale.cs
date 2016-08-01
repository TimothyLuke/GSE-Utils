using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extractor
{
    public class ApiLocale
    {
        public string Locale { get; set; }
        public string Api { get; set; }
        public string GameLocale { get; set; }
        public List<Spell> Spells { get; } = new List<Spell>();

        public ApiLocale (string locale, string api, string gamelocale)
        {
            Locale = locale;
            Api = api;
            GameLocale = gamelocale;
        }

        public void addSpell(Spell s)
        {
            Spells.Add(s);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extractor
{
    public class ApiLocales
    {
        public List<ApiLocale> Info { get; } = new List<ApiLocale>();

        public ApiLocales()
        {
            //Info.Add(new ApiLocale("locale=en_US", "https://us.api.battle.net/wow/spell/", "enUS"));
            Info.Add(new ApiLocale("locale=pt_BR", "https://us.api.battle.net/wow/spell/", "ptBR"));
            Info.Add(new ApiLocale("locale=es_MX", "https://us.api.battle.net/wow/spell/", "esMX"));

            Info.Add(new ApiLocale("locale=en_GB", "https://eu.api.battle.net/wow/spell/", "enGB"));
            Info.Add(new ApiLocale("locale=de_DE", "https://eu.api.battle.net/wow/spell/", "deDE"));
            Info.Add(new ApiLocale("locale=es_ES", "https://eu.api.battle.net/wow/spell/", "esES"));
            Info.Add(new ApiLocale("locale=fr_FR", "https://eu.api.battle.net/wow/spell/", "frFR"));
            Info.Add(new ApiLocale("locale=it_IT", "https://eu.api.battle.net/wow/spell/", "itIT"));
            Info.Add(new ApiLocale("locale=pl_PL", "https://eu.api.battle.net/wow/spell/", "plPL"));
            Info.Add(new ApiLocale("locale=pt_PT", "https://eu.api.battle.net/wow/spell/", "ptPT"));
            Info.Add(new ApiLocale("locale=ru_RU", "https://eu.api.battle.net/wow/spell/", "ruRU"));

            Info.Add(new ApiLocale("locale=ko_KR", "https://kr.api.battle.net/wow/spell/", "koKR"));
            Info.Add(new ApiLocale("locale=zh_TW", "https://tw.api.battle.net/wow/spell/", "zhTW"));


        }
    }
}

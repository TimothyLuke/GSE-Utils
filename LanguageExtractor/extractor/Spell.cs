using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extractor
{



    /// <summary>
    ///     {
    /// "id": 192081,
    /// "name": "Ironfur",
    /// "icon": "ability_druid_ironfur",
    /// "description": "Increases armor by 75% for 6 sec. Multiple uses of this ability may overlap.",
    /// "powerCost": "45 Rage",
    /// "castTime": "Instant",
    /// "cooldown": "0.5 sec cooldown"
    /// }
    /// </summary>
    public class Spell
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string description { get; set; }
        public string powerCost { get; set; }
        public string castTime { get; set; }
        public string cooldown { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace _5ECharacterCreator.Classes
{
    public class SpellList
    {
        private JArray SpellsList;

        public SpellList(JArray jarr)
        {
            SpellsList = jarr;
        }

        /// <summary>
        /// finds and creates a new spell object
        /// </summary>
        /// <param name="name">name of spell</param>
        /// <returns> null if not found</returns>
        public Spell CreateSpell(string name)
        {
            foreach (var item in SpellsList)
            {
                if ((string)item["name"] == name)
                {
                    return new Spell(item);
                }
            }
            return null;
        }
    }
}

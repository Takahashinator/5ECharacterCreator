using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using _5ECharacterCreator.Enums;

namespace _5ECharacterCreator
{
    public class Spell
    {
        public bool AlwaysPrepared = false;

        public string CastingTime { get; set; }
        public List<string> Classes { get; set; }
        public MatComponents Components { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Level { get; set; }
        public string Name { get; set; }
        public string Range { get; set; }
        public bool Ritual { get; set; }
        public string School { get; set; }
        public List<string> Tags { get; set; }
        public string Type { get; set; }

        public Spell(JToken job)
        {
            CastingTime = (string) job["casting_time"];
            Classes = new List<string>();
            foreach (var item in job["classes"])
            {
                Classes.Add((string) item);
            }
            Components = new MatComponents
            {
                Material = (bool) job["components"]["material"],
                Raw = (string) job["components"]["raw"],
                Somatic = (bool) job["components"]["somatic"],
                Verbal = (bool) job["components"]["verbal"]
            };
            Description = (string)job["description"];
            Duration = (string)job["duration"];
            Level = (string)job["level"];
            Name = (string)job["name"];
            Range = (string)job["range"];
            Ritual = (bool)job["ritual"];
            School = (string)job["school"];
            Tags = new List<string>();
            foreach (var item in job["tags"])
            {
                Tags.Add((string)item);
            }
            Type = (string)job["type"];
        }
        /*
             {
        "casting_time": "1 action",
        "classes": [
            "sorcerer",
            "wizard"
        ],
        "components": {
            "material": false,
            "raw": "V, S",
            "somatic": true,
            "verbal": true
        },
        "description": "You hurl a bubble of acid. Choose one creature within range, or choose two creatures within range that are within 5 feet of each other. A target must succeed on a Dexterity saving throw or take 1d6 acid damage.\n\nThis spell's damage increases by 1d6 when you reach 5th level (2d6), 11th level (3d6), and 17th level (4d6).",
        "duration": "Instantaneous",
        "level": "cantrip",
        "name": "Acid Splash",
        "range": "60 feet",
        "ritual": false,
        "school": "conjuration",
        "tags": [
            "sorcerer",
            "wizard",
            "cantrip"
        ],
        "type": "Conjuration cantrip"
    },
             */

        public class MatComponents
        {
            public bool Material { get; set; }
            public string Raw { get; set; }
            public bool Somatic { get; set; }
            public bool Verbal { get; set; }
        }
    }
}
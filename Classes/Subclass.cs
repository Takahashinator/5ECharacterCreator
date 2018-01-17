using _5ECharacterCreator.Enums;

namespace _5ECharacterCreator
{
    public class Subclass
    {
        public int Level { get; set; }
        public string Name { get; }
        public Subclass(SubclassEnum item)
        {
            switch (item)
            {
                // Barbarian Primal Paths
                case SubclassEnum.Berserker:
                    Name = "Berserker";
                    break;
                case SubclassEnum.TotemWarrior:
                    Name = "Totem Warrior";
                    break;
                // Bardic Colleges
                case SubclassEnum.Lore:
                    Name = "College of Lore";
                    break;
                case SubclassEnum.Valor:
                    Name = "College of Valor";
                    break;
                // Cleric Divine Domains
                case SubclassEnum.Knowledge:
                    Name = "Knowledge";
                    break;
                case SubclassEnum.Life:
                    Name = "Life";
                    break;
                case SubclassEnum.Light:
                    Name = "Light";
                    break;
                case SubclassEnum.Nature:
                    Name = "Nature";
                    break;
                case SubclassEnum.Tempest:
                    Name = "Tempest";
                    break;
                case SubclassEnum.Trickery:
                    Name = "Trickery";
                    break;
                case SubclassEnum.War:
                    Name = "War";
                    break;
                // Druid Circles
                case SubclassEnum.Land:
                    Name = "Circle of the Land";
                    break;
                case SubclassEnum.Moon:
                    Name = "Circle of the Moon";
                    break;
                // Fighter Archetypes
                case SubclassEnum.Champion:
                    Name = "Champion";
                    break;
                case SubclassEnum.BattleMaster:
                    Name = "Battle Master";
                    break;
                case SubclassEnum.EldritchKnight:
                    Name = "Eldritch Knight";
                    break;
                // Monk Monastic Traditions
                case SubclassEnum.OpenHand:
                    Name = "Way of the Open Hand";
                    break;
                case SubclassEnum.Shadow:
                    Name = "Way of the Shadow";
                    break;
                case SubclassEnum.FourElements:
                    Name = "Way of the Four Elements";
                    break;
                // Paladin Sacred Oaths
                case SubclassEnum.Devotion:
                    Name = "Oath of Devotion";
                    break;
                case SubclassEnum.Ancients:
                    Name = "Oath of Ancients";
                    break;
                case SubclassEnum.Vengeance:
                    Name = "Oath of Vengeance";
                    break;
                // Ranger Archetypes
                case SubclassEnum.Hunter:
                    Name = "Hunder";
                    break;
                case SubclassEnum.BeastMaster:
                    Name = "Beast Master";
                    break;
                // Rogue Archetypes
                case SubclassEnum.Thief:
                    Name = "Thief";
                    break;
                case SubclassEnum.Assassin:
                    Name = "Assassin";
                    break;
                case SubclassEnum.ArcaneTrickster:
                    Name = "Arcane Trickster";
                    break;
                // Sorcerer Origins
                case SubclassEnum.DraconicBloodline:
                    Name = "Draconic Bloodline";
                    break;
                case SubclassEnum.WildMagic:
                    Name = "Wild Magic";
                    break;
                // Warlock Patrons
                case SubclassEnum.Archfey:
                    Name = "Arch Fey";
                    break;
                case SubclassEnum.Fiend:
                    Name = "Fiend";
                    break;
                case SubclassEnum.GreatOldOne:
                    Name = "Great Old One";
                    break;
                // Wizard Arcane Traditions
                case SubclassEnum.Abjuration:
                    Name = "Abjuration";
                    break;
                case SubclassEnum.Conjuration:
                    Name = "Conjuration";
                    break;
                case SubclassEnum.Enchantment:
                    Name = "Enchantment";
                    break;
                case SubclassEnum.Divination:
                    Name = "Divination";
                    break;
                case SubclassEnum.Evocation:
                    Name = "Evocation";
                    break;
                case SubclassEnum.Illusion:
                    Name = "Illusion";
                    break;
                case SubclassEnum.Necromancy:
                    Name = "Necromancy";
                    break;
                case SubclassEnum.Transmuation:
                    Name = "Transmutation";
                    break;
            }
        }
        
        public override string ToString()
        {
            return Name;
        }
    }
}
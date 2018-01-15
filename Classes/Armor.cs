using _5ECharacterCreator.Enums;

namespace _5ECharacterCreator
{
    public class Armor : IItem
    {
        public new readonly string Name;
        public readonly int AC;
        public new readonly int Weight;
        public new readonly Proficiency Proficiency;
        public readonly bool disadvantageStealth;
        public readonly ArmorType Type;
        public new readonly bool MagicItem;
        public new readonly string Description;

        public Armor(ArmorType typeEnum)
        {
            Type = typeEnum;
            switch (typeEnum)
            {
                case ArmorType.Padded:
                    Name = "Padded";
                    AC = 11;
                    disadvantageStealth = true;
                    Proficiency = Proficiency.LightArmor;
                    Weight = 8;
                    MagicItem = false;
                    break;

                case ArmorType.Leather:
                    Name = "Leather";
                    AC = 11;
                    disadvantageStealth = false;
                    Proficiency = Proficiency.LightArmor;
                    Weight = 10;
                    MagicItem = false;
                    break;

                case ArmorType.StuddedLeather:
                    Name = "Studded Leather";
                    AC = 12;
                    disadvantageStealth = false;
                    Proficiency = Proficiency.LightArmor;
                    Weight = 13;
                    MagicItem = false;
                    break;

                case ArmorType.Hide:
                    Name = "Hide";
                    AC = 12;
                    disadvantageStealth = false;
                    Proficiency = Proficiency.MediumArmor;
                    Weight = 12;
                    MagicItem = false;
                    break;

                case ArmorType.ChainShirt:
                    Name = "Chain Shirt";
                    AC = 13;
                    disadvantageStealth = false;
                    Proficiency = Proficiency.MediumArmor;
                    Weight = 20;
                    MagicItem = false;
                    break;

                case ArmorType.ScaleMail:
                    Name = "Scale Mail";
                    AC = 14;
                    disadvantageStealth = true;
                    Proficiency = Proficiency.MediumArmor;
                    Weight = 45;
                    MagicItem = false;
                    break;

                case ArmorType.Breastplate:
                    Name = "Breastplate";
                    AC = 14;
                    disadvantageStealth = false;
                    Proficiency = Proficiency.MediumArmor;
                    Weight = 20;
                    MagicItem = false;
                    break;

                case ArmorType.HalfPlate:
                    Name = "Half Plate";
                    AC = 15;
                    disadvantageStealth = true;
                    Proficiency = Proficiency.MediumArmor;
                    Weight = 40;
                    MagicItem = false;
                    break;

                case ArmorType.RingMail:
                    Name = "Ring Mail";
                    AC = 14;
                    disadvantageStealth = true;
                    Proficiency = Proficiency.HeavyArmor;
                    Weight = 40;
                    MagicItem = false;
                    break;

                case ArmorType.ChainMail:
                    Name = "Chain Mail";
                    AC = 16;
                    disadvantageStealth = true;
                    Proficiency = Proficiency.HeavyArmor;
                    Weight = 55;
                    MagicItem = false;
                    break;

                case ArmorType.Splint:
                    Name = "Splint";
                    AC = 17;
                    disadvantageStealth = true;
                    Proficiency = Proficiency.HeavyArmor;
                    Weight = 60;
                    MagicItem = false;
                    break;

                case ArmorType.Plate:
                    Name = "Plate";
                    AC = 18;
                    disadvantageStealth = true;
                    Proficiency = Proficiency.HeavyArmor;
                    Weight = 65;
                    MagicItem = false;
                    break;

                case ArmorType.Unarmored:
                default:
                    Name = "Unarmored";
                    AC = 10;
                    disadvantageStealth = false;
                    Proficiency = Proficiency.None;
                    Weight = 0;
                    MagicItem = false;
                    break;
            }
        }
    }
}
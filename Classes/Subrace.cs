using System.Collections.Generic;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using _5ECharacterCreator.Enums;
using _5ECharacterCreator.HelperStructs;

namespace _5ECharacterCreator
{
    public class Subrace
    {
        public string Name { get; }
        public readonly SubraceEnum Type;
        public readonly string SubraceDescription;
        public readonly Stats StatIncrease;
        private readonly List<Trait> _traits;

        public Subrace(SubraceEnum type)
        {
            _traits = new List<Trait>();
            Type = type;
            switch (type)
            {
                case SubraceEnum.Black:
                    Name = "Black Dragon";
                    SubraceDescription =
                        "As offspring of a black dragon, your scales shine with a glossy black sheen, as dark as night.";
                    _traits.Add(new Trait("Damage Resistance", "You have resistance to acid damage due to your draconic ancestry", "Resistance to acid damage.", true));
                    _traits.Add(new Trait("Breath Weapon", "Your breath weapon does acid damage in a 5x30 ft line and requires a dexterity saving throw", "5x30 ft line, dex save, acid damage", false));
                    break;
                case SubraceEnum.Blue:
                    Name = "Blue Dragon";
                    SubraceDescription =
                        "As offspring of a blue dragon, your scales have a beautiful bright blue hue in color similar to the midday sky.";
                    _traits.Add(new Trait("Damage Resistance", "You have resistance to lightning damage due to your draconic ancestry", "Resistance to lightning damage.", true));
                    _traits.Add(new Trait("Breath Weapon", "Your breath weapon does lightning damage in a 5x30 ft line and requires a dexterity saving throw", "5x30 ft line, dex save, lightning damage", false));
                    break;
                case SubraceEnum.Brass:
                    Name = "Brass Dragon";
                    SubraceDescription =
                        "As offspring of a brass dragon, your scales resemble polished brass, shining with a warm, burnished luster.";
                    _traits.Add(new Trait("Damage Resistance", "You have resistance to fire damage due to your draconic ancestry", "Resistance to fire damage.", true));
                    _traits.Add(new Trait("Breath Weapon", "Your breath weapon does fire damage in a 5x30 ft line and requires a dexterity saving throw", "5x30 ft line, dex save, fire damage", false));
                    break;
                case SubraceEnum.Bronze:
                    Name = "Bronze Dragon";
                    SubraceDescription =
                        "As offspring of a bronze dragon, your scales shine with a metalic brown tone typical of your draconic heritage.";
                    _traits.Add(new Trait("Damage Resistance", "You have resistance to lightning damage due to your draconic ancestry", "Resistance to lightning damage.", true));
                    _traits.Add(new Trait("Breath Weapon", "Your breath weapon does lightning damage in a 5x30 ft line and requires a dexterity saving throw", "5x30 ft line, dex save, lightning damage", false));
                    break;
                case SubraceEnum.Copper:
                    Name = "Copper Dragon";
                    SubraceDescription =
                        "As offspring of a copper dragon, your scales are a brilliant copper color with a slight green tint.";
                    _traits.Add(new Trait("Damage Resistance", "You have resistance to acid damage due to your draconic ancestry", "Resistance to acid damage", true));
                    _traits.Add(new Trait("Breath Weapon", "Your breath weapon does acid damage in a 5x30 ft line and requires a dexterity saving throw", "5x30 ft line, dex save, acid damage", false));
                    break;
                case SubraceEnum.Silver:
                    Name = "Silver Dragon";
                    SubraceDescription =
                        "As offspring of a silver dragon, your scales shine with a brilliant metallic sheen, sparkling beautifully in the sunshine.";
                    _traits.Add(new Trait("Damage Resistance", "You have resistance to cold damage due to your draconic ancestry", "Resistance to cold damage.", true));
                    _traits.Add(new Trait("Breath Weapon", "Your breath weapon does cold damage in a 15 ft cone and requires a constitution saving throw", "15 ft cone, con save, cold damage", false));
                    break;
                case SubraceEnum.White:
                    Name = "White Dragon";
                    SubraceDescription =
                        "As offspring of a white dragon, your scales resemble the snowy landscapes from which your dragon ancesters originally hailed.";
                    _traits.Add(new Trait("Damage Resistance", "You have resistance to cold damage due to your draconic ancestry", "Resistance to cold damage.", true));
                    _traits.Add(new Trait("Breath Weapon", "Your breath weapon does cold damage in a 15 ft cone and requires a constitution saving throw", "15 ft cone, con save, cold damage", false));
                    break;
                case SubraceEnum.Green:
                    Name = "Greed Dragon";
                    SubraceDescription =
                        "As offspring of a green dragon, your scales are a rich, hearty green, fitted to the forest regions from which your dragon kin hail.";
                    _traits.Add(new Trait("Damage Resistance", "You have resistance to poision damage due to your draconic ancestry", "Resistance to poision damage.", true));
                    _traits.Add(new Trait("Breath Weapon", "Your breath weapon does poision damage in a 15 ft cone and requires a constitution saving throw", "15 ft cone, dex save, poision damage", false));
                    break;
                case SubraceEnum.Gold:
                    Name = "Gold Dragon";
                    SubraceDescription =
                        "As offspring of a gold dragon, your scales shine with a beautiful, deep golden color.";
                    _traits.Add(new Trait("Damage Resistance", "You have resistance to fire damage due to your draconic ancestry", "Resistance to fire damage.", true));
                    _traits.Add(new Trait("Breath Weapon", "Your breath weapon does fire damage in a 15 ft cone and requires a dexterity saving throw", "15 ft cone, dex save, fire damage", false));
                    break;
                case SubraceEnum.Red:
                    Name = "Red Dragon";
                    SubraceDescription =
                        "As offspring of a red dragon, your scales burn with an angry red, indicative of the fiery breath you are capable of producing.";
                    _traits.Add(new Trait("Damage Resistance", "You have resistance to fire damage due to your draconic ancestry", "Resistance to fire damage.", true));
                    _traits.Add(new Trait("Breath Weapon", "Your breath weapon does fire damage in a 15 ft cone and requires a dexterity saving throw", "15 ft cone, dex save, fire damage", false));
                    break;
                case SubraceEnum.Lightfoot:
                    Name = "Lightfoot";
                    StatIncrease = new Stats(10, 10, 10, 10, 10, 12);
                    SubraceDescription = StringResources.SR.GetString("LightfootDes");
                    _traits.Add(
                        new Trait("Ability Score Increase",
                            "Your Charisma score increases by 1",
                            "", false));
                    _traits.Add(
                        new Trait("Naturally Stealthy",
                            StringResources.SR.GetString("NaturallyStealthy"),
                            StringResources.SR.GetString("NaturallyStealthy"), true));
                    break;
                case SubraceEnum.Stout:
                    Name = "Stout";
                    StatIncrease = new Stats(10, 10, 12, 10, 10, 10);
                    SubraceDescription = StringResources.SR.GetString("StoutDes");
                    _traits.Add(
                        new Trait("Ability Score Increase",
                            "Your Constitution score increases by 1",
                            "", false));
                    _traits.Add(
                        new Trait("Stout Resilience",
                            StringResources.SR.GetString("StoutResilienceDes"),
                            StringResources.SR.GetString("StoutResilienceAbbrev"), true));
                    break;
                case SubraceEnum.HillDwarf:
                    Name = "Hill Dwarf";
                    StatIncrease = new Stats(10, 10, 10, 10, 12, 10);
                    SubraceDescription = StringResources.SR.GetString("HillDwarfDes");
                    _traits.Add(
                        new Trait("Ability Score Increase",
                            "Your Wisdom score increases by 1",
                            "", false));
                    _traits.Add(
                        new Trait("Dwarven Toughness",
                        StringResources.SR.GetString("DwarvenToughness"),
                        StringResources.SR.GetString("DwarvenToughness"),false));
                    break;
                case SubraceEnum.MountainDwarf:
                    Name = "Mountain Dwarf";
                    SubraceDescription = StringResources.SR.GetString("MountainDwarfDes");
                    StatIncrease = new Stats(14, 10, 10, 10, 10, 10);
                    _traits.Add(
                        new Trait("Ability Score Increase",
                            "Your Strength score increases by 2",
                            "", false));
                    _traits.Add(
                        new Trait("Dwarven Armor Training",
                            StringResources.SR.GetString("DwarvenArmorTraining"),
                            StringResources.SR.GetString("DwarvenArmorTraining"), false));
                    break;
                case SubraceEnum.RockGnome:
                    Name = "Rock Gnome";
                    StatIncrease = new Stats(10,10,12,10,10,10);
                    SubraceDescription = StringResources.SR.GetString("RockGnomeDes");
                    _traits.AddRange(new[]
                    {
                        new Trait("Ability Score Increase",
                            "Your Constitution score increase by 1",
                            "", false),
                        new Trait("Artificers Lore",
                            StringResources.SR.GetString("ArtificersLoreDes"),
                            StringResources.SR.GetString("ArtificersLoreAbbrev"),true),
                        new Trait("Tinker",
                            StringResources.SR.GetString("TinkerDes"),
                            StringResources.SR.GetString("TinkerAbbrev"), true),
                    });
                    break;
                case SubraceEnum.ForestGnome:
                    Name = "Forest Gnome";
                    StatIncrease = new Stats(10, 12, 10, 10, 10, 10);
                    SubraceDescription = StringResources.SR.GetString("ForestGnomeDes");
                    _traits.AddRange(new[]
                    {
                        new Trait("Ability Score Increase",
                            "Your Dexterity score increase by 1",
                            "", false),
                        new Trait("Natural Illusionist",
                            StringResources.SR.GetString("NaturalIllusionist"),
                            StringResources.SR.GetString("NaturalIllusionist"),false),
                        new Trait("Speak with Small Beasts",
                            StringResources.SR.GetString("SpeakWithSmallBeastsDes"),
                            StringResources.SR.GetString("SpeakWithSmallBeastsAbbrev"), true),
                    });
                    break;
                case SubraceEnum.WoodElf:
                    Name = "Wood Elf";
                    StatIncrease = new Stats(10, 10, 10, 10, 12, 10);
                    SubraceDescription = StringResources.SR.GetString("WoodElfDes");
                    _traits.AddRange(new[]
                    {
                        new Trait("Ability Score Increase",
                            "Your Wisdom score increase by 1",
                            "", false),
                        new Trait("Elf Weapon Training",
                            StringResources.SR.GetString("ElfWeaponTraining"),
                            StringResources.SR.GetString("ElfWeaponTraining"),false),
                        new Trait("Fleet of Foot",
                            StringResources.SR.GetString("FleetOfFoot"),
                            StringResources.SR.GetString("FleetOfFoot"), false),
                        new Trait("Mask of the Wild",
                            StringResources.SR.GetString("MaskOfTheWildDes"),
                            StringResources.SR.GetString("MaskOfTheWildAbbrev"), true),
                    });
                    break;
                case SubraceEnum.DarkElf:
                    Name = "Dark Elf";
                    StatIncrease = new Stats(10, 10, 10, 10, 10, 12);
                    SubraceDescription = StringResources.SR.GetString("DarkElfDes");
                    _traits.AddRange(new[]
                    {
                        new Trait("Ability Score Increase",
                            "Your Charisma score increase by 1",
                            "", false),
                        new Trait("Drow Weapon Training",
                            StringResources.SR.GetString("DrowWeaponTraining"),
                            StringResources.SR.GetString("DrowWeaponTraining"),false),
                        new Trait("Superior Darkvision",
                            StringResources.SR.GetString("SuperiorDarkvision"),
                            StringResources.SR.GetString("SuperiorDarkvision"), true),
                        new Trait("Sunlight Sensitivity",
                            StringResources.SR.GetString("SunlightSensitivityDes"),
                            StringResources.SR.GetString("SunlightSensitivityAbbrev"), true),
                        new Trait("Drow Magic",
                            StringResources.SR.GetString("DrowMagicDes"),
                            StringResources.SR.GetString("DrowMagicAbbrev"), true),
                    });
                    break;
                case SubraceEnum.HighElf:
                    Name = "High Elf";
                    StatIncrease = new Stats(10, 10, 10, 12, 10, 10);
                    SubraceDescription = StringResources.SR.GetString("HighElfDes");
                    _traits.AddRange(new[]
                    {
                        new Trait("Ability Score Increase",
                            "Your Intelligence score increase by 1",
                            "", false),
                        new Trait("Elf Weapon Training",
                            StringResources.SR.GetString("ElfWeaponTraining"),
                            StringResources.SR.GetString("ElfWeaponTraining"),false),
                        new Trait("Extra Cantrip",
                            StringResources.SR.GetString("ExtraCantripHighElf"),
                            StringResources.SR.GetString("ExtraCantripHighElf"), false),
                        new Trait("Extra Language",
                            StringResources.SR.GetString("ExtraLanguage"),
                            StringResources.SR.GetString("ExtraLanguage"), false),
                    });
                    break;
                case SubraceEnum.None:
                    Name = "";
                    break;


            }
            
        }

        public string GetSubraceHeader()
        {
            return SubraceDescription;
        }

        public void GetSubRaceDetails(StackPanel subraceStackPanel)
        {
            // Traits
            foreach (var trait in _traits)
            {
                StackPanel sp = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    Margin = new Thickness(0, 0, 0, 15),
                };
                sp.Children.Add(new TextBlock
                {
                    FontSize = 20,
                    FontWeight = FontWeights.Bold,
                    Text = trait.Header + ": ",
                });
                sp.Children.Add(new TextBlock
                {
                    FontSize = 20,
                    Text = trait.FullDescription,
                    MaxWidth = 400,
                    TextWrapping = TextWrapping.Wrap,
                });
                subraceStackPanel.Children.Add(sp);
            }
        }
    }
}
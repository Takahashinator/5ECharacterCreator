using System;
using System.Collections.Generic;
using _5ECharacterCreator.Enums;
using _5ECharacterCreator.HelperStructs;
using Windows.ApplicationModel.Resources;
using Windows.ApplicationModel.Resources.Core;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _5ECharacterCreator
{
    public class Race
    {
        public string Name { get; }
        private int _level;
        public readonly RaceEnum TypeEnum;
        private SubraceEnum _subrace;
        public SizeEnum Size;
        public string AvgHeight;
        public string AvgWeight;
        private readonly List<SubraceEnum> _allowedSubraces = new List<SubraceEnum>();
        public readonly int Speed;
        public Stats statIncrease;
        public readonly List<Proficiency> ExtraProficiencies = new List<Proficiency>();
        public readonly List<LanguageEnum> RacialLanguages = new List<LanguageEnum>();
        private List<Trait> _traits;
        // TODO: figure out "pick yourself" options. These should show up on the relevant screen

        public Race(RaceEnum race)
        {
            //_level = lvl;
            TypeEnum = race;
            RacialLanguages.Add(LanguageEnum.Common);
            _traits=new List<Trait>();
            switch (race)
            {
                case RaceEnum.Dragonborn:
                    Name = "Dragonborn";
                    _allowedSubraces.AddRange(new[]
                    {
                        SubraceEnum.Black, SubraceEnum.Blue, SubraceEnum.Brass, SubraceEnum.Bronze,
                        SubraceEnum.Copper, SubraceEnum.Gold, SubraceEnum.Green, SubraceEnum.Red,
                        SubraceEnum.Silver, SubraceEnum.White
                    });
                    Speed = 30;
                    statIncrease = new Stats(14, 10, 10, 10, 10, 12);
                    RacialLanguages.Add(LanguageEnum.Draconic);
                    Size = SizeEnum.Medium;
                    AvgHeight = "7 ft.";
                    AvgWeight = "250 lb.";
                    _traits.AddRange(new []
                    {
                        new Trait("Breath Weapon",
                            StringResources.SR.GetString("BreathWeaponGeneral"),
                            StringResources.SR.GetString("BreathWeaponAbbrev"),false),
                        new Trait("Damage Resistance",
                            StringResources.SR.GetString("DamageResistanceDragon"),
                            StringResources.SR.GetString("DamageResistanceAbbrev"),false),
                    });
                    break;
                case RaceEnum.Dwarf:
                    Name = "Dwarf";
                    _allowedSubraces.AddRange(new []
                    {
                        SubraceEnum.HillDwarf,
                        SubraceEnum.MountainDwarf,
                    });
                    Size = SizeEnum.Medium;
                    AvgHeight = "4 - 5 ft.";
                    AvgWeight = "190 lb.";
                    Speed = 25;
                    statIncrease = new Stats(10,10,14,10,10,10);
                    RacialLanguages.Add(LanguageEnum.Dwarvish);
                    ExtraProficiencies.AddRange(new []
                    {
                        Proficiency.Battleaxe, Proficiency.Handaxe, Proficiency.LightHammer, Proficiency.Warhammer,
                    });
                    _traits.AddRange(new []
                    {
                        new Trait("Darkvision", StringResources.SR.GetString("DarkvisionDw"),StringResources.SR.GetString("DarkvisionAbbrev"),true),
                        new Trait("Dwarven Resilience", StringResources.SR.GetString("DwarvenResilienceDes"), StringResources.SR.GetString("DwarvenResilienceAbbrev"),true),
                        new Trait("Stonecutting", StringResources.SR.GetString("StonecuttingDes"), StringResources.SR.GetString("StonecuttingAbbrev"),true),
                        new Trait("Dwarven Combat Training", StringResources.SR.GetString("DCT"), StringResources.SR.GetString("DCT"),false),
                        new Trait("Tool Proficiency", StringResources.SR.GetString("ToolProficiency"), StringResources.SR.GetString("ToolProficiency"),false),
                    });
                    break;
                case RaceEnum.Elf:
                    Name = "Elf";
                    _allowedSubraces.AddRange(new []
                    {
                        SubraceEnum.HighElf,
                        SubraceEnum.WoodElf,
                        SubraceEnum.DarkElf,
                    });
                    Size = SizeEnum.Medium;
                    AvgHeight = "5 - 6 ft.";
                    AvgWeight = "90 lb.";
                    Speed = 30;
                    statIncrease = new Stats(10,14,10,10,10,10);
                    RacialLanguages.Add(LanguageEnum.Elvish);
                    ExtraProficiencies.Add(Proficiency.Perception);
                    _traits.AddRange(new[]
                    {
                        new Trait("Darkvision", StringResources.SR.GetString("DarkvisionElf"),StringResources.SR.GetString("DarkvisionAbbrev"),true),
                        new Trait("Fey Ancestry", StringResources.SR.GetString("FeyAncestryDes"), StringResources.SR.GetString("FeyAncestryAbbrev"),true),
                        new Trait("Trance", StringResources.SR.GetString("TranceDes"), StringResources.SR.GetString("TranceAbbrev"),true),
                        new Trait("Keen Senses", StringResources.SR.GetString("KeenSenses"), StringResources.SR.GetString("KeenSenses"),false),
                    });
                    break;
                case RaceEnum.Gnome:
                    Name = "Gnome";
                    _allowedSubraces.AddRange(new[]
                    {
                        SubraceEnum.RockGnome,
                        SubraceEnum.ForestGnome,
                    });
                    Speed = 25;
                    Size = SizeEnum.Small;
                    AvgHeight = "3 - 4 ft.'";
                    AvgWeight = "40 lb.";
                    statIncrease = new Stats(10,10,10,14,10,10);
                    RacialLanguages.Add(LanguageEnum.Gnomish);
                    _traits.AddRange(new[]
                    {
                        new Trait("Darkvision", StringResources.SR.GetString("DarkvisionDw"),StringResources.SR.GetString("DarkvisionAbbrev"),true),
                        new Trait("Gnome Cunning", StringResources.SR.GetString("GnomeCunning"), StringResources.SR.GetString("GnomeCunning"),true),
                    });
                    break;
                case RaceEnum.HalfElf:
                    Name = "Half-Elf";
                    _allowedSubraces.Add(SubraceEnum.None);
                    Speed = 30;
                    Size = SizeEnum.Medium;
                    AvgHeight = "5 - 6 feet'";
                    AvgWeight = "120 lb.";
                    statIncrease = new Stats(10,10,10,10,10,14);
                    RacialLanguages.Add(LanguageEnum.Elvish);
                    _traits.AddRange(new []
                    {
                        new Trait("Fey Ancestry", StringResources.SR.GetString("FeyAncestryDes"), StringResources.SR.GetString("FeyAncestryAbbrev"),true),
                        new Trait("Darkvision", StringResources.SR.GetString("DarkvisionHalfElf"),StringResources.SR.GetString("DarkvisionAbbrev"),true),
                        new Trait("Skill Versatility", StringResources.SR.GetString("SkillVersatility"),StringResources.SR.GetString("SkillVersatility"),false),
                    });
                    break;
                case RaceEnum.HalfOrc:
                    Name = "Half-Orc";
                    _allowedSubraces.Add(SubraceEnum.None);
                    Speed = 30;
                    Size = SizeEnum.Medium;
                    AvgHeight = "6 - 7 ft.";
                    AvgWeight = "170 lb.";
                    statIncrease = new Stats(14,10,12,10,10,10);
                    RacialLanguages.Add(LanguageEnum.Orc);
                    _traits.AddRange(new[]
                    {
                        new Trait("Relentless Endurance", StringResources.SR.GetString("RelentlessEnduranceDes"), StringResources.SR.GetString("RelentlessEnduranceAbbrev"),true),
                        new Trait("Savage Attacks", StringResources.SR.GetString("SavageAttacksDes"), StringResources.SR.GetString("SavageAttacksAbbrev"),true),
                        new Trait("Darkvision", StringResources.SR.GetString("DarkvisionOrc"),StringResources.SR.GetString("DarkvisionAbbrev"),true),
                        new Trait("Menacing", StringResources.SR.GetString("Menacing"),StringResources.SR.GetString("Menacing"),false),
                    });
                    break;
                case RaceEnum.Tiefling:
                    Name = "Tiefling";
                    _allowedSubraces.Add(SubraceEnum.None);
                    Speed = 30;
                    Size = SizeEnum.Medium;
                    AvgHeight = "5 - 6 ft.";
                    AvgWeight = "150 lb.";
                    statIncrease = new Stats(10,10,10,12,10,14);
                    RacialLanguages.Add(LanguageEnum.Infernal);
                    _traits.AddRange(new[]
                    {
                        new Trait("Infernal Legacy", StringResources.SR.GetString("InfernalLegacyDes"), StringResources.SR.GetString("InfernalLegacyAbbrev"),true),
                        new Trait("Hellish Resistance", StringResources.SR.GetString("HellishResistance"), StringResources.SR.GetString("HellishResistance"),true),
                        new Trait("Darkvision", StringResources.SR.GetString("DarkvisionTief"),StringResources.SR.GetString("DarkvisionAbbrev"),true),
                    });
                    break;
                case RaceEnum.Human:
                    Name = "Human";
                    _allowedSubraces.Add(SubraceEnum.None);
                    Speed = 30;
                    Size = SizeEnum.Medium;
                    AvgHeight = "5 - 6 ft.";
                    AvgWeight = "150 lb.";
                    statIncrease = new Stats(12,12,12,12,12,12);
                    break;
                case RaceEnum.Halfling:
                    Name = "Halfling";
                    _allowedSubraces.Add(SubraceEnum.Lightfoot);
                    _allowedSubraces.Add(SubraceEnum.Stout);
                    Speed = 25;
                    Size = SizeEnum.Small;
                    AvgHeight = "3 ft";
                    AvgWeight = "50 lb.";
                    statIncrease = new Stats(10,14,10,10,10,10);
                    RacialLanguages.Add(LanguageEnum.Halfling);
                    _traits.AddRange(new[]
                    {
                        new Trait("Lucky", StringResources.SR.GetString("LuckyDes"), StringResources.SR.GetString("LuckyAbbrev"),true),
                        new Trait("Brave", StringResources.SR.GetString("Brave"), StringResources.SR.GetString("Brave"),true),
                        new Trait("Halfling Nimblness", StringResources.SR.GetString("HalflingNimbleness"),StringResources.SR.GetString("HalflingNimbleness"),true),
                    });
                    break;

            }
        }

        public List<SubraceEnum> GetAllowedSubraces()
        {
            return _allowedSubraces;
        }

        public SubraceEnum GetSubrace()
        {
            return _subrace;
        }

        public void AssignSubrace(SubraceEnum s, Stats stats, int profBonus)
        {
            if (_allowedSubraces.Contains(s) && _subrace != s)
            {
                _subrace = s;
                UpdateTraits(stats, profBonus);
            }
            else
            {
                throw new AssignmentException("Subrace is not allowed for the given race type");
            }
        }

        public void LevelTo(int level, Stats stats, int profBonus)
        {
            _level = level;
            // update any traits ect that change with levels (only dragonborn that I know of...)
            if (TypeEnum == RaceEnum.Dragonborn)
            {
                UpdateTraits(stats, profBonus);
            }
        }

        private void UpdateTraits(Stats stats, int profBonus)
        {
            _traits = new List<Trait>();
            switch (TypeEnum)
            {
                case RaceEnum.Dragonborn:
                    _traits = new List<Trait>();
                    // Breath weapon changes depending on subclass and level
                    if (_subrace.Equals(SubraceEnum.None))
                        break;

                    string aoe = "";
                    string DC = (8 + stats.ConMod + profBonus).ToString();
                    string damageType = "";
                    string damage = "2d6";
                    if (_level >= 6 && _level < 11)
                        damage = "3d6";
                    else if (_level >= 11 && _level < 16)
                        damage = "4d6";
                    else if (_level >= 16)
                        damage = "5d6";

                    switch (_subrace)
                    {
                        case SubraceEnum.Silver:
                        case SubraceEnum.White:
                            aoe = "15ft. cone (Con. save)";
                            damageType = "Cold";
                            break;
                        case SubraceEnum.Blue:
                        case SubraceEnum.Bronze:
                            aoe = "5x30ft. line (Dex. save)";
                            damageType = "Lightning";
                            break;
                        case SubraceEnum.Black:
                        case SubraceEnum.Copper:
                            aoe = "5x30ft. line (Dex. save)";
                            damageType = "Acid";
                            break;
                        case SubraceEnum.Red:
                        case SubraceEnum.Gold:
                            aoe = "15ft. cone (Dex. save)";
                            damageType = "Fire";
                            break;
                        case SubraceEnum.Brass:
                            aoe = "5x30ft. line (Dex. save";
                            damageType = "Fire";
                            break;
                        case SubraceEnum.Green:
                            aoe = "15ft. cone (Con. save)";
                            damageType = "Poison";
                            break;
                    }
                    //_traits.AddRange(new[]
                    //{
                    //    new Trait("Breath Weapon",
                    //        StringResources.SR.GetString("BreathWeaponDes"),
                    //        String.Format(StringResources.SR.GetString("BreathWeaponAbbrev"), aoe, DC, damage,
                    //            damageType)),
                    //    new Trait("Damage Resistance",
                    //        StringResources.SR.GetString("DamageResistanceDes"),
                    //        String.Format(StringResources.SR.GetString("DamageResistanceAbbrev"), damageType)),
                    //});
                    break;
                case RaceEnum.Dwarf:
                    switch (_subrace)
                    {
                        case SubraceEnum.HillDwarf:
                            statIncrease.Wis += 1;
                            break;
                    }
                    break;
                case RaceEnum.Elf:
                    switch (_subrace)
                    {
                        case SubraceEnum.HighElf:
                            statIncrease.Int += 1;
                            ExtraProficiencies.AddRange(new []
                            {
                                Proficiency.Longsword, Proficiency.Shortbow, Proficiency.Shorsword, Proficiency.Longbow,
                            });
                            break;
                    }
                    break;
                case RaceEnum.Gnome:
                    switch (_subrace)
                    {
                        case SubraceEnum.RockGnome:
                            statIncrease.Con += 1;
                            //_traits.AddRange(new[]
                            //{
                            //    new Trait("Artificers Lore",
                            //        StringResources.SR.GetString("ArtificersLoreDes"),
                            //        StringResources.SR.GetString("ArtificersLoreAbbrev")),
                            //    new Trait("Tinker",
                            //        StringResources.SR.GetString("TinkerDes"),
                            //        StringResources.SR.GetString("TinkerAbbrev")),
                            //});
                            ExtraProficiencies.Add(Proficiency.TinkerTools);
                            break;
                    }
                    break;

            }
        }

        /// <summary>
        /// Returns subheader string for the given race
        /// </summary>
        /// <returns></returns>
        public string GetRaceSubheader()
        {
            switch (TypeEnum)
            {
                case RaceEnum.Dragonborn:
                    return "Proud, honorable warriors, born from the blood of an ancient dragon god.";
                case RaceEnum.Dwarf:
                    return
                        "A bold and hardy people, known for thier skilled warriors, miners and workers of stone and metal.";
                case RaceEnum.Elf:
                    return
                        "Elves are a magical people of otherworldly grace, living in the world but not entirely part of it.";
                case RaceEnum.Gnome:
                    return
                        "A gnome’s energy and enthusiasm for living shines through every inch of his or her tiny body.";
                case RaceEnum.HalfElf:
                    return "Half-elves combine what some say are the best qualities of their elf and human parents.";
                case RaceEnum.HalfOrc:
                    return
                        "Half-Orcs posess impressive physical power and are generally better suited to civilization then their pure-orc ancestors.";
                case RaceEnum.Tiefling:
                    return
                        "To be greeted with stares and whispers, to suffer violence and insult on the street, to see mistrust and fear in every eye: this is the lot of the tiefling.";
                case RaceEnum.Human:
                    return
                        "Humans are the most adaptable and ambitious people among the common races. Whatever drives them, humans are the innovators, the achievers, and the pioneers of the worlds.";
                case RaceEnum.Halfling:
                    return
                        "The diminutive halflings survive in a world full of larger creatures by avoiding notice or, barring that, avoiding offense.";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Returns the formatted string containing all of the racal details
        /// </summary>
        /// <returns></returns>
        public void GetRaceDetails(StackPanel raceDetailsStackPanel)
        {
            // Print general information
            var sp = new StackPanel {Orientation = Orientation.Horizontal};
            sp.Children.Add(new TextBlock
            {
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Text = "Average Height: "
            });
            sp.Children.Add(new TextBlock
            {
                FontSize = 20,
                Text = this.AvgHeight,
                Margin = new Thickness(5, 0, 0, 0),
                TextWrapping = TextWrapping.Wrap,
            });
            raceDetailsStackPanel.Children.Add(sp);

            sp = new StackPanel { Orientation = Orientation.Horizontal };
            sp.Children.Add(new TextBlock
            {
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Text = "Average Weight: "
            });
            sp.Children.Add(new TextBlock
            {
                FontSize = 20,
                Text = this.AvgWeight,
                Margin = new Thickness(5, 0, 0, 0),
                TextWrapping = TextWrapping.Wrap,
            });
            raceDetailsStackPanel.Children.Add(sp);

            sp = new StackPanel { Orientation = Orientation.Horizontal };
            sp.Children.Add(new TextBlock
            {
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Text = "Size: "
            });
            sp.Children.Add(new TextBlock
            {
                FontSize = 20,
                Text = this.Size.ToString(),
                Margin = new Thickness(5, 0, 0, 0),
                TextWrapping = TextWrapping.Wrap,
            });
            raceDetailsStackPanel.Children.Add(sp);

            sp = new StackPanel { Orientation = Orientation.Horizontal };
            sp.Children.Add(new TextBlock
            {
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Text = "Speed: ",
            });
            sp.Children.Add(new TextBlock
            {
                FontSize = 20,
                Text = this.Speed.ToString(),
                Margin = new Thickness(5, 0, 0, 0),
                TextWrapping = TextWrapping.Wrap,
            });
            raceDetailsStackPanel.Children.Add(sp);

            // Languages
            sp = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0, 0, 0, 15)
            };
            sp.Children.Add(new TextBlock
            {
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Text = "Languages: ",
            });
            var tbContent = new TextBlock
            {
                FontSize = 20,
                Margin = new Thickness(5, 0, 0, 0),
                TextWrapping = TextWrapping.Wrap,
                MaxWidth = 380,
            };
            foreach (var lang in RacialLanguages)
            {
                tbContent.Text += lang + ", ";
            }
            tbContent.Text = tbContent.Text.Remove(tbContent.Text.Length - 2);
            if (TypeEnum == RaceEnum.Human || TypeEnum == RaceEnum.HalfElf)
                tbContent.Text += "and one extra language of their choice";
            sp.Children.Add(tbContent);
            raceDetailsStackPanel.Children.Add(sp);

            // Ability Scores
            sp = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0, 0, 0, 15)
            };
            sp.Children.Add(new TextBlock
            {
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Text = "Ability Scores: ",
            });
            tbContent = new TextBlock
            {
                FontSize = 20,
                Margin = new Thickness(5, 0, 0, 0),
                Text = statIncrease.ToString(),
                TextWrapping = TextWrapping.Wrap,
                MaxWidth = 380,
            };
            if (TypeEnum == RaceEnum.HalfElf)
                tbContent.Text += "and 2 other attributes of their choice gain +1";
            sp.Children.Add(tbContent);
            raceDetailsStackPanel.Children.Add(sp);

            // Traits
            foreach (var trait in _traits)
            {
                sp = new StackPanel
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
                    MaxWidth = 380,
                    TextWrapping = TextWrapping.Wrap,
                });
                raceDetailsStackPanel.Children.Add(sp);
            }

        }
    }
}
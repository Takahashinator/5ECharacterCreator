using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using _5ECharacterCreator.Enums;
using _5ECharacterCreator.HelperStructs;

namespace _5ECharacterCreator
{
    public class CharacterClass
    {
        public string Name { get; }
        public readonly ClassEnum EnumType;
        private readonly int _hitDie;
        public int Level { get; set; }
        private readonly List<Proficiency> _proficiencies = new List<Proficiency>();
        private List<Trait> _traits = new List<Trait>();
        private readonly List<Proficiency> _skillChoices = new List<Proficiency>();
        private readonly List<Proficiency> _savingThrows = new List<Proficiency>();
        public int NumberofSkillChoices = 0;
        public int ProficiencyBonus = 2;
        public bool Spellcaster = false;
        public int AbilityScoreIncreases = 0;
        public int[] SpellArray = new int[11];
        public string SubclassName;
        private List<SubclassEnum> _allowedSubclasses = new List<SubclassEnum>();
        public int LevelIndex => Level - 1;
        public List<ClassChoice> ClassChoices = new List<ClassChoice>();

        public CharacterClass(ClassEnum typeEnum, int startLevel = 1)
        {
            EnumType = typeEnum;
            switch (typeEnum)
            {
                case ClassEnum.Barbarian:
                    Name = "Barbarian";
                    SubclassName = "Primal Path";
                    _hitDie = 12;
                    _proficiencies.AddRange(new[]{ Proficiency.LightArmor, Proficiency.MediumArmor,
                        Proficiency.SimpleWeapon, Proficiency.MartialWeapon,Proficiency.Shields,});
                    _savingThrows.AddRange(new []{Proficiency.Strength, Proficiency.Constitution});
                    NumberofSkillChoices = 2;
                    _skillChoices.AddRange(new []
                    {
                        Proficiency.AnimalHandling,
                        Proficiency.Athletics,
                        Proficiency.Intimidation,
                        Proficiency.Nature,
                        Proficiency.Perception,
                        Proficiency.Survival,
                    });
                    Spellcaster = false;
                    _allowedSubclasses.AddRange(new []
                    {
                        SubclassEnum.Berserker, SubclassEnum.TotemWarrior,
                    });
                    break;
                case ClassEnum.Bard:
                    Name = "Bard";
                    SubclassName = "Bardic College";
                    _hitDie = 8;
                    _proficiencies.AddRange(new[]
                    {
                        Proficiency.LightArmor, Proficiency.SimpleWeapon, 
                        Proficiency.HandCrossbow, Proficiency.Longsword, Proficiency.Rapier, Proficiency.Shorsword,
                    });
                    _savingThrows.AddRange(new[] { Proficiency.Dexterity, Proficiency.Charisma, });
                    NumberofSkillChoices = 3;
                    _skillChoices.AddRange(new[]
                    {
                        Proficiency.Any,
                    });
                    Spellcaster = true;
                    _allowedSubclasses.AddRange(new[]
                    {
                        SubclassEnum.Lore, SubclassEnum.Valor,
                    });
                    break;
                case ClassEnum.Cleric:
                    Name = "Cleric";
                    SubclassName = "Divne Domain";
                    _hitDie = 8;
                    _proficiencies.AddRange(new[] { Proficiency.LightArmor, Proficiency.MediumArmor, Proficiency.Shields,
                        Proficiency.SimpleWeapon, });
                    _savingThrows.AddRange(new[] { Proficiency.Wisdom, Proficiency.Charisma, });
                    NumberofSkillChoices = 2;
                    _skillChoices.AddRange(new[]
                    {
                        Proficiency.History,
                        Proficiency.Insight,
                        Proficiency.Medicine,
                        Proficiency.Persuasion,
                        Proficiency.Religion,
                    });
                    Spellcaster = true;
                    _allowedSubclasses.AddRange(new[]
                    {
                        SubclassEnum.Knowledge, SubclassEnum.Life,
                        SubclassEnum.Light, SubclassEnum.Nature,
                        SubclassEnum.Tempest, SubclassEnum.Trickery,
                        SubclassEnum.War
                    });
                    break;
                case ClassEnum.Druid:
                    Name = "Druid";
                    SubclassName = "Druid Circle";
                    _hitDie = 8;
                    _proficiencies.AddRange(new[] { Proficiency.LightArmor, Proficiency.MediumArmor, Proficiency.Shields,
                        Proficiency.Club, Proficiency.Dagger, Proficiency.Dart,
                        Proficiency.Javelin, Proficiency.Mace, Proficiency.Quarterstaff, Proficiency.Scimitar, Proficiency.Sickle,
                        Proficiency.Sling, Proficiency.Spear,Proficiency.HerbalismKit,
                    });
                    _savingThrows.AddRange(new[] { Proficiency.Intelligence, Proficiency.Wisdom, });
                    NumberofSkillChoices = 2;
                    _skillChoices.AddRange(new[]
                    {
                        Proficiency.Arcana,
                        Proficiency.AnimalHandling,
                        Proficiency.Insight,
                        Proficiency.Medicine,
                        Proficiency.Nature,
                        Proficiency.Perception,
                        Proficiency.Religion,
                        Proficiency.Survival,
                    });
                    Spellcaster = true;
                    _allowedSubclasses.AddRange(new[]
                    {
                        SubclassEnum.Land, SubclassEnum.Moon,
                    });
                    break;
                case ClassEnum.Fighter:
                    Name = "Fighter";
                    SubclassName = "Martial Archetype";
                    _hitDie = 10;
                    _proficiencies.AddRange(new[] { Proficiency.LightArmor, Proficiency.MediumArmor, Proficiency.HeavyArmor,
                        Proficiency.Shields, Proficiency.SimpleWeapon, Proficiency.MartialWeapon,});
                    _savingThrows.AddRange(new[] { Proficiency.Strength, Proficiency.Constitution, });
                    NumberofSkillChoices = 2;
                    _skillChoices.AddRange(new[]
                    {
                        Proficiency.Acrobatics,
                        Proficiency.AnimalHandling,
                        Proficiency.Athletics,
                        Proficiency.History,
                        Proficiency.Insight,
                        Proficiency.Intimidation,
                        Proficiency.Perception,
                        Proficiency.Survival,
                    });
                    Spellcaster = false;
                    _allowedSubclasses.AddRange(new[]
                    {
                        SubclassEnum.Champion, SubclassEnum.BattleMaster,
                    });
                    break;
                case ClassEnum.Monk:
                    Name = "Monk";
                    SubclassName = "Monastic Tradition";
                    _hitDie = 8;
                    _proficiencies.AddRange(new[] { Proficiency.SimpleWeapon, Proficiency.Shorsword,});
                    _savingThrows.AddRange(new[] { Proficiency.Dexterity, Proficiency.Strength, });
                    NumberofSkillChoices = 2;
                    _skillChoices.AddRange(new[]
                    {
                        Proficiency.Acrobatics,
                        Proficiency.Athletics,
                        Proficiency.History,
                        Proficiency.Insight,
                        Proficiency.Religion,
                        Proficiency.Stealth,
                    });
                    Spellcaster = false;
                    _allowedSubclasses.AddRange(new[]
                    {
                        SubclassEnum.OpenHand, SubclassEnum.Shadow, SubclassEnum.FourElements,
                    });
                    break;
                case ClassEnum.Paladin:
                    Name = "Paladin";
                    SubclassName = "Sacred Oath";
                    _hitDie = 10;
                    _proficiencies.AddRange(new[] { Proficiency.LightArmor, Proficiency.MediumArmor, Proficiency.HeavyArmor,
                        Proficiency.Shields, Proficiency.SimpleWeapon, Proficiency.MartialWeapon, });
                    _savingThrows.AddRange(new[] { Proficiency.Wisdom, Proficiency.Charisma, });
                    NumberofSkillChoices = 2;
                    _skillChoices.AddRange(new[]
                    {
                        Proficiency.Insight,
                        Proficiency.Athletics,
                        Proficiency.Intimidation,
                        Proficiency.Medicine,
                        Proficiency.Persuasion,
                        Proficiency.Religion,
                    });
                    Spellcaster = true;
                    _allowedSubclasses.AddRange(new[]
                    {
                        SubclassEnum.Devotion, SubclassEnum.Ancients, SubclassEnum.Vengeance,
                    });
                    break;
                case ClassEnum.Ranger:
                    Name = "Ranger";
                    SubclassName = "Ranger Archetype";
                    _hitDie = 10;
                    _proficiencies.AddRange(new[] { Proficiency.LightArmor, Proficiency.MediumArmor, Proficiency.Shields,
                        Proficiency.SimpleWeapon, Proficiency.MartialWeapon,});
                    _savingThrows.AddRange(new[] { Proficiency.Dexterity, Proficiency.Strength, });
                    NumberofSkillChoices = 3;
                    _skillChoices.AddRange(new[]
                    {
                        Proficiency.AnimalHandling,
                        Proficiency.Athletics,
                        Proficiency.Insight,
                        Proficiency.Investigation,
                        Proficiency.Perception,
                        Proficiency.Nature,
                        Proficiency.Stealth,
                        Proficiency.Survival,
                    });
                    Spellcaster = true;
                    _allowedSubclasses.AddRange(new[]
                    {
                        SubclassEnum.Hunter, SubclassEnum.BeastMaster,
                    });
                    break;
                case ClassEnum.Rogue:
                    Name = "Rogue";
                    SubclassName = "Roguish Archetype";
                    _hitDie = 8;
                    _proficiencies.AddRange(new[]
                    {
                        Proficiency.LightArmor, Proficiency.SimpleWeapon,
                        Proficiency.HandCrossbow, Proficiency.Longsword, Proficiency.Rapier, Proficiency.Shorsword,
                        Proficiency.ThievesTools,
                    });
                    _savingThrows.AddRange(new[] { Proficiency.Dexterity, Proficiency.Intelligence, });
                    NumberofSkillChoices = 4;
                    _skillChoices.AddRange(new[]
                    {
                        Proficiency.Acrobatics,
                        Proficiency.Athletics,
                        Proficiency.Deception,
                        Proficiency.Insight,
                        Proficiency.Intimidation,
                        Proficiency.Investigation,
                        Proficiency.Perception,
                        Proficiency.Performance,
                        Proficiency.Persuasion,
                        Proficiency.SlightOfHand,
                        Proficiency.Stealth,
                    });
                    Spellcaster = false;
                    _allowedSubclasses.AddRange(new[]
                    {
                        SubclassEnum.Thief, SubclassEnum.Assassin, SubclassEnum.ArcaneTrickster,
                    });
                    break;
                case ClassEnum.Sorcerer:
                    Name = "Sorcerer";
                    SubclassName = "Sorcerous Origin";
                    _hitDie = 6;
                    _proficiencies.AddRange(new[]
                    {
                        Proficiency.Dagger,
                        Proficiency.Dart, Proficiency.Sling, Proficiency.Quarterstaff, Proficiency.LightCrossbow
                    });
                    _savingThrows.AddRange(new[] { Proficiency.Constitution, Proficiency.Charisma, });
                    NumberofSkillChoices = 2;
                    _skillChoices.AddRange(new[]
                    {
                        Proficiency.Arcana,
                        Proficiency.Deception,
                        Proficiency.Insight,
                        Proficiency.Intimidation,
                        Proficiency.Persuasion,
                        Proficiency.Religion,
                    });
                    Spellcaster = true;
                    _allowedSubclasses.AddRange(new[]
                    {
                        SubclassEnum.DraconicBloodline, SubclassEnum.WildMagic,
                    });
                    break;
                case ClassEnum.Warlock:
                    Name = "Warlock";
                    SubclassName = "Otherworldly Patron";
                    _hitDie = 8;
                    _proficiencies.AddRange(new[] { Proficiency.LightArmor, Proficiency.SimpleWeapon, });
                    _savingThrows.AddRange(new[] { Proficiency.Wisdom, Proficiency.Charisma, });
                    NumberofSkillChoices = 2;
                    _skillChoices.AddRange(new[]
                    {
                        Proficiency.Arcana,
                        Proficiency.Deception,
                        Proficiency.History,
                        Proficiency.Intimidation,
                        Proficiency.Investigation,
                        Proficiency.Nature,
                        Proficiency.Religion,
                    });
                    Spellcaster = true;
                    _allowedSubclasses.AddRange(new[]
                    {
                        SubclassEnum.GreatOldOne, SubclassEnum.Archfey, SubclassEnum.Fiend,
                    });
                    break;
                case ClassEnum.Wizard:
                    Name = "Wizard";
                    SubclassName = "Arcane Tradition";
                    _hitDie = 6;
                    _proficiencies.AddRange(new[]
                    {
                        Proficiency.Dagger,
                        Proficiency.Dart, Proficiency.Sling, Proficiency.Quarterstaff,
                        Proficiency.LightCrossbow,
                    });
                    _savingThrows.AddRange(new[] { Proficiency.Intelligence, Proficiency.Wisdom, });
                    NumberofSkillChoices = 2;
                    _skillChoices.AddRange(new[]
                    {
                        Proficiency.Arcana,
                        Proficiency.History,
                        Proficiency.Insight,
                        Proficiency.Investigation,
                        Proficiency.Medicine,
                        Proficiency.Religion,
                    });
                    Spellcaster = true;
                    _allowedSubclasses.AddRange(new[]
                    {
                        SubclassEnum.Abjuration, SubclassEnum.Conjuration, SubclassEnum.Enchantment,
                        SubclassEnum.Divination, SubclassEnum.Evocation, SubclassEnum.Illusion,
                        SubclassEnum.Necromancy, SubclassEnum.Transmuation,
                    });
                    break;
            }
            LevelTo(startLevel);
        }

        public void LevelTo(int lvl)
        {
            Level = lvl;
            _traits = new List<Trait>();
            ClassChoices = new List<ClassChoice>();
            switch (EnumType)
            {
/************************----BARBARIAN----**************************************/
                case ClassEnum.Barbarian:
                    // Reset to defaults
                    if (Level >= 1)
                    {
                        AbilityScoreIncreases = 0;
                        ProficiencyBonus = 2;
                        _traits.AddRange(new[]
                        {
                            new Trait("Barbarian Rage",
                                StringResources.SR.GetString("RageDes"),
                                string.Format(StringResources.SR.GetString("RageAbbrev"), 2, 2),true),
                            new Trait("Unarmored Defense",
                                StringResources.SR.GetString("UnarmoredDefenseBarb"),
                                StringResources.SR.GetString("UnarmoredDefenseBarb"),false),
                        });
                    }
                    if (Level >= 2)
                    {
                        _traits.Add(new Trait("Reckless Attack",
                            StringResources.SR.GetString("RecklessAttackDes"),
                            StringResources.SR.GetString("RecklessAttackAbbrev"), true));
                        _traits.Add(new Trait("Danger Sense",
                            StringResources.SR.GetString("DangerSenseDes"),
                            StringResources.SR.GetString("DangerSenseAbbrev"), true));
                    }
                    if (Level >= 3)
                    {
                        // Rage +1
                        var index = _traits.FindIndex(p => p.Header == "Barbarian Rage");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("RageAbbrev"), 2, 3);

                    }
                    if (Level >= 4)
                    {
                        // ASI+1
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 5)
                    {
                        ProficiencyBonus = 3;
                        _traits.Add(new Trait("Extra Attack",
                            StringResources.SR.GetString("ExtraAttackDes"),
                            string.Format(StringResources.SR.GetString("ExtraAttackAbbrev"), 2), true));
                        _traits.Add(new Trait("Fast Movement",
                            StringResources.SR.GetString("FastMovement"),
                            StringResources.SR.GetString("FastMovement"), false));
                    }
                    if (Level >= 6)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Barbarian Rage");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("RageAbbrev"), 2, 4);
                    }
                    if (Level >= 7)
                    {
                        _traits.Add(new Trait("Feral Instinct",
                            StringResources.SR.GetString("FeralInstinctDes"),
                            StringResources.SR.GetString("FeralInstinctAbbrev"), true));
                    }
                    if (Level >= 8)
                    {
                        //ASI+1
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 9)
                    {
                        ProficiencyBonus = 4;
                        var index = _traits.FindIndex(p => p.Header == "Barbarian Rage");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("RageAbbrev"), 3, 4);

                        _traits.Add(new Trait("Brutal Critical",
                            StringResources.SR.GetString("BrutalCriticalDes"),
                            string.Format(StringResources.SR.GetString("BrutalCriticalAbbrev"), 1), true));
                    }
                    if (Level >= 11)
                    {
                        _traits.Add(new Trait("Relentless Rage",
                            StringResources.SR.GetString("RelentlessRageDes"),
                            StringResources.SR.GetString("RelentlessRageAbbrev"), true));
                    }
                    if (Level >= 12)
                    {
                        //ASI+1
                        AbilityScoreIncreases += 1;
                        var index = _traits.FindIndex(p => p.Header == "Barbarian Rage");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("RageAbbrev"), 3, 5);
                    }
                    if (Level >= 13)
                    {
                        ProficiencyBonus = 5;
                        // brutal critical +1
                        var index = _traits.FindIndex(p => p.Header == "Brutal Critical");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("BrutalCriticalAbbrev"), 2);
                    }
                    if (Level >= 15)
                    {
                        _traits.Add(new Trait("Persistent Rage",
                            StringResources.SR.GetString("PersistentRageDes"),
                            StringResources.SR.GetString("PersistentRageAbbrev"), true));
                    }
                    if (Level >= 16)
                    {
                        //ASI+1
                        AbilityScoreIncreases += 1;
                        var index = _traits.FindIndex(p => p.Header == "Barbarian Rage");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("RageAbbrev"), 4, 5);
                    }
                    if (Level >= 17)
                    {
                        ProficiencyBonus = 6;
                        // brutal critical +1
                        var index = _traits.FindIndex(p => p.Header == "Barbarian Rage");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("RageAbbrev"), 4, 6);
                        index = _traits.FindIndex(p => p.Header == "Brutal Critical");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("BrutalCriticalAbbrev"), 3);
                    }
                    if (Level >= 18)
                    {
                        _traits.Add(new Trait("Indomitable Might",
                            StringResources.SR.GetString("IndomitableMightDes"),
                            StringResources.SR.GetString("IndomitableMightAbbrev"), true));
                    }
                    if (Level >= 19)
                    {
                        // ASI+1
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 20)
                    {
                        _traits.Add(new Trait("Primal Champion",
                            StringResources.SR.GetString("PrimalChampion"),
                            StringResources.SR.GetString("PrimalChampion"), true));
                        var index = _traits.FindIndex(p => p.Header == "Barbarian Rage");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("RageAbbrev"), 4, "unlimited");
                    }
                    break;
/************************----BARD----**************************************/
                case ClassEnum.Bard:
                    if (Level >= 1)
                    {
                        SpellArray = new int[11];
                        SpellArray[0] = 2;
                        SpellArray[1] = 4;
                        SpellArray[2] = 2;
                        ProficiencyBonus = 2;
                        _traits.AddRange(new[]
                        {
                            new Trait("Bardic Inspiration",
                                StringResources.SR.GetString("BardicInspirationDes"),
                                string.Format(StringResources.SR.GetString("BardicInspirationAbbrev"), "d6"),true),
                        });
                    }
                    if (Level >= 2)
                    {
                        SpellArray[1] = 5;
                        SpellArray[2] = 3;
                        _traits.Add(new Trait("Jack of All Trades",
                            StringResources.SR.GetString("JackofAllTrades"),
                            StringResources.SR.GetString("JackofAllTrades"),false));
                        _traits.Add(new Trait("Song of Rest",
                            StringResources.SR.GetString("SongofRestDes"),
                            string.Format(StringResources.SR.GetString("SongofRestAbbrev"), "1d6"), true));
                    }
                    if (Level >= 3)
                    {
                        SpellArray[1] = 6;
                        SpellArray[2] = 4;
                        SpellArray[3] = 2;
                        _traits.Add(new Trait("Expertise",
                            StringResources.SR.GetString("Expertise"),
                            StringResources.SR.GetString("Expertise"), false));
                    }
                    if (Level >= 4)
                    {
                        SpellArray[0] = 3;
                        SpellArray[1] = 7;
                        SpellArray[2] = 4;
                        SpellArray[3] = 3;
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 5)
                    {
                        SpellArray[1] = 8;
                        SpellArray[4] = 2;
                        ProficiencyBonus = 3;
                        var index = _traits.FindIndex(p => p.Header == "Bardic Inspiration");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("BardicInspirationAbbrev"), "d8");
                        _traits.Add(new Trait("Font of Inspiration",
                            StringResources.SR.GetString("FontofInspirationDes"),
                            StringResources.SR.GetString("FontofInspirationAbbrev"), true));
                    }
                    if (Level >= 6)
                    {
                        SpellArray[1] = 9;
                        SpellArray[4] = 3;
                        _traits.Add(new Trait("Countercharm",
                            StringResources.SR.GetString("CountercharmDes"),
                            StringResources.SR.GetString("CountercharmAbbrev"), true));
                    }
                    if (Level >= 7)
                    {
                        SpellArray[1] = 10;
                        SpellArray[5] = 1;
                    }
                    if (Level >= 8)
                    {
                        SpellArray[1] = 11;
                        SpellArray[5] = 2;
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 9)
                    {
                        SpellArray[1] = 12;
                        SpellArray[5] = 3;
                        SpellArray[6] = 1;
                        ProficiencyBonus = 4;
                        var index = _traits.FindIndex(p => p.Header == "Song of Rest");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SongofRestAbbrev"), "1d8");
                    }
                    if (Level >= 10)
                    {
                        SpellArray[0] = 4;
                        SpellArray[1] = 14;
                        SpellArray[6] = 2;
                        var index = _traits.FindIndex(p => p.Header == "Bardic Inspiration");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("BardicInspirationAbbrev"), "d10");
                        _traits.Add(new Trait("Magical Secrets",
                            StringResources.SR.GetString("MagicalSecrets"),
                            StringResources.SR.GetString("MagicalSecrets"), false));
                    }
                    if (Level >= 11)
                    {
                        SpellArray[1] = 15;
                        SpellArray[7] = 1;
                    }
                    if (Level >= 12)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 13)
                    {
                        SpellArray[1] = 16;
                        SpellArray[8] = 1;
                        ProficiencyBonus = 5;
                        var index = _traits.FindIndex(p => p.Header == "Song of Rest");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SongofRestAbbrev"), "1d10");
                    }
                    if (Level >= 14)
                    {
                        SpellArray[1] = 18;
                    }
                    if (Level >= 15)
                    {
                        SpellArray[1] = 19;
                        SpellArray[9] = 1;
                        var index = _traits.FindIndex(p => p.Header == "Bardic Inspiration");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("BardicInspirationAbbrev"), "d12");
                    }
                    if (Level >= 16)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 17)
                    {
                        SpellArray[1] = 20;
                        SpellArray[10] = 1;
                        ProficiencyBonus = 6;
                        var index = _traits.FindIndex(p => p.Header == "Song of Rest");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SongofRestAbbrev"), "1d12");
                    }
                    if (Level >= 18)
                    {
                        SpellArray[1] = 22;
                        SpellArray[6] = 3;
                    }
                    if (Level >= 19)
                    {
                        SpellArray[7] = 2;
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 20)
                    {
                        SpellArray[8] = 2;
                        _traits.Add(new Trait("Superior Inspiration",
                            StringResources.SR.GetString("SuperiorInspirationDes"),
                            StringResources.SR.GetString("SuperiorInspirationAbbrev"), true));
                    }
                    break;
/************************----CLERIC----**************************************/
                case ClassEnum.Cleric:
                    if (Level >= 1)
                    {
                        SpellArray = new int[10];
                        SpellArray[0] = 3;
                        SpellArray[1] = 2;
                        ProficiencyBonus = 2;
                    }
                    if (Level >= 2)
                    {
                        SpellArray[1] = 3;
                        _traits.Add(new Trait("Channel Divinity",
                            StringResources.SR.GetString("ChannelDivinityDes"),
                            string.Format(StringResources.SR.GetString("ChannelDivinityAbbrev"), 1), true));
                        _traits.Add(new Trait("Turn Undead",
                            StringResources.SR.GetString("TurnUndeadDes"),
                            StringResources.SR.GetString("TurnUndeadAbbrev"), true));
                    }
                    if (Level >= 3)
                    {
                        SpellArray[1] = 4;
                        SpellArray[2] = 2;
                    }
                    if (Level >= 4)
                    {
                        SpellArray[0] = 4;
                        SpellArray[3] = 2;
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 5)
                    {
                        SpellArray[3] = 2;
                        ProficiencyBonus = 3;
                        _traits.Add(new Trait("Destroy Undead",
                            StringResources.SR.GetString("DestroyUndeadDes"),
                            string.Format(StringResources.SR.GetString("DestroyUndeadAbbrev"), "1/2"), true));
                    }
                    if (Level >= 6)
                    {
                        SpellArray[3] = 3;
                        var index = _traits.FindIndex(p => p.Header == "Channel Divinity");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("ChannelDivinityAbbrev"), 2);
                    }
                    if (Level >= 7)
                    {
                        SpellArray[4] = 1;
                    }
                    if (Level >= 8)
                    {
                        SpellArray[4] = 2;
                        AbilityScoreIncreases += 1;
                        var index = _traits.FindIndex(p => p.Header == "Destroy Undead");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("DestroyUndeadAbbrev"), "1");
                    }
                    if (Level >= 9)
                    {
                        SpellArray[4] = 3;
                        SpellArray[5] = 1;
                        ProficiencyBonus = 4;
                    }
                    if (Level >= 10)
                    {
                        SpellArray[0] = 5;
                        SpellArray[5] = 2;
                        _traits.Add(new Trait("Divine Intervention",
                            StringResources.SR.GetString("DivineInterventionDes"),
                            StringResources.SR.GetString("DivineInterventionAbbrev"), true));
                    }
                    if (Level >= 11)
                    {
                        SpellArray[6] = 1;
                        var index = _traits.FindIndex(p => p.Header == "Destroy Undead");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("DestroyUndeadAbbrev"), "2");
                    }
                    if (Level >= 12)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 13)
                    {
                        SpellArray[7] = 1;
                        ProficiencyBonus = 5;
                    }
                    if (Level >= 14)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Destroy Undead");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("DestroyUndeadAbbrev"), "3");
                    }
                    if (Level >= 15)
                    {
                        SpellArray[8] = 1;
                    }
                    if (Level >= 16)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 17)
                    {
                        SpellArray[9] = 1;
                        ProficiencyBonus = 6;
                        var index = _traits.FindIndex(p => p.Header == "Destroy Undead");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("DestroyUndeadAbbrev"), "4");
                    }
                    if (Level >= 18)
                    {
                        SpellArray[5] = 3;
                        var index = _traits.FindIndex(p => p.Header == "Channel Divinity");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("ChannelDivinityAbbrev"), 3);
                    }
                    if (Level >= 19)
                    {
                        SpellArray[6] = 2;
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 20)
                    {
                        SpellArray[7] = 2;
                        var index = _traits.FindIndex(p => p.Header == "Divine Intervention");
                        _traits[index].SheetDescription = "Your diety intervenes at your command. Usable once every 7 days.";
                    }
                    break;
/************************----DRUID----**************************************/
                case ClassEnum.Druid:
                    if (Level >= 1)
                    {
                        SpellArray = new int[10];
                        SpellArray[0] = 2;
                        SpellArray[1] = 2;
                        ProficiencyBonus = 2;
                        _traits.Add(new Trait("Druidic",
                            StringResources.SR.GetString("Druidic"),
                            StringResources.SR.GetString("Druidic"),false));
                    }
                    if (Level >= 2)
                    {
                        SpellArray[1] = 3;
                        _traits.Add(new Trait("Wild Shape",
                            StringResources.SR.GetString("WildShapeDes"),
                            string.Format(StringResources.SR.GetString("WildShapeAbbrev"), "1/4", "No flying or swimming beasts", 2), true));
                    }
                    if (Level >= 3)
                    {
                        SpellArray[1] = 4;
                        SpellArray[2] = 2;
                    }
                    if (Level >= 4)
                    {
                        SpellArray[0] = 3;
                        SpellArray[2] = 3;
                        var index = _traits.FindIndex(p => p.Header == "Wild Shape");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("WildShapeAbbrev"), "1/2", "No flying", 2);
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 5)
                    {
                        SpellArray[3] = 2;
                        ProficiencyBonus = 3;
                    }
                    if (Level >= 6)
                    {
                        SpellArray[3] = 3;
                    }
                    if (Level >= 7)
                    {
                        SpellArray[4] = 1;
                    }
                    if (Level >= 8)
                    {
                        SpellArray[4] = 2;
                        AbilityScoreIncreases += 1;
                        var index = _traits.FindIndex(p => p.Header == "Wild Shape");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("WildShapeAbbrev"), "1", "", 2);
                    }
                    if (Level >= 9)
                    {
                        SpellArray[4] = 3;
                        SpellArray[5] = 1;
                        ProficiencyBonus = 4;
                    }
                    if (Level >= 10)
                    {
                        SpellArray[0] = 4;
                        SpellArray[5] = 2;
                    }
                    if (Level >= 11)
                    {
                        SpellArray[6] = 1;
                    }
                    if (Level >= 12)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 13)
                    {
                        SpellArray[7] = 1;
                        ProficiencyBonus = 5;
                    }
                    if (Level >= 14)
                    {

                    }
                    if (Level >= 15)
                    {
                        SpellArray[8] = 1;
                    }
                    if (Level >= 16)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 17)
                    {
                        SpellArray[9] = 1;
                        ProficiencyBonus = 6;
                    }
                    if (Level >= 18)
                    {
                        SpellArray[5] = 3;
                        _traits.Add(new Trait("Timeless Body",
                            StringResources.SR.GetString("TimelessBodyDruDes"),
                            StringResources.SR.GetString("TimelessBodyDruAbbrev"), true));
                        _traits.Add(new Trait("Beast Spells",
                            StringResources.SR.GetString("BeastSpellsDes"),
                            StringResources.SR.GetString("BeastSpellsAbbrev"), true));
                    }
                    if (Level >= 19)
                    {
                        SpellArray[6] = 2;
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 20)
                    {
                        SpellArray[7] = 2;
                        _traits.Add(new Trait("Archdruid",
                            StringResources.SR.GetString("Archdruid"),
                            StringResources.SR.GetString("Archdruid"), true));
                        var index = _traits.FindIndex(p => p.Header == "Wild Shape");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("WildShapeAbbrev"), "1", "", "unlimited");
                    }
                    break;
/************************----FIGHTER----**************************************/
                case ClassEnum.Fighter:
                    if (Level >= 1)
                    {
                        ProficiencyBonus = 2;
                        _traits.Add(new Trait("Fighting Style",
                            StringResources.SR.GetString("FightingStyle"),
                            StringResources.SR.GetString("FightingStyle"), false));
                        ClassChoices.Add(new ClassChoice(ClassChoicesEnum.FighterFightingStyle, lvl));
                        _traits.Add(new Trait("Second Wind",
                            StringResources.SR.GetString("SecondWindDes"),
                            StringResources.SR.GetString("SecondWindAbbrev"), true));
                    }
                    if (Level >= 2)
                    {
                        _traits.Add(new Trait("Action Surge",
                            StringResources.SR.GetString("ActionSurgeDes"),
                            string.Format(StringResources.SR.GetString("ActionSurgeAbbrev"), 1), true));
                    }
                    if (Level >= 4)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 5)
                    {
                        ProficiencyBonus = 3;
                        _traits.Add(new Trait("Extra Attack",
                            StringResources.SR.GetString("ExtraAttackDes"),
                            string.Format(StringResources.SR.GetString("ExtraAttackAbbrev"), 2), true));
                    }
                    if (Level >= 6)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 8)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 9)
                    {
                        ProficiencyBonus = 4;
                        _traits.Add(new Trait("Indomitable",
                            StringResources.SR.GetString("IndomitableDes"),
                            string.Format(StringResources.SR.GetString("IndomitableAbbrev"), 1), true));
                    }
                    if (Level >= 11)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Extra Attack");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("ExtraAttackAbbrev"), 3);
                    }
                    if (Level >= 12)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 13)
                    {
                        ProficiencyBonus = 5;
                        var index = _traits.FindIndex(p => p.Header == "Indomitable");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("IndomitableAbbrev"), 2);
                    }
                    if (Level >= 14)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 16)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 17)
                    {
                        ProficiencyBonus = 6;
                        var index = _traits.FindIndex(p => p.Header == "Indomitable");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("IndomitableAbbrev"), 3);
                        index = _traits.FindIndex(p => p.Header == "Action Surge");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("ActionSurgeAbbrev"), 2);
                    }
                    if (Level >= 18)
                    {

                    }
                    if (Level >= 19)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 20)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Extra Attack");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("ExtraAttackAbbrev"), 4);
                    }
                    break;
/************************----MONK----**************************************/
                case ClassEnum.Monk:
                    if (Level >= 1)
                    {
                        ProficiencyBonus = 2;
                        _traits.Add(new Trait("Unarmored Defense",
                            StringResources.SR.GetString("UnarmoredDefenseMonk"),
                            StringResources.SR.GetString("UnarmoredDefenseMonk"), false));
                        _traits.Add(new Trait("Martial Arts",
                            StringResources.SR.GetString("MartialArtsDes"),
                            StringResources.SR.GetString("MartialArtsAbbrev"), true));
                    }
                    if (Level >= 2)
                    {
                        _traits.Add(new Trait("Ki",
                            StringResources.SR.GetString("KiDes"),
                            string.Format(StringResources.SR.GetString("KiAbbrev"), 2), true));
                        _traits.Add(new Trait("Flurry of Blows",
                            StringResources.SR.GetString("FlurryofBlows"),
                            StringResources.SR.GetString("FlurryofBlows"), true));
                        _traits.Add(new Trait("Patient Defense",
                            StringResources.SR.GetString("PatientDefense"),
                            StringResources.SR.GetString("PatientDefense"), true));
                        _traits.Add(new Trait("Step of the Wind",
                            StringResources.SR.GetString("StepoftheWind"),
                            StringResources.SR.GetString("StepoftheWind"), true));
                        _traits.Add(new Trait("Unarmored Movement",
                            StringResources.SR.GetString("MonkUnarmoredMovementDes"),
                            StringResources.SR.GetString("UnarmoredMovement"), false));
                    }
                    if (Level >= 3)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 3);
                        _traits.Add(new Trait("Deflect Missles",
                            StringResources.SR.GetString("DeflectMissilesDes"),
                            StringResources.SR.GetString("DeflectMissilesAbbrev"), true));
                    }
                    if (Level >= 4)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 4);
                        AbilityScoreIncreases += 1;
                        _traits.Add(new Trait("Slow Fall",
                            StringResources.SR.GetString("SlowFallDes"),
                            StringResources.SR.GetString("SlowFallAbbrev"), true));
                    }
                    if (Level >= 5)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 5);
                        ProficiencyBonus = 3;
                        _traits.Add(new Trait("Extra Attack",
                            StringResources.SR.GetString("ExtraAttackDes"),
                            string.Format(StringResources.SR.GetString("ExtraAttackAbbrev"), 2), true));
                        _traits.Add(new Trait("Stunning Strike",
                            StringResources.SR.GetString("StunningStrikeDes"),
                            StringResources.SR.GetString("StunningStrikeAbbrev"), true));
                    }
                    if (Level >= 6)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 6);
                        _traits.Add(new Trait("Ki-Empowered Strikes",
                            StringResources.SR.GetString("KiEmpoweredStrikesDes"),
                            StringResources.SR.GetString("KiEmpoweredStrikesAbbrev"), true));
                    }
                    if (Level >= 7)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 7);
                        _traits.Add(new Trait("Evasion",
                            StringResources.SR.GetString("EvasionDesMonk"),
                            StringResources.SR.GetString("EvasionAbbrev"), true));
                        _traits.Add(new Trait("Stillness of Mind",
                            StringResources.SR.GetString("StillnessofMindDes"),
                            StringResources.SR.GetString("StillnessofMindAbbrev"), true));
                    }
                    if (Level >= 8)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 8);
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 9)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 9);
                        ProficiencyBonus = 4;
                        index = _traits.FindIndex(p => p.Header == "Unarmored Movement");
                        _traits[index].SheetDescription = StringResources.SR.GetString("MonkUnarmoredMovementAbbrev");
                        _traits[index].FullDescription = StringResources.SR.GetString("MonkUnarmoredMovementDes");
                        _traits[index].IncludePDF = true;
                    }
                    if (Level >= 10)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 10);
                        _traits.Add(new Trait("Purity of Body",
                            StringResources.SR.GetString("PurityofBodyDes"),
                            StringResources.SR.GetString("PurityofBodyAbbrev"), true));
                    }
                    if (Level >= 11)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 11);
                    }
                    if (Level >= 12)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 12);
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 13)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 13);
                        ProficiencyBonus = 5;
                        _traits.Add(new Trait("Tounge of the Sun and Moon",
                            StringResources.SR.GetString("ToungeoftheSunandMoonDes"),
                            StringResources.SR.GetString("ToungeoftheSunandMoonAbbrev"), true));
                    }
                    if (Level >= 14)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 14);
                        _traits.Add(new Trait("Diamond Soul",
                            StringResources.SR.GetString("DiamondSoulDes"),
                            StringResources.SR.GetString("DiamondSoulAbbrev"), true));
                    }
                    if (Level >= 15)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 15);
                        _traits.Add(new Trait("Timeless Body",
                            StringResources.SR.GetString("TimelessBodyMonkDes"),
                            StringResources.SR.GetString("TimelessBodyMonkAbbrev"), true));
                    }
                    if (Level >= 16)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 16);
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 17)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 17);
                        ProficiencyBonus = 6;
                    }
                    if (Level >= 18)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 18);
                        _traits.Add(new Trait("Empty Body",
                            StringResources.SR.GetString("EmptyBodyDes"),
                            StringResources.SR.GetString("EmptyBodyAbbrev"), true));
                    }
                    if (Level >= 19)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 19);
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 20)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Ki");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("KiAbbrev"), 20);
                        _traits.Add(new Trait("Perfect Soul",
                            StringResources.SR.GetString("PerfectSoulDes"),
                            StringResources.SR.GetString("PerfectSoulAbbrev"), true));
                    }
                    break;
/************************----PALADIN----**************************************/
                case ClassEnum.Paladin:
                    if (Level >= 1)
                    {
                        ProficiencyBonus = 2;
                        SpellArray = new int[5];
                        _traits.Add(new Trait("Divine Sense",
                            StringResources.SR.GetString("DivineSenseDes"),
                            StringResources.SR.GetString("DivineSenseAbbrev"), true));
                        _traits.Add(new Trait("Lay on Hands",
                            StringResources.SR.GetString("LayonHandsDes"),
                            StringResources.SR.GetString("LayonHandsAbbrev"), true));
                    }
                    if (Level >= 2)
                    {
                        SpellArray[0] = 2;
                        _traits.Add(new Trait("Fighting Style",
                            StringResources.SR.GetString("FightingStyle"),
                            StringResources.SR.GetString("FightingStyle"), false));
                        ClassChoices.Add(new ClassChoice(ClassChoicesEnum.PaladinFightingStyle, lvl));
                        _traits.Add(new Trait("Divine Smite",
                            StringResources.SR.GetString("DivineSmiteDes"),
                            StringResources.SR.GetString("DivineSmiteAbbrev"), true));
                    }
                    if (Level >= 3)
                    {
                        SpellArray[0] = 3;
                        _traits.Add(new Trait("Divine Health",
                            StringResources.SR.GetString("DivineHealthDes"),
                            StringResources.SR.GetString("DivineHealthAbbrev"), true));
                    }
                    if (Level >= 4)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 5)
                    {
                        SpellArray[0] = 4;
                        SpellArray[1] = 2;
                        ProficiencyBonus = 3;
                        _traits.Add(new Trait("Extra Attack",
                            StringResources.SR.GetString("ExtraAttackDes"),
                            string.Format(StringResources.SR.GetString("ExtraAttackAbbrev"), 2), true));
                    }
                    if (Level >= 6)
                    {
                        _traits.Add(new Trait("Aura of Protection",
                            StringResources.SR.GetString("AuraofProtectionDes"),
                            string.Format(StringResources.SR.GetString("AuraofProtectionAbbrev"), "10"), true));
                    }
                    if (Level >= 7)
                    {
                        SpellArray[1] = 3;
                    }
                    if (Level >= 8)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 9)
                    {
                        SpellArray[2] = 2;
                        ProficiencyBonus = 4;
                    }
                    if (Level >= 10)
                    {
                        _traits.Add(new Trait("Aura of Courage",
                            StringResources.SR.GetString("AuraofCourageDes"),
                            string.Format(StringResources.SR.GetString("AuraofCourageAbbrev"),"10"), true));
                    }
                    if (Level >= 11)
                    {
                        SpellArray[2] = 3;
                        _traits.Add(new Trait("Improved Divine Smite",
                            StringResources.SR.GetString("ImprovedDivineSmite"),
                            StringResources.SR.GetString("ImprovedDivineSmite"), false));
                    }
                    if (Level >= 12)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 13)
                    {
                        SpellArray[3] = 1;
                        ProficiencyBonus = 5;
                    }
                    if (Level >= 14)
                    {
                        _traits.Add(new Trait("Cleansing Touch",
                            StringResources.SR.GetString("CleansingTouchDes"),
                            StringResources.SR.GetString("CleansingTouchAbbrev"), true));
                    }
                    if (Level >= 15)
                    {
                        SpellArray[3] = 2;
                    }
                    if (Level >= 16)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 17)
                    {
                        SpellArray[3] = 3;
                        SpellArray[4] = 1;
                        ProficiencyBonus = 6;
                    }
                    if (Level >= 18)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Aura of Courage");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("AuraofCourageAbbrev"), "30");
                        index = _traits.FindIndex(p => p.Header == "Aura of Protection");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("AuraofProtection"), "30");
                    }
                    if (Level >= 19)
                    {
                        SpellArray[4] = 2;
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 20)
                    {

                    }
                    break;
/************************----RANGER----**************************************/
                case ClassEnum.Ranger:
                    if (Level >= 1)
                    {
                        ProficiencyBonus = 2;
                        SpellArray = new int[6];
                        _traits.Add(new Trait("Favored Enemy",
                            StringResources.SR.GetString("FavoredEnemy"),
                            StringResources.SR.GetString("FavoredEnemy"), false));
                        _traits.Add(new Trait("Natural Explorer",
                            StringResources.SR.GetString("NaturalExplorerDes"),
                            StringResources.SR.GetString("NaturalExplorerAbbrev"), true));
                    }
                    if (Level >= 2)
                    {
                        SpellArray[0] = 2;
                        SpellArray[1] = 2;
                        _traits.Add(new Trait("Fighting Style",
                            StringResources.SR.GetString("FightingStyleRanger"),
                            StringResources.SR.GetString("FightingStyleRanger"), false));
                        ClassChoices.Add(new ClassChoice(ClassChoicesEnum.RangerFightingStyle, lvl));
                    }
                    if (Level >= 3)
                    {
                        SpellArray[0] = 3;
                        SpellArray[1] = 3;
                        _traits.Add(new Trait("Primeval Awareness",
                            StringResources.SR.GetString("PrimevalAwarenessDes"),
                            StringResources.SR.GetString("PrimevalAwarenessAbbrev"), true));
                    }
                    if (Level >= 4)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 5)
                    {
                        SpellArray[0] = 4;
                        SpellArray[1] = 4;
                        SpellArray[2] = 2;
                        ProficiencyBonus = 3;
                        _traits.Add(new Trait("Extra Attack",
                            StringResources.SR.GetString("ExtraAttackDes"),
                            string.Format(StringResources.SR.GetString("ExtraAttackAbbrev"), 2), true));
                    }
                    if (Level >= 6)
                    {

                    }
                    if (Level >= 7)
                    {
                        SpellArray[0] = 5;
                        SpellArray[2] = 3;
                    }
                    if (Level >= 8)
                    {
                        AbilityScoreIncreases += 1;
                        _traits.Add(new Trait("Land's Stride",
                            StringResources.SR.GetString("LandsStrideDes"),
                            StringResources.SR.GetString("LandsStrideAbbrev"), true));
                    }
                    if (Level >= 9)
                    {
                        SpellArray[0] = 6;
                        SpellArray[3] = 2;
                        ProficiencyBonus = 4;
                    }
                    if (Level >= 10)
                    {
                        _traits.Add(new Trait("Hide in Plain Sight",
                            StringResources.SR.GetString("HideinPlainSightDes"),
                            StringResources.SR.GetString("HideinPlainSightAbbrev"), true));
                    }
                    if (Level >= 11)
                    {
                        SpellArray[0] = 7;
                        SpellArray[3] = 3;
                    }
                    if (Level >= 12)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 13)
                    {
                        SpellArray[0] = 8;
                        SpellArray[4] = 1;
                        ProficiencyBonus = 5;
                    }
                    if (Level >= 14)
                    {
                        _traits.Add(new Trait("Vanish",
                            StringResources.SR.GetString("VanishDes"),
                            StringResources.SR.GetString("VanishAbbrev"), true));
                    }
                    if (Level >= 15)
                    {
                        SpellArray[0] = 9;
                        SpellArray[4] = 2;
                    }
                    if (Level >= 16)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 17)
                    {
                        SpellArray[0] = 10;
                        SpellArray[4] = 3;
                        SpellArray[5] = 1;
                        ProficiencyBonus = 6;
                    }
                    if (Level >= 18)
                    {
                        _traits.Add(new Trait("Feral Senses",
                            StringResources.SR.GetString("FeralSensesDes"),
                            StringResources.SR.GetString("FeralSensesAbbrev"), true));
                    }
                    if (Level >= 19)
                    {
                        SpellArray[0] = 11;
                        SpellArray[5] = 2;
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 20)
                    {
                        _traits.Add(new Trait("Foe Slayer",
                            StringResources.SR.GetString("FoeSlayerDes"),
                            StringResources.SR.GetString("FoeSlayerAbbrev"), true));
                    }
                    break;
/************************----ROGUE----**************************************/
                case ClassEnum.Rogue:
                    if (Level >= 1)
                    {
                        ProficiencyBonus = 2;
                        _traits.Add(new Trait("Expertise",
                            StringResources.SR.GetString("ExpertiseRogue"),
                            StringResources.SR.GetString("ExpertiseRogue"), false));
                        _traits.Add(new Trait("Sneak Attack",
                            StringResources.SR.GetString("SneakAttackDes"),
                            string.Format(StringResources.SR.GetString("SneakAttackAbbrev"), "1d6"), true));
                        _traits.Add(new Trait("Thieves' Cant",
                            StringResources.SR.GetString("ThievesCant"),
                            StringResources.SR.GetString("ThievesCant"), false));
                    }
                    if (Level >= 2)
                    {
                        _traits.Add(new Trait("Cunning Action",
                            StringResources.SR.GetString("CunningActionDes"),
                            StringResources.SR.GetString("CunningActionAbbrev"), true));
                    }
                    if (Level >= 3)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Sneak Attack");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SneakAttackAbbrev"), "2d6");
                    }
                    if (Level >= 4)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 5)
                    {
                        ProficiencyBonus = 3;
                        var index = _traits.FindIndex(p => p.Header == "Sneak Attack");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SneakAttackAbbrev"), "3d6");
                        _traits.Add(new Trait("Uncanny Dodge",
                            StringResources.SR.GetString("UncannyDodgeDes"),
                            StringResources.SR.GetString("UncannyDodgeAbbrev"), true));
                    }
                    if (Level >= 6)
                    {

                    }
                    if (Level >= 7)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Sneak Attack");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SneakAttackAbbrev"), "4d6");
                        _traits.Add(new Trait("Evasion",
                            StringResources.SR.GetString("EvasionRogueDes"),
                            StringResources.SR.GetString("EvasionAbbrev"), true));
                    }
                    if (Level >= 8)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 9)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Sneak Attack");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SneakAttackAbbrev"), "5d6");
                        ProficiencyBonus = 4;
                    }
                    if (Level >= 10)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 11)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Sneak Attack");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SneakAttackAbbrev"), "6d6");
                        _traits.Add(new Trait("Reliable Talent",
                            StringResources.SR.GetString("ReliableTalentDes"),
                            StringResources.SR.GetString("ReliableTalentAbbrev"), true));
                    }
                    if (Level >= 12)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 13)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Sneak Attack");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SneakAttackAbbrev"), "7d6");
                        ProficiencyBonus = 5;
                    }
                    if (Level >= 14)
                    {
                        _traits.Add(new Trait("Blindsense",
                            StringResources.SR.GetString("BlindSenseDes"),
                            StringResources.SR.GetString("BlindSenseAbbrev"), true));
                    }
                    if (Level >= 15)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Sneak Attack");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SneakAttackAbbrev"), "8d6");
                        _traits.Add(new Trait("Slippery Mind",
                            StringResources.SR.GetString("SlipperyMind"),
                            StringResources.SR.GetString("SlipperyMind"), false));
                    }
                    if (Level >= 16)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 17)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Sneak Attack");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SneakAttackAbbrev"), "9d6");
                        ProficiencyBonus = 6;
                    }
                    if (Level >= 18)
                    {
                        _traits.Add(new Trait("Elusive",
                            StringResources.SR.GetString("ElusiveDes"),
                            StringResources.SR.GetString("ElusiveAbbrev"), true));
                    }
                    if (Level >= 19)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Sneak Attack");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SneakAttackAbbrev"), "10d6");
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 20)
                    {
                        _traits.Add(new Trait("Stroke of Luck",
                            StringResources.SR.GetString("StrokeofLuckDes"),
                            StringResources.SR.GetString("StrokeofLuckAbbrev"), true));
                    }
                    break;
/************************----SORCERER----**************************************/
                case ClassEnum.Sorcerer:
                    if (Level >= 1)
                    {
                        ProficiencyBonus = 2;
                        SpellArray = new int[11];
                        SpellArray[0] = 4;
                        SpellArray[1] = 2;
                        SpellArray[2] = 2;
                    }
                    if (Level >= 2)
                    {
                        SpellArray[1] = 3;
                        SpellArray[2] = 3;
                        _traits.Add(new Trait("Font of Magic",
                            StringResources.SR.GetString("FontofMagic"),
                            StringResources.SR.GetString("FontofMagic"), false));
                        _traits.Add(new Trait("Sorcery Points",
                            StringResources.SR.GetString("SorceryPointsDes"),
                            string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), 2),true));
                        _traits.Add(new Trait("Flexible Casting",
                            StringResources.SR.GetString("FlexibleCastingDes"),
                            StringResources.SR.GetString("FlexibleCastingAbbrev"), true));
                    }
                    if (Level >= 3)
                    {
                        SpellArray[0] = 4;
                        SpellArray[1] = 4;
                        SpellArray[2] = 4;
                        SpellArray[3] = 2;
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "3");
                        _traits.Add(new Trait("Metamagic",
                            StringResources.SR.GetString("Metamagic"),
                            StringResources.SR.GetString("Metamagic"), false));
                        ClassChoices.Add(new ClassChoice(ClassChoicesEnum.SorcererMetamagic, lvl));
                    }
                    if (Level >= 4)
                    {
                        SpellArray[0] = 5;
                        SpellArray[1] = 5;
                        SpellArray[3] = 3;
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "4");
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 5)
                    {
                        SpellArray[0] = 5;
                        SpellArray[1] = 6;
                        SpellArray[2] = 4;
                        SpellArray[3] = 3;
                        SpellArray[4] = 2;
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "5");
                        ProficiencyBonus = 3;
                    }
                    if (Level >= 6)
                    {
                        SpellArray[0] = 5;
                        SpellArray[1] = 7;
                        SpellArray[4] = 3;
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "6");
                    }
                    if (Level >= 7)
                    {
                        SpellArray[1] = 8;
                        SpellArray[5] = 1;
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "7");
                    }
                    if (Level >= 8)
                    {
                        SpellArray[1] = 9;
                        SpellArray[5] = 2;
                        AbilityScoreIncreases += 1;
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "8");
                    }
                    if (Level >= 9)
                    {
                        SpellArray[1] = 10;
                        SpellArray[5] = 3;
                        SpellArray[6] = 1;
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "9");
                        ProficiencyBonus = 4;
                    }
                    if (Level >= 10)
                    {
                        SpellArray[0] = 6;
                        SpellArray[1] = 11;
                        SpellArray[6] = 2;
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "10");
                        var itemToRemove = ClassChoices.Single(r => r.EnumType == ClassChoicesEnum.SorcererMetamagic);
                        ClassChoices.Remove(itemToRemove);
                        ClassChoices.Add(new ClassChoice(ClassChoicesEnum.SorcererMetamagic, lvl));
                    }
                    if (Level >= 11)
                    {
                        SpellArray[1] = 12;
                        SpellArray[7] = 1;
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "11");
                    }
                    if (Level >= 12)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "12");
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 13)
                    {
                        SpellArray[1] = 13;
                        SpellArray[8] = 1;
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "13");
                        ProficiencyBonus = 5;
                    }
                    if (Level >= 14)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "14");
                    }
                    if (Level >= 15)
                    {
                        SpellArray[1] = 14;
                        SpellArray[9] = 1;
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "15");
                    }
                    if (Level >= 16)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "16");
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 17)
                    {
                        SpellArray[1] = 15;
                        SpellArray[10] = 1;
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "17");
                        ProficiencyBonus = 6;
                        var itemToRemove = ClassChoices.Single(r => r.EnumType == ClassChoicesEnum.SorcererMetamagic);
                        ClassChoices.Remove(itemToRemove);
                        ClassChoices.Add(new ClassChoice(ClassChoicesEnum.SorcererMetamagic, lvl));
                    }
                    if (Level >= 18)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "18");
                    }
                    if (Level >= 19)
                    {
                        SpellArray[7] = 2;
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "19");
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 20)
                    {
                        SpellArray[8] = 2;
                        var index = _traits.FindIndex(p => p.Header == "Sorcery Points");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("SorceryPointsAbbrev"), "20");
                        _traits.Add(new Trait("Sorcerous Restoration",
                            StringResources.SR.GetString("SorcerousRestorationDes"),
                            StringResources.SR.GetString("SorcerousRestorationAbbrev"), true));
                    }
                    break;
/************************----WARLOCK----**************************************/
                case ClassEnum.Warlock:
                    if (Level >= 1)
                    {
                        ProficiencyBonus = 2;
                        SpellArray = new int[4];
                        SpellArray[0] = 2;
                        SpellArray[1] = 2;
                        SpellArray[2] = 1;
                        _traits.Add(new Trait("Otherworldly Patron",
                            StringResources.SR.GetString("OtherworldlyPatron"),
                            StringResources.SR.GetString("OtherworldlyPatron"), false));
                    }
                    if (Level >= 2)
                    {
                        SpellArray[1] = 3;
                        SpellArray[2] = 2;
                        SpellArray[3] = 2;
                        _traits.Add(new Trait("Eldritch Invocations",
                            StringResources.SR.GetString("EldritchInvocations"),
                            StringResources.SR.GetString("EldritchInvocations"), false));
                        _traits.Add(new Trait("Pact Boon",
                            StringResources.SR.GetString("PactBoon"),
                            StringResources.SR.GetString("PactBoon"), false));
                        ClassChoices.Add(new ClassChoice(ClassChoicesEnum.PactBoon, lvl));
                    }
                    if (Level >= 3)
                    {
                        SpellArray[1] = 4;
                    }
                    if (Level >= 4)
                    {
                        SpellArray[0] = 3;
                        SpellArray[1] = 5;
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 5)
                    {
                        SpellArray[1] = 6;
                        SpellArray[3] = 3;
                        ProficiencyBonus = 3;
                    }
                    if (Level >= 6)
                    {
                        SpellArray[1] = 7;
                    }
                    if (Level >= 7)
                    {
                        SpellArray[3] = 4;
                        SpellArray[1] = 8;
                    }
                    if (Level >= 8)
                    {
                        SpellArray[1] = 9;
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 9)
                    {
                        SpellArray[1] = 10;
                        SpellArray[3] = 5;
                        ProficiencyBonus = 4;
                    }
                    if (Level >= 10)
                    {
                        SpellArray[0] = 4;
                    }
                    if (Level >= 11)
                    {
                        SpellArray[1] = 11;
                        SpellArray[2] = 3;
                        _traits.Add(new Trait("Mystic Arcanum",
                            StringResources.SR.GetString("MysticArcanumDes"),
                            string.Format(StringResources.SR.GetString("MysticArcanumAbbrev"),"","","",""), false));
                    }
                    if (Level >= 12)
                    {
                        SpellArray[3] = 6;
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 13)
                    {
                        SpellArray[1] = 12;
                        ProficiencyBonus = 5;
                    }
                    if (Level >= 15)
                    {
                        SpellArray[1] = 13;
                        SpellArray[3] = 7;
                    }
                    if (Level >= 16)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 17)
                    {
                        SpellArray[1] = 14;
                        SpellArray[2] = 4;
                        ProficiencyBonus = 6;
                    }
                    if (Level >= 18)
                    {
                        SpellArray[3] = 8;
                    }
                    if (Level >= 19)
                    {
                        SpellArray[1] = 15;
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 20)
                    {
                        _traits.Add(new Trait("Eldritch Master",
                            StringResources.SR.GetString("EldritchMasterDes"),
                            StringResources.SR.GetString("EldritchMasterAbbrev"), true));
                    }
                    break;
/************************----WIZARD----**************************************/
                case ClassEnum.Wizard:
                    if (Level >= 1)
                    {
                        ProficiencyBonus = 2;
                        SpellArray = new int[11];
                        SpellArray[0] = 4;
                        SpellArray[1] = 2;
                        SpellArray[2] = 2;
                        _traits.Add(new Trait("Arcane Recovery",
                            StringResources.SR.GetString("ArcaneRecoveryDes"),
                            StringResources.SR.GetString("ArcaneRecoveryAbbrev"), true));
                    }
                    if (Level >= 2)
                    {
                        SpellArray[1] = 3;
                        SpellArray[2] = 3;
                        _traits.Add(new Trait("Arcane Tradition",
                            StringResources.SR.GetString("ArcaneTradition"),
                            StringResources.SR.GetString("ArcaneTradition"), false));
                    }
                    if (Level >= 3)
                    {
                        SpellArray[0] = 4;
                        SpellArray[1] = 4;
                        SpellArray[2] = 4;
                        SpellArray[3] = 2;
                    }
                    if (Level >= 4)
                    {
                        SpellArray[0] = 5;
                        SpellArray[1] = 5;
                        SpellArray[3] = 3;
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 5)
                    {
                        SpellArray[0] = 5;
                        SpellArray[1] = 6;
                        SpellArray[2] = 4;
                        SpellArray[3] = 3;
                        SpellArray[4] = 2;
                        ProficiencyBonus = 3;
                    }
                    if (Level >= 6)
                    {
                        SpellArray[0] = 5;
                        SpellArray[1] = 7;
                        SpellArray[4] = 3;
                    }
                    if (Level >= 7)
                    {
                        SpellArray[1] = 8;
                        SpellArray[5] = 1;
                    }
                    if (Level >= 8)
                    {
                        SpellArray[1] = 9;
                        SpellArray[5] = 2;
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 9)
                    {
                        SpellArray[1] = 10;
                        SpellArray[5] = 3;
                        SpellArray[6] = 1;
                        ProficiencyBonus = 4;
                    }
                    if (Level >= 10)
                    {
                        SpellArray[0] = 6;
                        SpellArray[1] = 11;
                        SpellArray[6] = 2;
                    }
                    if (Level >= 11)
                    {
                        SpellArray[1] = 12;
                        SpellArray[7] = 1;
                    }
                    if (Level >= 12)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 13)
                    {
                        SpellArray[1] = 13;
                        SpellArray[8] = 1;
                        ProficiencyBonus = 5;
                    }
                    if (Level >= 14)
                    {

                    }
                    if (Level >= 15)
                    {
                        SpellArray[1] = 14;
                        SpellArray[9] = 1;
                    }
                    if (Level >= 16)
                    {
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 17)
                    {
                        SpellArray[1] = 15;
                        SpellArray[10] = 1;
                        ProficiencyBonus = 6;
                    }
                    if (Level >= 18)
                    {
                        _traits.Add(new Trait("Spell Mastery",
                            StringResources.SR.GetString("SpellMasteryDes"),
                            StringResources.SR.GetString("SpellMasteryAbbrev"), true));
                    }
                    if (Level >= 19)
                    {
                        SpellArray[7] = 2;
                        AbilityScoreIncreases += 1;
                    }
                    if (Level >= 20)
                    {
                        SpellArray[8] = 2;
                        _traits.Add(new Trait("Signature Spells",
                            StringResources.SR.GetString("SignatureSpellsDes"),
                            StringResources.SR.GetString("SignatureSpellsAbbrev"), true));
                    }
                    break;
            }
        }

        public int GetHitDie()
        {
            return _hitDie;
        }

        public List<Proficiency> GetSkillChoices()
        {
            return _skillChoices;
        }

        public List<Trait> GetClassTraits()
        {
            return _traits;
        }

        public List<Proficiency> GetProficiencies()
        {
            return _proficiencies;
        }

        public List<SubclassEnum> GetAllowedSubclasses()
        {
            return _allowedSubclasses;
        }

        public string GetClassSubheader()
        {
            switch (EnumType)
            {
                case ClassEnum.Barbarian:
                    return
                        "Barbarians are primal warriors who prefer to charge in and engage foes in melee combat. They draw their power from a deep well of rage and are able to take incredible amounts of punishment without stopping";
                case ClassEnum.Bard:
                    return 
                        "An ideal Bard is one who has traveled the bredth of the land, learning magical secrets and lore. They are incredibly versitile, and an asset to any group they travel with.";
                case ClassEnum.Cleric:
                    return
                        "Clerics are intermediaries between the mortal world and the distant planes of the gods. As varied as the gods they serve, they strive to embody the handiwork of their deities.";
                case ClassEnum.Druid:
                    return 
                        "Druids revere nature above all, and gain their spells and magical powers either from the force of nature itself or from a nature diety. They posess powers of wild nature, animals or elemental forces.";
                case ClassEnum.Fighter:
                    return
                        "Questing knights, conquering overlords, royal champions, elite foot soldiers, hardened mercenaries, and bandit kings—as fighters, they all share an unparalleled mastery with weapons and armor, and a thorough knowledge of the skills of combat.";
                case ClassEnum.Monk:
                    return 
                        "The Monks are a mysterious bunch. Their studies and meditations have allowed them to channel a mystical energy called Ki, allowing them to perfom near superhuman feats.";
                case ClassEnum.Paladin:
                    return 
                        "Knights, Crusaders, Champions of their diety. Paladins embody the life of an adventurer, persuing their chosen cause with zeal and furvor; channeling the powers of their diety to achieve their goals.";
                case ClassEnum.Ranger:
                    return
                        "Far from the bustle of cities and towns, amid the dense-packed trees of trackless forests and across wide and empty plains, rangers keep their unending watch.";
                case ClassEnum.Rogue:
                    return
                        "Rogues rely on skill, stealth, and their foes’ vulnerabilities to get the upper hand in any situation. They have a knack for finding the solution to just about any problem, bringing resourcefulness and versatility to their adventuring parties.";
                case ClassEnum.Sorcerer:
                    return 
                        "Sorcerers wield raw magical power even from their youth. They are able to manipulate the mysterious powers of magic through sheer force of will.";
                case ClassEnum.Warlock:
                    return 
                        "A Warlock draws their power from the pact they have made with an otherworldly being. Often dark and sometimes devious, these patrons grant spectacular magic abilities. ";
                case ClassEnum.Wizard:
                    return "Drawing on the subtle weave of magic that permeates the cosmos, wizards cast spells of explosive fire, arcing lightning, subtle deception, and brute-force mind control.";
            }
            return null;
        }

        public void GetClassDetails(StackPanel classDetailsStackPanel)
        {
            // Print Class information
            var sp = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(5,10,0,0)};
            sp.Children.Add(new TextBlock
            {
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Text = "Hit Points: "
            });
            sp.Children.Add(new TextBlock
            {
                FontSize = 20,
                Text = "1d"+this._hitDie + " per level",
                Margin = new Thickness(5, 0, 0, 0),
                TextWrapping = TextWrapping.Wrap,
            });
            classDetailsStackPanel.Children.Add(sp);

            sp = new StackPanel { Orientation = Orientation.Vertical, Margin = new Thickness(5, 10, 0, 0) };
            sp.Children.Add(new TextBlock
            {
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Text = "Saving Throws: "
            });
            foreach (var item in _savingThrows)
            {
                sp.Children.Add(new TextBlock
                {
                    FontSize = 20,
                    Text = item.ToString() + " ",
                    Margin = new Thickness(5, 0, 0, 0),
                    MaxWidth = 400,
                    TextWrapping = TextWrapping.Wrap,
                });
            }
            classDetailsStackPanel.Children.Add(sp);

            sp = new StackPanel { Orientation = Orientation.Vertical, Margin = new Thickness(5, 10, 0, 10) };
            sp.Children.Add(new TextBlock
            {
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Text = "Proficiencies: "
            });
            foreach (var item in _proficiencies)
            {
                sp.Children.Add(new TextBlock
                {
                    FontSize = 20,
                    Text = item.ToString(),
                    Margin = new Thickness(5, 0, 0, 0),
                    MaxWidth = 380,
                    TextWrapping = TextWrapping.Wrap,
                });
            }
            classDetailsStackPanel.Children.Add(sp);

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
                classDetailsStackPanel.Children.Add(sp);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
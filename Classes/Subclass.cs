using System.Collections.Generic;
using System.Linq;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using _5ECharacterCreator.Enums;
using _5ECharacterCreator.HelperStructs;

namespace _5ECharacterCreator
{
    public class Subclass
    {
        // Subclass parameters override class parameters
        public int Level { get; set; }
        public string Name { get; }
        private List<Trait> _traits = new List<Trait>();
        public SubclassEnum EnumType;
        public string Subheader;
        public List<Spell> Spells = new List<Spell>();
        public bool Spellcaster = false;
        public List<ClassChoice> ChoiceList = new List<ClassChoice>();
        public List<Proficiency> SubclassProficiencies = new List<Proficiency>();
        public int[] SpellArray = new int[11];

        public Subclass(SubclassEnum item, int level)
        {
            EnumType = item;
            switch (item)
            {
                // Barbarian Primal Paths
                case SubclassEnum.Berserker:
                    Name = "Berserker";
                    Subheader = StringResources.SR.GetString("BerserkerSubheader");
                    break;
                case SubclassEnum.TotemWarrior:
                    Name = "Totem Warrior";
                    Subheader = StringResources.SR.GetString("TotemWarriorSubheader");
                    break;
                // Bardic Colleges
                case SubclassEnum.Lore:
                    Name = "College of Lore";
                    Subheader = StringResources.SR.GetString("LoreSubheader");
                    break;
                case SubclassEnum.Valor:
                    Name = "College of Valor";
                    Subheader = StringResources.SR.GetString("ValorSubheader");
                    break;
                // Cleric Divine Domains
                case SubclassEnum.Knowledge:
                    Name = "Knowledge";
                    Subheader = StringResources.SR.GetString("KnowledgeSubheader");
                    break;
                case SubclassEnum.Life:
                    Name = "Life";
                    Subheader = StringResources.SR.GetString("LifeSubheader");
                    break;
                case SubclassEnum.Light:
                    Name = "Light";
                    Subheader = StringResources.SR.GetString("LightSubheader");
                    break;
                case SubclassEnum.Nature:
                    Name = "Nature";
                    Subheader = StringResources.SR.GetString("NatureSubheader");
                    break;
                case SubclassEnum.Tempest:
                    Name = "Tempest";
                    Subheader = StringResources.SR.GetString("TempestSubheader");
                    break;
                case SubclassEnum.Trickery:
                    Name = "Trickery";
                    Subheader = StringResources.SR.GetString("TrickerySubheader");
                    break;
                case SubclassEnum.War:
                    Name = "War";
                    Subheader = StringResources.SR.GetString("WarSubheader");
                    break;
                // Druid Circles
                case SubclassEnum.Land:
                    Name = "Circle of the Land";
                    Subheader = StringResources.SR.GetString("CircleofLandSubheader");
                    break;
                case SubclassEnum.Moon:
                    Name = "Circle of the Moon";
                    Subheader = StringResources.SR.GetString("CircleofMoonSubheader");
                    break;
                // Fighter Archetypes
                case SubclassEnum.Champion:
                    Name = "Champion";
                    Subheader = StringResources.SR.GetString("ChampionSubheader");
                    break;
                case SubclassEnum.BattleMaster:
                    Name = "Battle Master";
                    Subheader = StringResources.SR.GetString("BattleMasterSubheader");
                    break;
                case SubclassEnum.EldritchKnight:
                    Name = "Eldritch Knight";
                    Subheader = StringResources.SR.GetString("EldritchKnightSubheader");
                    break;
                // Monk Monastic Traditions
                case SubclassEnum.OpenHand:
                    Name = "Way of the Open Hand";
                    Subheader = StringResources.SR.GetString("OpenHandSubheader");
                    break;
                case SubclassEnum.Shadow:
                    Name = "Way of the Shadow";
                    Subheader = StringResources.SR.GetString("WayofShadowSubheader");
                    break;
                case SubclassEnum.FourElements:
                    Name = "Way of the Four Elements";
                    Subheader = StringResources.SR.GetString("FourElementsSubheader");
                    break;
                // Paladin Sacred Oaths
                case SubclassEnum.Devotion:
                    Name = "Oath of Devotion";
                    Subheader = StringResources.SR.GetString("DevotionSubheader");
                    break;
                case SubclassEnum.Ancients:
                    Name = "Oath of Ancients";
                    Subheader = StringResources.SR.GetString("AncientsSubheader");
                    break;
                case SubclassEnum.Vengeance:
                    Name = "Oath of Vengeance";
                    Subheader = StringResources.SR.GetString("VengeanceSubheader");
                    break;
                // Ranger Archetypes
                case SubclassEnum.Hunter:
                    Name = "Hunter";
                    Subheader = StringResources.SR.GetString("HunterSubheader");
                    break;
                case SubclassEnum.BeastMaster:
                    Name = "Beast Master";
                    Subheader = StringResources.SR.GetString("BeastMasterSubheader");
                    break;
                // Rogue Archetypes
                case SubclassEnum.Thief:
                    Name = "Thief";
                    Subheader = StringResources.SR.GetString("ThiefSubheader");
                    break;
                case SubclassEnum.Assassin:
                    Name = "Assassin";
                    Subheader = StringResources.SR.GetString("AssassinSubheader");
                    break;
                case SubclassEnum.ArcaneTrickster:
                    Name = "Arcane Trickster";
                    Subheader = StringResources.SR.GetString("ArcaneTricksterSubheader");
                    break;
                // Sorcerer Origins
                case SubclassEnum.DraconicBloodline:
                    Name = "Draconic Bloodline";
                    Subheader = StringResources.SR.GetString("DraconicBloodlineSubheader");
                    break;
                case SubclassEnum.WildMagic:
                    Name = "Wild Magic";
                    Subheader = StringResources.SR.GetString("WildMagicSubheader");
                    break;
                // Warlock Patrons
                case SubclassEnum.Archfey:
                    Name = "Arch Fey";
                    Subheader = StringResources.SR.GetString("ArchfeySubheader");
                    break;
                case SubclassEnum.Fiend:
                    Name = "Fiend";
                    Subheader = StringResources.SR.GetString("FiendSubheader");
                    break;
                case SubclassEnum.GreatOldOne:
                    Name = "Great Old One";
                    Subheader = StringResources.SR.GetString("GreatOldOneSubheader");
                    break;
                // Wizard Arcane Traditions
                case SubclassEnum.Abjuration:
                    Name = "Abjuration";
                    Subheader = StringResources.SR.GetString("AbjurationSubheader");
                    break;
                case SubclassEnum.Conjuration:
                    Name = "Conjuration";
                    Subheader = StringResources.SR.GetString("ConjurationSubheader");
                    break;
                case SubclassEnum.Enchantment:
                    Name = "Enchantment";
                    Subheader = StringResources.SR.GetString("EnchantmentSubheader");
                    break;
                case SubclassEnum.Divination:
                    Name = "Divination";
                    Subheader = StringResources.SR.GetString("DivinationSubheader");
                    break;
                case SubclassEnum.Evocation:
                    Name = "Evocation";
                    Subheader = StringResources.SR.GetString("EvocationSubheader");
                    break;
                case SubclassEnum.Illusion:
                    Name = "Illusion";
                    Subheader = StringResources.SR.GetString("IllusionSubheader");
                    break;
                case SubclassEnum.Necromancy:
                    Name = "Necromancy";
                    Subheader = StringResources.SR.GetString("NecromancySubheader");
                    break;
                case SubclassEnum.Transmuation:
                    Name = "Transmutation";
                    Subheader = StringResources.SR.GetString("TransmutationSubheader");
                    break;
            }

            SetLevelSpecifics(level);
        }

        public void SetLevelSpecifics(int lvl)
        {
            Level = lvl;
            _traits = new List<Trait>();
            switch (EnumType)
            {
                // Barbarian Primal Paths
                case SubclassEnum.Berserker:
                    if (lvl >= 3)
                    {
                        _traits.Add(new Trait("Frenzy",
                            StringResources.SR.GetString("FrenzyDes"),
                            StringResources.SR.GetString("FrenzyAbbrev"), true));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Mindless Rage",
                            StringResources.SR.GetString("MindlessRageDes"),
                            StringResources.SR.GetString("MindlessRageAbbrev"), true));
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Intimidating Presence",
                            StringResources.SR.GetString("IntimidatingPresenceDes"),
                            StringResources.SR.GetString("IntimidatingPresenceAbbrev"), true));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Retaliation",
                            StringResources.SR.GetString("RetaliationDes"),
                            StringResources.SR.GetString("RetaliationAbbrev"), true));
                    }
                    break;
                case SubclassEnum.TotemWarrior:
                    if (lvl >= 3)
                    {
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.TotemSpirit, lvl));
                        _traits.Add(new Trait("Totem Spirit",
                            StringResources.SR.GetString("TotemSpirit"),
                            StringResources.SR.GetString("TotemSpirit"), false));
                    }
                    if (lvl >= 6)
                    {
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.AspectoftheBeast, lvl));
                        _traits.Add(new Trait("Aspect of the Beast",
                            StringResources.SR.GetString("AspectoftheBeast"),
                            StringResources.SR.GetString("AspectoftheBeast"), false));
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Spirit Walker",
                            StringResources.SR.GetString("SpiritWalkerDes"),
                            StringResources.SR.GetString("SpiritWalkerAbbrev"), true));
                    }
                    if (lvl >= 14)
                    {
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.TotemicAttunement, lvl));
                        _traits.Add(new Trait("Totemic Attunement",
                            StringResources.SR.GetString("TotemicAttunement"),
                            StringResources.SR.GetString("TotemicAttunement"), false));
                    }
                    break;
                // Bardic Colleges
                case SubclassEnum.Lore:
                    if (lvl >= 3)
                    {
                        _traits.Add(new Trait("Cutting Words",
                            StringResources.SR.GetString("CuttingWordsDes"),
                            StringResources.SR.GetString("CuttingWordsAbbrev"), true));
                        _traits.Add(new Trait("Bonus Proficiencies",
                            StringResources.SR.GetString("BonusProficiencies"),
                            StringResources.SR.GetString("BonusProficiencies"), false));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Additional Magical Secrets",
                            StringResources.SR.GetString("AdditionalMagicalSecrets"),
                            StringResources.SR.GetString("AdditionalMagicalSecrets"), false));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Peerless Skill",
                            StringResources.SR.GetString("PeerlessSkillDes"),
                            StringResources.SR.GetString("PeerlessSkillAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Valor:
                    if (lvl >= 3)
                    {
                        _traits.Add(new Trait("Combat Inspiration",
                            StringResources.SR.GetString("CombatInspirationDes"),
                            StringResources.SR.GetString("CombatInspirationAbbrev"), true));
                        _traits.Add(new Trait("Bonus Proficiencies",
                            StringResources.SR.GetString("BonusProficienciesValor"),
                            StringResources.SR.GetString("BonusProficienciesValor"), false));
                        SubclassProficiencies.AddRange(new []
                        {
                            Proficiency.MediumArmor,
                            Proficiency.Shields,
                            Proficiency.MartialWeapon,
                        });
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Extra Attack",
                            StringResources.SR.GetString("ExtraAttackBardValor"),
                            string.Format(StringResources.SR.GetString("ExtraAttackAbbrev"), 2), false));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Battle Magic",
                            StringResources.SR.GetString("BattleMagicDes"),
                            StringResources.SR.GetString("BattleMagicAbbrev"), true));
                    }
                    break;
                // Cleric Divine Domains
                case SubclassEnum.Knowledge:
                    _traits.Add(new Trait("Knowledge Domain Spells",
                        StringResources.SR.GetString("KnowledgeDomainSpells"),
                        StringResources.SR.GetString("KnowledgeDomainSpells"), false));
                    _traits.Add(new Trait("Blessings of Knowledge",
                        StringResources.SR.GetString("BlessingsofKnowledge"),
                        StringResources.SR.GetString("BlessingsofKnowledge"), false));
                    Spells.Add(MainPage.AllSpells.CreateSpell("Command"));
                    Spells.Add(MainPage.AllSpells.CreateSpell("Identify"));
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Knowledge of the Ages",
                            StringResources.SR.GetString("KnowledgeoftheAgesDes"),
                            StringResources.SR.GetString("KnowledgeoftheAgesAbbrev"), true));
                    }
                    if (lvl >= 3)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Augury"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Suggestion"));
                    }
                    if (lvl >= 5)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Nondetection"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Speak with Dead"));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Read Thoughts",
                            StringResources.SR.GetString("ReadThoughtsDes"),
                            StringResources.SR.GetString("ReadThoughtsAbbrev"), true));
                    }
                    if (lvl >= 7)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Arcane Eye"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Confusion"));
                    }
                    if (lvl >= 8)
                    {
                        _traits.Add(new Trait("Potent Spellcasting",
                            StringResources.SR.GetString("PotentSpellcastingDes"),
                            StringResources.SR.GetString("PotentSpellcastingAbbrev"), true));
                    }
                    if (lvl >= 9)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Legend Lore"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Scrying"));
                    }
                    if (lvl >= 17)
                    {
                        _traits.Add(new Trait("Visions of the Past",
                            StringResources.SR.GetString("VisionsofthePastDes"),
                            StringResources.SR.GetString("VisionsofthePastAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Life:
                    _traits.Add(new Trait("Life Domain Spells",
                        StringResources.SR.GetString("LifeDomainSpells"),
                        StringResources.SR.GetString("LifeDomainSpells"), false));
                    _traits.Add(new Trait("Bonus Proficiency",
                        StringResources.SR.GetString("ClericLifeBonusProficiency"),
                        StringResources.SR.GetString("ClericLifeBonusProficiency"), false));
                    SubclassProficiencies.Add(Proficiency.HeavyArmor);
                    _traits.Add(new Trait("Disciple of Life",
                        StringResources.SR.GetString("DiscipleofLifeDes"),
                        StringResources.SR.GetString("DiscipleofLifeAbbrev"), true));
                    Spells.Add(MainPage.AllSpells.CreateSpell("Bless"));
                    Spells.Add(MainPage.AllSpells.CreateSpell("Cure Wounds"));
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Preserve Life",
                            StringResources.SR.GetString("PreserveLifeDes"),
                            StringResources.SR.GetString("PreserveLifeAbbrev"), true));
                    }
                    if (lvl >= 3)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Lesser Restoration"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Spiritual Weapon"));
                    }
                    if (lvl >= 5)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Beacon of Hope"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Revivify"));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Blessed Healer",
                            StringResources.SR.GetString("BlessedHealerDes"),
                            StringResources.SR.GetString("BlessedHealerAbbrev"), true));
                    }
                    if (lvl >= 7)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Death Ward"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Guardian of Faith"));
                    }
                    if (lvl >= 8)
                    {
                        _traits.Add(new Trait("Divine Strike",
                            StringResources.SR.GetString("DivineStrikeDes"),
                            string.Format(StringResources.SR.GetString("DivineStrikeAbbrev"), "1d8"), true));
                    }
                    if (lvl >= 9)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Mass Cure Wounds"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Raise Dead"));
                    }
                    if (lvl >= 14)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Divine Strike");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("DivineStrikeAbbrev"), "2d8");
                    }
                    if (lvl >= 17)
                    {
                        _traits.Add(new Trait("Supreme Healing",
                            StringResources.SR.GetString("SupremeHealingDes"),
                            StringResources.SR.GetString("SupremeHealingAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Light:
                    _traits.Add(new Trait("Light Domain Spells",
                        StringResources.SR.GetString("LightDomainSpells"),
                        StringResources.SR.GetString("LightDomainSpells"), false));
                    _traits.Add(new Trait("Bonus Cantrip",
                        StringResources.SR.GetString("ClericLightBonusCantrip"),
                        StringResources.SR.GetString("ClericLightBonusCantrip"), false));
                    _traits.Add(new Trait("Warding Flare",
                        StringResources.SR.GetString("WardingFlareDes"),
                        StringResources.SR.GetString("WardingFlareAbbrev"), true));
                    Spells.Add(MainPage.AllSpells.CreateSpell("Light"));
                    Spells.Add(MainPage.AllSpells.CreateSpell("Burning Hands"));
                    Spells.Add(MainPage.AllSpells.CreateSpell("Faerie Fire"));
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Radiance of the Dawn",
                            StringResources.SR.GetString("RadianceoftheDawnDes"),
                            StringResources.SR.GetString("RadianceoftheDawnAbbrev"), true));
                    }
                    if (lvl >= 3)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Flaming Sphere"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Scorching Ray"));
                    }
                    if (lvl >= 5)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Daylight"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Fireball"));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Improved Flare",
                            StringResources.SR.GetString("ImprovedFlareDes"),
                            StringResources.SR.GetString("ImprovedFlareAbbrev"), true));
                    }
                    if (lvl >= 7)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Guardian of Faith"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Wall of Fire"));
                    }
                    if (lvl >= 8)
                    {
                        _traits.Add(new Trait("Potent Spellcasting",
                            StringResources.SR.GetString("PotentSpellcastingDes"),
                            StringResources.SR.GetString("PotentSpellcastingAbbrev"), true));
                    }
                    if (lvl >= 9)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Flame Strike"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Scrying"));
                    }
                    if (lvl >= 17)
                    {
                        _traits.Add(new Trait("Corona of Light",
                            StringResources.SR.GetString("CoronaofLightDes"),
                            StringResources.SR.GetString("CoronaofLightAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Nature:
                    _traits.Add(new Trait("Nature Domain Spells",
                        StringResources.SR.GetString("NatureDomainSpells"),
                        StringResources.SR.GetString("NatureDomainSpells"), false));
                    _traits.Add(new Trait("Acolyte of Nature",
                        StringResources.SR.GetString("AcolyteofNature"),
                        StringResources.SR.GetString("AcolyteofNature"), false));
                    _traits.Add(new Trait("Bonus Proficiency",
                        StringResources.SR.GetString("ClericLifeBonusProficiency"),
                        StringResources.SR.GetString("ClericLifeBonusProficiency"), false));
                    SubclassProficiencies.Add(Proficiency.HeavyArmor);
                    Spells.Add(MainPage.AllSpells.CreateSpell("Animal Friendship"));
                    Spells.Add(MainPage.AllSpells.CreateSpell("Speak with Animals"));
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Charm Animals and Plants",
                            StringResources.SR.GetString("CharmAnimalsandPlantsDes"),
                            StringResources.SR.GetString("CharmAnimalsandPlantsAbbrev"), true));
                    }
                    if (lvl >= 3)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Barkskin"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Spike Growth"));
                    }
                    if (lvl >= 5)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Plant Growth"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Wind Wall"));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Dampen Elements",
                            StringResources.SR.GetString("DampenElementsDes"),
                            StringResources.SR.GetString("DampenElementsAbbrev"), true));
                    }
                    if (lvl >= 7)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Dominate Beast"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Grasping Vine"));
                    }
                    if (lvl >= 8)
                    {
                        _traits.Add(new Trait("Divine Strike",
                            StringResources.SR.GetString("DivineStrikeNatureDes"),
                            string.Format(StringResources.SR.GetString("DivineStrikeNatureAbbrev"), "1d8"), true));
                    }
                    if (lvl >= 9)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Insect Plague"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Tree Stride"));
                    }
                    if (lvl >= 14)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Divine Strike");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("DivineStrikeNatureAbbrev"), "2d8");
                    }
                    if (lvl >= 17)
                    {
                        _traits.Add(new Trait("Master of Nature",
                            StringResources.SR.GetString("MasterofNatureDes"),
                            StringResources.SR.GetString("MasterofNatureAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Tempest:
                    _traits.Add(new Trait("Tempest Domain Spells",
                        StringResources.SR.GetString("TempestDomainSpells"),
                        StringResources.SR.GetString("TempestDomainSpells"), false));
                    _traits.Add(new Trait("Wrath of the Storm",
                        StringResources.SR.GetString("WrathoftheStormDes"),
                        StringResources.SR.GetString("WrathoftheStormAbbrev"), true));
                    _traits.Add(new Trait("Bonus Proficiencies",
                        StringResources.SR.GetString("ClericTempestBonusProficiencies"),
                        StringResources.SR.GetString("ClericTempestBonusProficiencies"), false));
                    SubclassProficiencies.AddRange(new []
                    {
                        Proficiency.HeavyArmor,
                        Proficiency.MartialWeapon,
                    });
                    Spells.Add(MainPage.AllSpells.CreateSpell("Fog Cloud"));
                    Spells.Add(MainPage.AllSpells.CreateSpell("Thunderwave"));
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Destructive Wrath",
                            StringResources.SR.GetString("DestructiveWrathDes"),
                            StringResources.SR.GetString("DestructiveWrathAbbrev"), true));
                    }
                    if (lvl >= 3)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Gust of Wind"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Shatter"));
                    }
                    if (lvl >= 5)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Call Lightning"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Sleet Storm"));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Thunderbolt Strike",
                            StringResources.SR.GetString("ThunderboltStrikeDes"),
                            StringResources.SR.GetString("ThunderboltStrikeAbbrev"), true));
                    }
                    if (lvl >= 7)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Control Water"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Ice Storm"));
                    }
                    if (lvl >= 8)
                    {
                        _traits.Add(new Trait("Divine Strike",
                            StringResources.SR.GetString("DivineStrikeTempestDes"),
                            string.Format(StringResources.SR.GetString("DivineStrikeTempestAbbrev"), "1d8"), true));
                    }
                    if (lvl >= 9)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Insect Plague"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Tree Stride"));
                    }
                    if (lvl >= 14)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Divine Strike");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("DivineStrikeTempestAbbrev"), "2d8");
                    }
                    if (lvl >= 17)
                    {
                        _traits.Add(new Trait("Stormborn",
                            StringResources.SR.GetString("StormbornDes"),
                            StringResources.SR.GetString("StormbornAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Trickery:
                    _traits.Add(new Trait("Trickery Domain Spells",
                        StringResources.SR.GetString("TrickeryDomainSpells"),
                        StringResources.SR.GetString("TrickeryDomainSpells"), false));
                    _traits.Add(new Trait("Blessing of the Trickster",
                        StringResources.SR.GetString("BlessingoftheTricksterDes"),
                        StringResources.SR.GetString("BlessingoftheTricksterAbbrev"), true));
                    Spells.Add(MainPage.AllSpells.CreateSpell("Charm Person"));
                    Spells.Add(MainPage.AllSpells.CreateSpell("Disguise Self"));
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Invoke Duplicity",
                            StringResources.SR.GetString("InvokeDuplicityDes"),
                            StringResources.SR.GetString("InvokeDuplicityAbbrev"), true));
                    }
                    if (lvl >= 3)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Mirror Image"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Pass Without Trace"));
                    }
                    if (lvl >= 5)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Blink"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Dispel Magic"));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Cloak of Shadows",
                            StringResources.SR.GetString("CloakofShadowsDes"),
                            StringResources.SR.GetString("CloakofShadowsAbbrev"), true));
                    }
                    if (lvl >= 7)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Dimension door"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Polymorph"));
                    }
                    if (lvl >= 8)
                    {
                        _traits.Add(new Trait("Divine Strike",
                            StringResources.SR.GetString("DivineStrikeTrickeryDes"),
                            string.Format(StringResources.SR.GetString("DivineStrikeTrickeryAbbrev"), "1d8"), true));
                    }
                    if (lvl >= 9)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Dominate Person"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Modify Memory"));
                    }
                    if (lvl >= 14)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Divine Strike");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("DivineStrikeTrickeryAbbrev"), "2d8");
                    }
                    if (lvl >= 17)
                    {
                        _traits.Add(new Trait("Improved Duplicity",
                            StringResources.SR.GetString("ImprovedDuplicityDes"),
                            StringResources.SR.GetString("ImprovedDuplicityAbbrev"), true));
                    }
                    break;
                case SubclassEnum.War:
                    _traits.Add(new Trait("War Domain Spells",
                        StringResources.SR.GetString("WarDomainSpells"),
                        StringResources.SR.GetString("WarDomainSpells"), false));
                    _traits.Add(new Trait("Bonus Proficiencies",
                        StringResources.SR.GetString("ClericTempestBonusProficiencies"),
                        StringResources.SR.GetString("ClericTempestBonusProficiencies"), false));
                    SubclassProficiencies.AddRange(new[]
                    {
                        Proficiency.HeavyArmor,
                        Proficiency.MartialWeapon,
                    });
                    _traits.Add(new Trait("War Priest",
                        StringResources.SR.GetString("WarPriestDes"),
                        StringResources.SR.GetString("WarPriestAbbrev"), true));
                    Spells.Add(MainPage.AllSpells.CreateSpell("Divine Favor"));
                    Spells.Add(MainPage.AllSpells.CreateSpell("Shield of Faith"));
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Guided Strike",
                            StringResources.SR.GetString("GuidedStrikeDes"),
                            StringResources.SR.GetString("GuidedStrikeAbbrev"), true));
                    }
                    if (lvl >= 3)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Magic Weapon"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Spiritual Weapon"));
                    }
                    if (lvl >= 5)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Crusader's Mantle"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Spirit Guardians"));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("War God's Blessing",
                            StringResources.SR.GetString("WarGodsBlessingDes"),
                            StringResources.SR.GetString("WarGodsBlessingAbbrev"), true));
                    }
                    if (lvl >= 7)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Freedom of Movement"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Stoneskin"));
                    }
                    if (lvl >= 8)
                    {
                        _traits.Add(new Trait("Divine Strike",
                            StringResources.SR.GetString("DivineStrikeWarDes"),
                            string.Format(StringResources.SR.GetString("DivineStrikeWarAbbrev"), "1d8"), true));
                    }
                    if (lvl >= 9)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Flame Strike"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Hold Monster"));
                    }
                    if (lvl >= 14)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Divine Strike");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("DivineStrikeWarAbbrev"), "2d8");
                    }
                    if (lvl >= 17)
                    {
                        _traits.Add(new Trait("Avatar of Battle",
                            StringResources.SR.GetString("AvatarofBattleDes"),
                            StringResources.SR.GetString("AvatarofBattleAbbrev"), true));
                    }
                    break;
                // Druid Circles
                case SubclassEnum.Land:
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Bonus Cantrip",
                            StringResources.SR.GetString("DruidLandBonusCantrip"),
                            StringResources.SR.GetString("DruidLandBonusCantrip"), false));
                        _traits.Add(new Trait("Natural Recovery",
                            StringResources.SR.GetString("NaturalRecoveryDes"),
                            StringResources.SR.GetString("NaturalRecoveryAbbrev"), true));
                    }
                    if (lvl >= 3)
                    {
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.LandCircleSpells, lvl));
                        _traits.Add(new Trait("Druid Circle",
                            StringResources.SR.GetString("DruidCircle"),
                            StringResources.SR.GetString("DruidCircle"), false));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Land's Stride",
                            StringResources.SR.GetString("LandStrideDes"),
                            StringResources.SR.GetString("LandStrideAbbrev"), true));
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Nature's Ward",
                            StringResources.SR.GetString("NaturesWardDes"),
                            StringResources.SR.GetString("NaturesWardAbbrev"), true));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Nature's Sanctuary",
                            StringResources.SR.GetString("NaturesSanctuaryDes"),
                            StringResources.SR.GetString("NaturesSanctuaryAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Moon:
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Combat Wild Shape",
                            StringResources.SR.GetString("CombatWildShapeDes"),
                            StringResources.SR.GetString("CombatWildShapeAbbrev"), true));
                        _traits.Add(new Trait("Circle Forms",
                            StringResources.SR.GetString("CircleFormsDes"),
                            string.Format(StringResources.SR.GetString("CombatWildShapeAbbrev"), "1"), true));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Primal Strike",
                            StringResources.SR.GetString("PrimalStrikeDes"),
                            StringResources.SR.GetString("PrimalStrikeAbbrev"), true));
                        var index = _traits.FindIndex(p => p.Header == "Circle Forms");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("CircleFormsAbbrev"), "Druid Level % 3 (round down)");
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Elemental Wild Shape",
                            StringResources.SR.GetString("ElementalWildShapeDes"),
                            StringResources.SR.GetString("ElementalWildShapeAbbrev"), true));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Thousand Forms",
                            StringResources.SR.GetString("ThousandFormsDes"),
                            StringResources.SR.GetString("ThousandFormsAbbrev"), true));
                    }
                    break;
                // Fighter Archetypes
                case SubclassEnum.Champion:
                    if (lvl >= 3)
                    {
                        _traits.Add(new Trait("Improved Critical",
                            StringResources.SR.GetString("ImprovedCriticalDes"),
                            StringResources.SR.GetString("ImprovedCriticalAbbrev"), true));
                    }
                    if (lvl >= 7)
                    {
                        _traits.Add(new Trait("Remarkable Athlete",
                            StringResources.SR.GetString("RemarkableAthleteDes"),
                            StringResources.SR.GetString("RemarkableAthleteAbbrev"), true));
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Additional Fightning Style",
                            StringResources.SR.GetString("AdditionalFightingStyle"),
                            StringResources.SR.GetString("AdditionalFightingStyle"), false));
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.FighterFightingStyle, 1));
                    }
                    if (lvl >= 15)
                    {
                        _traits.Add(new Trait("Superior Critical",
                            StringResources.SR.GetString("SuperiorCriticalDes"),
                            StringResources.SR.GetString("SuperiorCriticalAbbrev"), true));
                    }
                    if (lvl >= 18)
                    {
                        _traits.Add(new Trait("Survivor",
                            StringResources.SR.GetString("SurvivorDes"),
                            StringResources.SR.GetString("SurvivorAbbrev"), true));
                    }
                    break;
                case SubclassEnum.BattleMaster:
                    if (lvl >= 3)
                    {
                        _traits.Add(new Trait("Combat Superiority",
                            StringResources.SR.GetString("CombatSuperiorityDes"),
                            string.Format(StringResources.SR.GetString("CombatSuperiorityAbbrev"), "4", "d8"), true));
                        _traits.Add(new Trait("Student of War",
                            StringResources.SR.GetString("StudentOfWar"),
                            StringResources.SR.GetString("StudentOfWar"), false));
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.CombatSuperiority, lvl));
                    }
                    if (lvl >= 7)
                    {
                        _traits.Add(new Trait("Know Your Enemy",
                            StringResources.SR.GetString("KnowYourEnemyDes"),
                            StringResources.SR.GetString("KnowYourEnemyAbbrev"), true));
                        var index = _traits.FindIndex(p => p.Header == "Combat Superiority");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("CombatSuperiorityAbbrev"), "5" , "d8");
                        var itemToRemove = ChoiceList.Single(r => r.EnumType == ClassChoicesEnum.CombatSuperiority);
                        ChoiceList.Remove(itemToRemove);
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.CombatSuperiority, lvl));
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Improved Combat Superiority",
                            StringResources.SR.GetString("ImprovedCombatSuperiority"),
                            StringResources.SR.GetString("ImprovedCombatSuperiority"), false));
                        var index = _traits.FindIndex(p => p.Header == "Combat Superiority");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("CombatSuperiorityAbbrev"), "5", "d10");
                        var itemToRemove = ChoiceList.Single(r => r.EnumType == ClassChoicesEnum.CombatSuperiority);
                        ChoiceList.Remove(itemToRemove);
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.CombatSuperiority, lvl));
                    }
                    if (lvl >= 15)
                    {
                        _traits.Add(new Trait("Relentless",
                            StringResources.SR.GetString("RelentlessDes"),
                            StringResources.SR.GetString("RelentlessAbbrev"), true));
                        var index = _traits.FindIndex(p => p.Header == "Combat Superiority");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("CombatSuperiorityAbbrev"), "6", "d10");
                        var itemToRemove = ChoiceList.Single(r => r.EnumType == ClassChoicesEnum.CombatSuperiority);
                        ChoiceList.Remove(itemToRemove);
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.CombatSuperiority, lvl));
                    }
                    if (lvl >= 18)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Combat Superiority");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("CombatSuperiorityAbbrev"), "6", "d12");
                    }
                    break;
                case SubclassEnum.EldritchKnight:
                    Spellcaster = true;
                    if (lvl >= 3)
                    {
                        _traits.Add(new Trait("Spellcasting",
                            StringResources.SR.GetString("Spellcasting"),
                            StringResources.SR.GetString("Spellcasting"), false));
                        _traits.Add(new Trait("Weapon Bond",
                            StringResources.SR.GetString("WeaponBondDes"),
                            StringResources.SR.GetString("WeaponBondAbbrev"), true));
                        SpellArray = new int[6];
                        SpellArray[0] = 2;
                        SpellArray[1] = 3;
                        SpellArray[2] = 2;
                    }
                    if (lvl >= 4)
                    {
                        SpellArray[1] = 4;
                        SpellArray[2] = 3;
                    }
                    if (lvl >= 7)
                    {
                        _traits.Add(new Trait("War Magic",
                            StringResources.SR.GetString("WarMagicDes"),
                            StringResources.SR.GetString("WarMagicAbbrev"), true));
                        SpellArray[1] = 5;
                        SpellArray[2] = 4;
                        SpellArray[3] = 2;
                    }
                    if (lvl >= 8)
                    {
                        SpellArray[1] = 6;
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Eldritch Strike",
                            StringResources.SR.GetString("EldritchStrikeDes"),
                            StringResources.SR.GetString("EldritchStrikeAbbrev"), true));
                        SpellArray[0] = 3;
                        SpellArray[1] = 7;
                        SpellArray[3] = 3;
                    }
                    if (lvl >= 11)
                    {
                        SpellArray[1] = 8;
                    }
                    if (lvl >= 13)
                    {
                        SpellArray[1] = 9;
                        SpellArray[4] = 2;
                    }
                    if (lvl >= 14)
                    {
                        SpellArray[1] = 10;
                    }
                    if (lvl >= 15)
                    {
                        _traits.Add(new Trait("Arcane Charge",
                            StringResources.SR.GetString("ArcangChargeDes"),
                            StringResources.SR.GetString("ArcangChargeAbbrev"), true));
                    }
                    if (lvl >= 16)
                    {
                        SpellArray[1] = 11;
                        SpellArray[4] = 3;
                    }
                    if (lvl >= 18)
                    {
                        _traits.Add(new Trait("Improved War Magic",
                            StringResources.SR.GetString("ImprovedWarMagicDes"),
                            StringResources.SR.GetString("ImprovedWarMagicAbbrev"), true));
                    }
                    if (lvl >= 19)
                    {
                        SpellArray[1] = 12;
                        SpellArray[5] = 1;
                    }
                    if (lvl >= 20)
                    {
                        SpellArray[1] = 13;
                    }
                    break;
                // Monk Monastic Traditions
                case SubclassEnum.OpenHand:
                    if (lvl >= 3)
                    {
                        _traits.Add(new Trait("Open Hand Technique",
                            StringResources.SR.GetString("OpenHandTechniqueDes"),
                            StringResources.SR.GetString("OpenHandTechniqueAbbrev"), true));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Wholeness of Body",
                            StringResources.SR.GetString("WholenessofBodyDes"),
                            StringResources.SR.GetString("WholenessofBodyAbbrev"), true));
                    }
                    if (lvl >= 11)
                    {
                        _traits.Add(new Trait("Tranquility",
                            StringResources.SR.GetString("TranquilityDes"),
                            StringResources.SR.GetString("TranquilityAbbrev"), true));
                    }
                    if (lvl >= 17)
                    {
                        _traits.Add(new Trait("Quivering Palm",
                            StringResources.SR.GetString("QuiveringPalmDes"),
                            StringResources.SR.GetString("QuiveringPalmAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Shadow:
                    if (lvl >= 3)
                    {
                        _traits.Add(new Trait("Shadow Arts",
                            StringResources.SR.GetString("ShadowArtsDes"),
                            StringResources.SR.GetString("ShadowArtsAbbrev"), true));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Minor Illusion"));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Shadow Step",
                            StringResources.SR.GetString("ShadowStepDes"),
                            StringResources.SR.GetString("ShadowStepAbbrev"), true));
                    }
                    if (lvl >= 11)
                    {
                        _traits.Add(new Trait("Cloak of Shadows",
                            StringResources.SR.GetString("CloakofShadowsMonkDes"),
                            StringResources.SR.GetString("CloakofShadowsMonkAbbrev"), true));
                    }
                    if (lvl >= 17)
                    {
                        _traits.Add(new Trait("Opportunist",
                            StringResources.SR.GetString("OpportunistDes"),
                            StringResources.SR.GetString("OpportunistAbbrev"), true));
                    }
                    break;
                case SubclassEnum.FourElements:
                    if (lvl >= 3)
                    {
                        _traits.Add(new Trait("Disciple of the Elements",
                            StringResources.SR.GetString("DiscipleoftheElements"),
                            StringResources.SR.GetString("DiscipleoftheElements"), false));
                        _traits.Add(new Trait("Elemental Attunement",
                            StringResources.SR.GetString("ElementalAttunementDes"),
                            StringResources.SR.GetString("ElementalAttunementAbbrev"), true));
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.DiscipleoftheElements, lvl));
                    }
                    if (lvl >= 5)
                    {
                        _traits.Add(new Trait("Empowered Diciplines",
                            StringResources.SR.GetString("EmpoweredDiciplinesDes"),
                            StringResources.SR.GetString("EmpoweredDiciplinesAbbrev"), true));
                    }
                    if (lvl >= 6)
                    {
                        var itemToRemove = ChoiceList.Single(r => r.EnumType == ClassChoicesEnum.DiscipleoftheElements);
                        ChoiceList.Remove(itemToRemove);
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.DiscipleoftheElements, lvl));
                    }
                    if (lvl >= 11)
                    {
                        var itemToRemove = ChoiceList.Single(r => r.EnumType == ClassChoicesEnum.DiscipleoftheElements);
                        ChoiceList.Remove(itemToRemove);
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.DiscipleoftheElements, lvl));
                    }
                    if (lvl >= 17)
                    {
                        var itemToRemove = ChoiceList.Single(r => r.EnumType == ClassChoicesEnum.DiscipleoftheElements);
                        ChoiceList.Remove(itemToRemove);
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.DiscipleoftheElements, lvl));
                    }
                    break;
                // Paladin Sacred Oaths
                case SubclassEnum.Devotion:
                    if (lvl >= 3)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Protection from Evil and Good"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Sanctuary"));
                        _traits.Add(new Trait("Sacred Weapon",
                            StringResources.SR.GetString("SacredWeaponDes"),
                            StringResources.SR.GetString("SacredWeaponAbbrev"), true));
                        _traits.Add(new Trait("Turn the Unholy",
                            StringResources.SR.GetString("TurntheUnholyDes"),
                            StringResources.SR.GetString("TurntheUnholyAbbrev"), true));
                    }
                    if (lvl >= 5)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Lesser Restoration"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Zone of Truth"));
                    }
                    if (lvl >= 7)
                    {
                        _traits.Add(new Trait("Aura of Devotion",
                            StringResources.SR.GetString("AuraofDevotionDes"),
                            string.Format(StringResources.SR.GetString("AuraofDevotionAbbrev"), "10"),true));
                    }
                    if (lvl >= 9)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Beacon of Hope"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Dispel Magic"));
                    }
                    if (lvl >= 13)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Freedom of Movement"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Guardian of Faith"));
                    }
                    if (lvl >= 15)
                    {
                        _traits.Add(new Trait("Purity of Spirit",
                            StringResources.SR.GetString("PurityofSpiritDes"),
                            StringResources.SR.GetString("PurityofSpiritAbbrev"), true));
                    }
                    if (lvl >= 17)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Commune"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Flame Strike"));
                    }
                    if (lvl >= 18)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Aura of Devotion");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("AuraofDevotionAbbrev"), "30");
                    }
                    if (lvl >= 20)
                    {
                        _traits.Add(new Trait("Holy Nimbus",
                            StringResources.SR.GetString("HolyNimbusDes"),
                            StringResources.SR.GetString("HolyNimbusAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Ancients:
                    if (lvl >= 3)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Ensnaring Strike"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Speak with Animals"));
                        _traits.Add(new Trait("Nature's Wrath",
                            StringResources.SR.GetString("NaturesWrathDes"),
                            StringResources.SR.GetString("NaturesWrathAbbrev"), true));
                        _traits.Add(new Trait("Turn the Faithless",
                            StringResources.SR.GetString("TurntheFaithlessDes"),
                            StringResources.SR.GetString("TurntheFaithlessAbbrev"), true));
                    }
                    if (lvl >= 5)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Misty Step"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Moonbeam"));
                    }
                    if (lvl >= 7)
                    {
                        _traits.Add(new Trait("Aura of Warding",
                            StringResources.SR.GetString("AuraofWardingDes"),
                            string.Format(StringResources.SR.GetString("AuraofWardingAbbrev"), "10"), true));
                    }
                    if (lvl >= 9)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Plant Growth"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Protection from Energy"));
                    }
                    if (lvl >= 13)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Ice Storm"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Stoneskin"));
                    }
                    if (lvl >= 15)
                    {
                        _traits.Add(new Trait("Undying Sentinel",
                            StringResources.SR.GetString("UndyingSentinelDes"),
                            StringResources.SR.GetString("UndyingSentinelAbbrev"), true));
                    }
                    if (lvl >= 17)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Commune with Nature"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Tree Stride"));
                    }
                    if (lvl >= 18)
                    {
                        var index = _traits.FindIndex(p => p.Header == "Aura of Warding");
                        _traits[index].SheetDescription = string.Format(StringResources.SR.GetString("AuraofWardingAbbrev"), "30");
                    }
                    if (lvl >= 20)
                    {
                        _traits.Add(new Trait("Elder Champion",
                            StringResources.SR.GetString("ElderChampionDes"),
                            StringResources.SR.GetString("ElderChampionAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Vengeance:
                    if (lvl >= 3)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Bane"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Hunter's Mark"));
                        _traits.Add(new Trait("Abjure Enemy",
                            StringResources.SR.GetString("AbjureEnemyDes"),
                            StringResources.SR.GetString("AbjureEnemyAbbrev"), true));
                        _traits.Add(new Trait("Vow of Enmity",
                            StringResources.SR.GetString("VowofEnmityDes"),
                            StringResources.SR.GetString("VowofEnmityAbbrev"), true));
                    }
                    if (lvl >= 5)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Misty Step"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Hold Person"));
                    }
                    if (lvl >= 7)
                    {
                        _traits.Add(new Trait("Relentless Avenger",
                            StringResources.SR.GetString("RelentlessAvengerDes"),
                            StringResources.SR.GetString("RelentlessAvengerAbbrev"), true));
                    }
                    if (lvl >= 9)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Haste"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Protection from Energy"));
                    }
                    if (lvl >= 13)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Banishment"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Dimension Door"));
                    }
                    if (lvl >= 15)
                    {
                        _traits.Add(new Trait("Soul of Vengeance",
                            StringResources.SR.GetString("SoulofVengeanceDes"),
                            StringResources.SR.GetString("SoulofVengeanceAbbrev"), true));
                    }
                    if (lvl >= 17)
                    {
                        Spells.Add(MainPage.AllSpells.CreateSpell("Hold Monster"));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Scrying"));
                    }
                    if (lvl >= 20)
                    {
                        _traits.Add(new Trait("Avenging Angel",
                            StringResources.SR.GetString("AvengingAngelDes"),
                            StringResources.SR.GetString("AvengingAngelAbbrev"), true));
                    }
                    break;
                // Ranger Archetypes
                case SubclassEnum.Hunter:
                    if (lvl >= 3)
                    {
                        _traits.Add(new Trait("Hunters Prey",
                            StringResources.SR.GetString("HuntersPrey"),
                            StringResources.SR.GetString("HuntersPrey"), false));
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.HuntersPrey, lvl));
                    }
                    if (lvl >= 7)
                    {
                        _traits.Add(new Trait("Defensive Tactics",
                            StringResources.SR.GetString("DefensiveTactics"),
                            StringResources.SR.GetString("DefensiveTactics"), false));
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.DefensiveTactics, lvl));
                    }
                    if (lvl >= 11)
                    {
                        _traits.Add(new Trait("Multiattack",
                            StringResources.SR.GetString("Multiattack"),
                            StringResources.SR.GetString("Multiattack"), false));
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.Multiattack, lvl));
                    }
                    if (lvl >= 15)
                    {
                        _traits.Add(new Trait("Superior Hunters Defense",
                            StringResources.SR.GetString("SuperiorHuntersDefense"),
                            StringResources.SR.GetString("SuperiorHuntersDefense"), false));
                        ChoiceList.Add(new ClassChoice(ClassChoicesEnum.SuperiorHuntersDefense, lvl));
                    }
                    break;
                case SubclassEnum.BeastMaster:
                    if (lvl >= 3)
                    {
                        _traits.Add(new Trait("Ranger's Companion",
                            StringResources.SR.GetString("RangerCompanionDes"),
                            StringResources.SR.GetString("RangerCompanionAbbrev"), true));
                    }
                    if (lvl >= 7)
                    {
                        _traits.Add(new Trait("Exceptional Training",
                            StringResources.SR.GetString("ExceptionalTrainingDes"),
                            StringResources.SR.GetString("ExceptionalTrainingAbbrev"), true));
                    }
                    if (lvl >= 11)
                    {
                        _traits.Add(new Trait("Bestial Fury",
                            StringResources.SR.GetString("BestialFuryDes"),
                            StringResources.SR.GetString("BestialFuryAbbrev"), true));
                    }
                    if (lvl >= 15)
                    {
                        _traits.Add(new Trait("Share Spells",
                            StringResources.SR.GetString("ShareSpellsDes"),
                            StringResources.SR.GetString("ShareSpellsAbbrev"), true));
                    }
                    break;
                // Rogue Archetypes
                case SubclassEnum.Thief:
                    if (lvl >= 3)
                    {
                        _traits.Add(new Trait("Fast Hands",
                            StringResources.SR.GetString("FastHandsDes"),
                            StringResources.SR.GetString("FastHandsAbbrev"), true));
                        _traits.Add(new Trait("Second-Story Work",
                            StringResources.SR.GetString("SecondStoryWorkDes"),
                            StringResources.SR.GetString("SecondStoryWorkAbbrev"), true));
                    }
                    if (lvl >= 9)
                    {
                        _traits.Add(new Trait("Supreme Sneak",
                            StringResources.SR.GetString("SupremeSneakDes"),
                            StringResources.SR.GetString("SupremeSneakAbbrev"), true));
                    }
                    if (lvl >= 13)
                    {
                        _traits.Add(new Trait("Use Magic Device",
                            StringResources.SR.GetString("UseMagicDeviceDes"),
                            StringResources.SR.GetString("UseMagicDeviceAbbrev"), true));
                    }
                    if (lvl >= 17)
                    {
                        _traits.Add(new Trait("Thief's Reflexes",
                            StringResources.SR.GetString("ThiefsReflexesDes"),
                            StringResources.SR.GetString("ThiefsReflexesAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Assassin:
                    if (lvl >= 3)
                    {
                        SubclassProficiencies.Add(Proficiency.DisguiseKit);
                        SubclassProficiencies.Add(Proficiency.PoisonersKit);
                        _traits.Add(new Trait("Assassin Proficiencies",
                            StringResources.SR.GetString("AssassinProficiencies"),
                            StringResources.SR.GetString("AssassinProficiencies"), false));
                        _traits.Add(new Trait("Assassinate",
                            StringResources.SR.GetString("AssassinateDes"),
                            StringResources.SR.GetString("AssassinateAbbrev"), true));
                    }
                    if (lvl >= 9)
                    {
                        _traits.Add(new Trait("InfiltrationExpertise",
                            StringResources.SR.GetString("InfiltrationExpertiseDes"),
                            StringResources.SR.GetString("InfiltrationExpertiseAbbrev"), true));
                    }
                    if (lvl >= 13)
                    {
                        _traits.Add(new Trait("Impostor",
                            StringResources.SR.GetString("ImpostorDes"),
                            StringResources.SR.GetString("ImpostorAbbrev"), true));
                    }
                    if (lvl >= 17)
                    {
                        _traits.Add(new Trait("Death Strike",
                            StringResources.SR.GetString("DeathStrikeDes"),
                            StringResources.SR.GetString("DeathStrikeAbbrev"), true));
                    }
                    break;
                case SubclassEnum.ArcaneTrickster:
                    Spellcaster = true;
                    if (lvl >= 3)
                    {
                        _traits.Add(new Trait("Mage Hand Legerdemain",
                            StringResources.SR.GetString("MageHandLegerdemainDes"),
                            StringResources.SR.GetString("MageHandLegerdemainAbbrev"), true));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Mage Hand"));
                        SpellArray = new int[6];
                        SpellArray[0] = 2;
                        SpellArray[1] = 3;
                        SpellArray[2] = 2;
                    }
                    if (lvl >= 4)
                    {
                        SpellArray[1] = 4;
                        SpellArray[2] = 3;
                    }
                    if (lvl >= 7)
                    {
                        SpellArray[1] = 5;
                        SpellArray[2] = 4;
                        SpellArray[3] = 2;
                    }
                    if (lvl >= 8)
                    {
                        SpellArray[1] = 6;
                    }
                    if (lvl >= 9)
                    {
                        _traits.Add(new Trait("Magical Ambush",
                            StringResources.SR.GetString("MagicalAmbushDes"),
                            StringResources.SR.GetString("MagicalAmbushAbbrev"), true));
                    }
                    if (lvl >= 10)
                    {
                        SpellArray[0] = 3;
                        SpellArray[1] = 7;
                        SpellArray[3] = 3;
                    }
                    if (lvl >= 11)
                    {
                        SpellArray[1] = 8;
                    }
                    if (lvl >= 13)
                    {
                        _traits.Add(new Trait("Versatile Trickster",
                            StringResources.SR.GetString("VersatileTricksterDes"),
                            StringResources.SR.GetString("VersatileTricksterAbberv"), true));
                        SpellArray[1] = 9;
                        SpellArray[4] = 2;
                    }
                    if (lvl >= 14)
                    {
                        SpellArray[1] = 10;
                    }
                    if (lvl >= 16)
                    {
                        SpellArray[1] = 11;
                        SpellArray[4] = 3;
                    }
                    if (lvl >= 17)
                    {
                        _traits.Add(new Trait("Spell Thief",
                            StringResources.SR.GetString("SpellThiefDes"),
                            StringResources.SR.GetString("SpellThiefAbbrev"), true));
                    }
                    if (lvl >= 19)
                    {
                        SpellArray[1] = 12;
                        SpellArray[5] = 1;
                    }
                    if (lvl >= 20)
                    {
                        SpellArray[1] = 13;
                    }
                    break;
                // Sorcerer Origins
                case SubclassEnum.DraconicBloodline:
                    ChoiceList.Add(new ClassChoice(ClassChoicesEnum.DraconicAncestry, lvl));
                    _traits.Add(new Trait("Dragon Ancestor",
                        StringResources.SR.GetString("DragonAncestorDes"),
                        StringResources.SR.GetString("DragonAncerstorAbbrev"), true));
                    _traits.Add(new Trait("Draconic Resilience",
                        StringResources.SR.GetString("DraconicReilience"),
                        StringResources.SR.GetString("DraconicResilience"), false));
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Elemental Affinity",
                            StringResources.SR.GetString("ElementalAffinityDes"),
                            StringResources.SR.GetString("ElementalAffinityAbbrev"), true));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Dragon Wings",
                            StringResources.SR.GetString("DragonWingsDes"),
                            StringResources.SR.GetString("DragonWingsAbbrev"), true));
                    }
                    if (lvl >= 18)
                    {
                        _traits.Add(new Trait("Draconic Presence",
                            StringResources.SR.GetString("DraconicPresenceDes"),
                            StringResources.SR.GetString("DraconicPresenceAbbrev"), true));
                    }
                    break;
                case SubclassEnum.WildMagic:
                    _traits.Add(new Trait("Wild Magic Surge",
                        StringResources.SR.GetString("WildMagicSurgeDes"),
                        StringResources.SR.GetString("WildMagicSurgeAbbrev"), true));
                    _traits.Add(new Trait("Tides of Chaos",
                        StringResources.SR.GetString("TidesofChaosDes"),
                        StringResources.SR.GetString("TidesofChaosAbbrev"), true));
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Bend Luck",
                            StringResources.SR.GetString("BendLuckDes"),
                            StringResources.SR.GetString("BendLuckAbbrev"), true));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Controlled Chaos",
                            StringResources.SR.GetString("ControlledChaosDes"),
                            StringResources.SR.GetString("ControlledChaosAbbrev"), true));
                    }
                    if (lvl >= 18)
                    {
                        _traits.Add(new Trait("Spell Bombardment",
                            StringResources.SR.GetString("SpellBombardmentDes"),
                            StringResources.SR.GetString("SpellBombardmentAbbrev"), true));
                    }
                    break;
                // Warlock Patrons
                case SubclassEnum.Archfey:
                    _traits.Add(new Trait("Fey Presence",
                        StringResources.SR.GetString("FeyPresenceDes"),
                        StringResources.SR.GetString("FeyPresenceAbbrev"), true));
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Misty Escape",
                            StringResources.SR.GetString("MistyEscapeDes"),
                            StringResources.SR.GetString("MistyEscapeAbbrev"), true));
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Beguiling Defenses",
                            StringResources.SR.GetString("BeguilingDefensesDes"),
                            StringResources.SR.GetString("BeguilingDefensesAbbrev"), true));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Dark Delirium",
                            StringResources.SR.GetString("DarkDeliriumDes"),
                            StringResources.SR.GetString("DarkDeliriumAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Fiend:
                    _traits.Add(new Trait("Dark One's Blessing",
                        StringResources.SR.GetString("DarkOnesBlessingDes"),
                        StringResources.SR.GetString("DarkOnesBlessingAbbrev"), true));
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Dark One's Own Luck",
                            StringResources.SR.GetString("DarkOnesOwnLuckDes"),
                            StringResources.SR.GetString("DarkOnesOwnLuckAbbrev"), true));
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Fiendish Resilience",
                            StringResources.SR.GetString("FiendishResilienceDes"),
                            StringResources.SR.GetString("FiendishResilienceAbbrev"), true));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Hurl Through Hell",
                            StringResources.SR.GetString("HurlThroughHellDes"),
                            StringResources.SR.GetString("HurlThroughHellAbbrev"), true));
                    }
                    break;
                case SubclassEnum.GreatOldOne:
                    _traits.Add(new Trait("Awakened Mind",
                        StringResources.SR.GetString("AwakenedMindDes"),
                        StringResources.SR.GetString("AwakenedMindAbbrev"), true));
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Entropic Ward",
                            StringResources.SR.GetString("EntropicWardDes"),
                            StringResources.SR.GetString("EntropicWardAbbrev"), true));
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Thought Shield",
                            StringResources.SR.GetString("ThoughtShieldDes"),
                            StringResources.SR.GetString("ThoughtShieldAbbrev"), true));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Create Thrall",
                            StringResources.SR.GetString("CreateThrallDes"),
                            StringResources.SR.GetString("CreateThrallAbbrev"), true));
                    }
                    break;
                // Wizard Arcane Traditions
                case SubclassEnum.Abjuration:
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Abjuration Savant",
                            StringResources.SR.GetString("AbjurationSavantDes"),
                            StringResources.SR.GetString("AbjurationSavantAbbrev"), true));
                        _traits.Add(new Trait("Arcane Ward",
                            StringResources.SR.GetString("ArcaneWardDes"),
                            StringResources.SR.GetString("ArcaneWardAbbrev"), true));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Projected Ward",
                            StringResources.SR.GetString("ProjectedWardDes"),
                            StringResources.SR.GetString("ProjectedWardAbbrev"), true));
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Improved Abjuration",
                            StringResources.SR.GetString("ImprovedAbjurationDes"),
                            StringResources.SR.GetString("ImprovedAbjurationAbbrev"), true));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Spell Resistance",
                            StringResources.SR.GetString("SpellResistanceDes"),
                            StringResources.SR.GetString("SpellResistanceAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Conjuration:
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Conjuration Savant",
                            StringResources.SR.GetString("ConjurationSavantDes"),
                            StringResources.SR.GetString("ConjurationSavantAbbrev"), true));
                        _traits.Add(new Trait("Minor Conjuration",
                            StringResources.SR.GetString("MinorConjurationDes"),
                            StringResources.SR.GetString("MinorConjurationAbbrev"), true));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Benign Transposition",
                            StringResources.SR.GetString("BenignTranspositionDes"),
                            StringResources.SR.GetString("BenignTranspositionAbbrev"), true));
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Focused Conjuration",
                            StringResources.SR.GetString("FocusedConjurationDes"),
                            StringResources.SR.GetString("FocuesConjurationAbbrev"), true));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Durable Summons",
                            StringResources.SR.GetString("DurableSummonsDes"),
                            StringResources.SR.GetString("DurableSummonsAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Enchantment:
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Enchantment Savant",
                            StringResources.SR.GetString("EnchantmentSavantDes"),
                            StringResources.SR.GetString("EnchantmentSavantAbbrev"), true));
                        _traits.Add(new Trait("Hypnotic Gaze",
                            StringResources.SR.GetString("HypnoticGazeDes"),
                            StringResources.SR.GetString("HypnoticGazeAbbrev"), true));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Instinctive Charm",
                            StringResources.SR.GetString("InstinctiveCharmDes"),
                            StringResources.SR.GetString("InstinctiveCharmAbbrev"), true));
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Split Enchantment",
                            StringResources.SR.GetString("SplitEnchantmentDes"),
                            StringResources.SR.GetString("SplitEnchantmentAbbrev"), true));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Alter Memories",
                            StringResources.SR.GetString("AlterMemoriesDes"),
                            StringResources.SR.GetString("AlterMemoriesAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Divination:
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Divination Savant",
                            StringResources.SR.GetString("DivinationSavantDes"),
                            StringResources.SR.GetString("DivinationSavantAbbrev"), true));
                        _traits.Add(new Trait("Portent",
                            StringResources.SR.GetString("PortentDes"),
                            StringResources.SR.GetString("PortentAbbrev"), true));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Expert Divination",
                            StringResources.SR.GetString("ExpertDivinationDes"),
                            StringResources.SR.GetString("ExpertDivinationAbbrev"), true));
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("The Third Eye",
                            StringResources.SR.GetString("TheThirdEyeDes"),
                            StringResources.SR.GetString("TheThirdEyeAbbrev"), true));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Greater Portent",
                            StringResources.SR.GetString("GreaterPortentDes"),
                            StringResources.SR.GetString("GreaterPortentAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Evocation:
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Evocation Savant",
                            StringResources.SR.GetString("EvocationSavantDes"),
                            StringResources.SR.GetString("EvocationSavantAbbrev"), true));
                        _traits.Add(new Trait("Sculpt Spells",
                            StringResources.SR.GetString("SculptSpellsDes"),
                            StringResources.SR.GetString("SculptSpellsAbbrev"), true));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Potent Cantrip",
                            StringResources.SR.GetString("PotentCantripDes"),
                            StringResources.SR.GetString("PotentCantripAbbrev"), true));
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Empowered Evocation",
                            StringResources.SR.GetString("EmpoweredEvocationDes"),
                            StringResources.SR.GetString("EmpoweredEvocationAbbrev"), true));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Overchannel",
                            StringResources.SR.GetString("OverchannelDes"),
                            StringResources.SR.GetString("OverchannelAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Illusion:
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Illusion Savant",
                            StringResources.SR.GetString("IllusionSavantDes"),
                            StringResources.SR.GetString("IllusionSavantAbbrev"), true));
                        _traits.Add(new Trait("Improved Minor Illusion",
                            StringResources.SR.GetString("ImprovedMinorIllusionDes"),
                            StringResources.SR.GetString("ImprovedMinorIllusionAbbrev"), true));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Minor Illusion"));

                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Malleable Illusions",
                            StringResources.SR.GetString("MalleableIllusionsDes"),
                            StringResources.SR.GetString("MalleableIllusionsAbbrev"), true));
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Illusory Self",
                            StringResources.SR.GetString("IllusorySelfDes"),
                            StringResources.SR.GetString("IllusorySelfAbbrev"), true));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Illusory Reality",
                            StringResources.SR.GetString("IllusoryRealityDes"),
                            StringResources.SR.GetString("IllusoryRealityAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Necromancy:
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Necromancy Savant",
                            StringResources.SR.GetString("NecromancySavantDes"),
                            StringResources.SR.GetString("NecromancySavantAbbrev"), true));
                        _traits.Add(new Trait("Grim Harvest",
                            StringResources.SR.GetString("GrimHarvestDes"),
                            StringResources.SR.GetString("GrimHarvestAbbrev"), true));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Undead Thralls",
                            StringResources.SR.GetString("UndeadThrallsDes"),
                            StringResources.SR.GetString("UndeadThrallsAbbrev"), true));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Animate Dead"));
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Inured to Undeath",
                            StringResources.SR.GetString("InuredtoUndeathDes"),
                            StringResources.SR.GetString("InuuredtoUndeathAbbrev"), true));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Command Undead",
                            StringResources.SR.GetString("CommandUndeadDes"),
                            StringResources.SR.GetString("CommandUndeadAbbrev"), true));
                    }
                    break;
                case SubclassEnum.Transmuation:
                    if (lvl >= 2)
                    {
                        _traits.Add(new Trait("Transmutation Savant",
                            StringResources.SR.GetString("NecromancySavantDes"),
                            StringResources.SR.GetString("NecromancySavantAbbrev"), true));
                        _traits.Add(new Trait("Minor Alchemy",
                            StringResources.SR.GetString("MinorAlchemyDes"),
                            StringResources.SR.GetString("MinorAlchemyAbbrev"), true));
                    }
                    if (lvl >= 6)
                    {
                        _traits.Add(new Trait("Transmuter's Stone",
                            StringResources.SR.GetString("TransmutersStoneDes"),
                            StringResources.SR.GetString("TransmutersStoneAbbrev"), true));
                    }
                    if (lvl >= 10)
                    {
                        _traits.Add(new Trait("Shapechanger",
                            StringResources.SR.GetString("ShapechangerDes"),
                            StringResources.SR.GetString("ShapechangerAbbrev"), true));
                        Spells.Add(MainPage.AllSpells.CreateSpell("Polymorph"));
                    }
                    if (lvl >= 14)
                    {
                        _traits.Add(new Trait("Master Transmuter",
                            StringResources.SR.GetString("MasterTransmuterDes"),
                            StringResources.SR.GetString("MasterTransmuterAbbrev"), true));
                    }
                    break;
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public string GetSubclassSubheader()
        {
            return Subheader;
        }

        public void GetClassDetails(StackPanel classDetailsStackPanel)
        {
            // Print Class information
            var sp = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(5, 10, 0, 0) };

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
    }
}
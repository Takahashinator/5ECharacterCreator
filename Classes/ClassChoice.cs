using System.Collections.Generic;
using _5ECharacterCreator.Enums;
using _5ECharacterCreator.HelperStructs;

namespace _5ECharacterCreator
{
    public class ClassChoice
    {
        public Trait Choice = null;
        public List<Trait> Choices = new List<Trait>();
        public readonly int Level;
        public ClassChoicesEnum EnumType;
        public int ItemstoChoose = 1;
        public string Header = "";

        public ClassChoice(ClassChoicesEnum scc, int lvl)
        {
            Level = lvl;
            EnumType = scc;

            switch (scc)
            {
                case ClassChoicesEnum.TotemSpirit:
                    Header = "Totem Spirit";
                    Choices.Add(new Trait("Bear",
                        StringResources.SR.GetString("TSBearDes"),
                        StringResources.SR.GetString("TSBearAbbrev"), true));
                    Choices.Add(new Trait("Eagle",
                        StringResources.SR.GetString("TSEagleDes"),
                        StringResources.SR.GetString("TSEagleAbbrev"), true));
                    Choices.Add(new Trait("Wolf",
                        StringResources.SR.GetString("TSWolfDes"),
                        StringResources.SR.GetString("TSWolfAbbrev"), true));
                    break;
                case ClassChoicesEnum.AspectoftheBeast:
                    Header = "Aspect of the Beast";
                    Choices.Add(new Trait("Bear",
                        StringResources.SR.GetString("AbBearDes"),
                        StringResources.SR.GetString("ABBearAbbrev"), true));
                    Choices.Add(new Trait("Eagle",
                        StringResources.SR.GetString("ABEagleDes"),
                        StringResources.SR.GetString("ABEagleAbbrev"), true));
                    Choices.Add(new Trait("Wolf",
                        StringResources.SR.GetString("ABWolfDes"),
                        StringResources.SR.GetString("ABWolfAbbrev"), true));
                    break;
                case ClassChoicesEnum.TotemicAttunement:
                    Header = "Totemic Attunement";
                    Choices.Add(new Trait("Bear",
                        StringResources.SR.GetString("TABearDes"),
                        StringResources.SR.GetString("TABearAbbrev"), true));
                    Choices.Add(new Trait("Eagle",
                        StringResources.SR.GetString("TAEagleDes"),
                        StringResources.SR.GetString("TAEagleAbbrev"), true));
                    Choices.Add(new Trait("Wolf",
                        StringResources.SR.GetString("TAWolfDes"),
                        StringResources.SR.GetString("TAWolfAbbrev"), true));
                    break;
                // Battle Master
                case ClassChoicesEnum.CombatSuperiority:
                    Header = "Combat Superiority";
                    if (Level >= 3)
                        ItemstoChoose = 3;
                    if (Level >= 7)
                        ItemstoChoose = 5;
                    if (Level >= 10)
                        ItemstoChoose = 7;
                    if (Level >= 15)
                        ItemstoChoose = 9;

                    Choices.Add(new Trait("Commander's Strike",
                        StringResources.SR.GetString("CommandersStrikeDes"),
                        StringResources.SR.GetString("CommandersStrikeAbbrev"), true));
                    Choices.Add(new Trait("Disarming Attack",
                        StringResources.SR.GetString("DisarmingAttackDes"),
                        StringResources.SR.GetString("DisarmingAttackAbbrev"), true));
                    Choices.Add(new Trait("Distracting Strike",
                        StringResources.SR.GetString("DistractingStrikeDes"),
                        StringResources.SR.GetString("DistractingStrikeAbbrev"), true));
                    Choices.Add(new Trait("Evasive Footwork",
                        StringResources.SR.GetString("EvasiveFootworkDes"),
                        StringResources.SR.GetString("EvasiveFootworkAbbrev"), true));
                    Choices.Add(new Trait("Feinting Attack",
                        StringResources.SR.GetString("FeintingAttackDes"),
                        StringResources.SR.GetString("FeintingAttackAbbrev"), true));
                    Choices.Add(new Trait("Goading Attack",
                        StringResources.SR.GetString("GoadingAttackDes"),
                        StringResources.SR.GetString("GoadingAttackAbbrev"), true));
                    Choices.Add(new Trait("Lunging Attack",
                        StringResources.SR.GetString("LungingAttackDes"),
                        StringResources.SR.GetString("LungingAttackAbbrev"), true));
                    Choices.Add(new Trait("Maneuvering Attack",
                        StringResources.SR.GetString("ManeuveringAttackDes"),
                        StringResources.SR.GetString("ManeuveringAttackAbbrev"), true));
                    Choices.Add(new Trait("Menacing Attack",
                        StringResources.SR.GetString("MenacingAttackDes"),
                        StringResources.SR.GetString("MenacingAttackAbbrve"), true));
                    Choices.Add(new Trait("Parry",
                        StringResources.SR.GetString("ParryDes"),
                        StringResources.SR.GetString("ParryAbbrev"), true));
                    Choices.Add(new Trait("Precision Attack",
                        StringResources.SR.GetString("PrecisionAttackDes"),
                        StringResources.SR.GetString("PrecisionAttackAbbrev"), true));
                    Choices.Add(new Trait("Pushing Attack",
                        StringResources.SR.GetString("PushingAttackDes"),
                        StringResources.SR.GetString("PushingAttackAbbrev"), true));
                    Choices.Add(new Trait("Rally",
                        StringResources.SR.GetString("RallyDes"),
                        StringResources.SR.GetString("RallyAbbrev"), true));
                    Choices.Add(new Trait("Riposte",
                        StringResources.SR.GetString("RiposteDes"),
                        StringResources.SR.GetString("RiposteAbbrev"), true));
                    Choices.Add(new Trait("Sweeping Attack",
                        StringResources.SR.GetString("SweepingAttackDes"),
                        StringResources.SR.GetString("SweepingAttackAbbrev"), true));
                    Choices.Add(new Trait("Trip Attack",
                        StringResources.SR.GetString("TripAttackDes"),
                        StringResources.SR.GetString("TripAttackAbbrev"), true));
                    break;
                // Four Elements
                case ClassChoicesEnum.DiscipleoftheElements:
                    Header = "Disciple of the Elements";
                    ItemstoChoose = 1;
                    if (Level >= 6)
                    {
                        ItemstoChoose = 2;
                        Choices.Add(new Trait("Clench of the North Wind",
                            StringResources.SR.GetString("ClenchoftheNorthWind"),
                            StringResources.SR.GetString("ClenchoftheNorthWind"), true));
                        Choices.Add(new Trait("Gong of the Summit",
                            StringResources.SR.GetString("GongoftheSummit"),
                            StringResources.SR.GetString("GongoftheSummit"), true));
                    }
                    if (Level >= 11)
                    {
                        ItemstoChoose = 3;
                        Choices.Add(new Trait("Flames of the Phoenix",
                            StringResources.SR.GetString("FlamesofthePhoenix"),
                            StringResources.SR.GetString("FlamesofthePhoenix"), true));
                        Choices.Add(new Trait("Mist Stance",
                            StringResources.SR.GetString("MistStance"),
                            StringResources.SR.GetString("MistStance"), true));
                        Choices.Add(new Trait("Ride the Wind",
                            StringResources.SR.GetString("RidetheWind"),
                            StringResources.SR.GetString("RidetheWind"), true));
                    }
                    if (Level >= 17)
                    {
                        ItemstoChoose = 4;
                        Choices.Add(new Trait("Breath of Winter",
                            StringResources.SR.GetString("BreathofWinter"),
                            StringResources.SR.GetString("BreathofWinter"), true));
                        Choices.Add(new Trait("Eternal Mountain Defense",
                            StringResources.SR.GetString("EternalMountainDefense"),
                            StringResources.SR.GetString("EternalMountainDefense"), true));
                        Choices.Add(new Trait("River of Hungry Flame",
                            StringResources.SR.GetString("RiverofHungryFlame"),
                            StringResources.SR.GetString("RiverofHungryFlame"), true));
                        Choices.Add(new Trait("Wave of Rolling Earth",
                            StringResources.SR.GetString("WaveofRollingEarth"),
                            StringResources.SR.GetString("WaveofRollingEarth"), true));
                    }
                    Choices.Add(new Trait("Fangs of the Fire Snake",
                        StringResources.SR.GetString("FangsoftheFireSnakeDes"),
                        StringResources.SR.GetString("FangsoftheFireSnakeAbbrev"), true));
                    Choices.Add(new Trait("Fist of Four Thunders",
                        StringResources.SR.GetString("FistofFourThunders"),
                        StringResources.SR.GetString("FistofFourThunders"), true));
                    Choices.Add(new Trait("Fist of Unbroken Air",
                        StringResources.SR.GetString("FistofUnbrokenAirDes"),
                        StringResources.SR.GetString("FistofUnbrokenAirAbbrev"), true));
                    Choices.Add(new Trait("Rush of the Gale Spirits",
                        StringResources.SR.GetString("RushoftheGaleSpirits"),
                        StringResources.SR.GetString("RushoftheGaleSpirits"), true));
                    Choices.Add(new Trait("Shape the Flowing River",
                        StringResources.SR.GetString("ShapetheFlowingRiverDes"),
                        StringResources.SR.GetString("ShapetheFlowingRiverAbbrev"), true));
                    Choices.Add(new Trait("Sweeping Cinder Strike",
                        StringResources.SR.GetString("SweepingCinderStrike"),
                        StringResources.SR.GetString("SweepingCinderStrike"), true));
                    Choices.Add(new Trait("Water Whip",
                        StringResources.SR.GetString("WaterWhipDes"),
                        StringResources.SR.GetString("WaterWhipAbbrev"), true));
                    break;
                // Hunter
                case ClassChoicesEnum.HuntersPrey:
                    Header = "Hunters Prey";
                    Choices.Add(new Trait("Colossus Slayer",
                        StringResources.SR.GetString("ColossusSlayerDes"),
                        StringResources.SR.GetString("ColossusSlayerAbbrev"), true));
                    Choices.Add(new Trait("Giant Killer",
                        StringResources.SR.GetString("GiantKillerDes"),
                        StringResources.SR.GetString("GiantKillerAbbrev"), true));
                    Choices.Add(new Trait("Horde Breaker",
                        StringResources.SR.GetString("HordeBreakerDes"),
                        StringResources.SR.GetString("HordeBreakerAbbrev"), true));
                    break;
                case ClassChoicesEnum.DefensiveTactics:
                    Header = "Defensive Tactics";
                    Choices.Add(new Trait("Escape the Horde",
                        StringResources.SR.GetString("EscapetheHorde"),
                        StringResources.SR.GetString("EscapetheHorde"), true));
                    Choices.Add(new Trait("Multiattack Defense",
                        StringResources.SR.GetString("MultiattackDefenseDes"),
                        StringResources.SR.GetString("MultiattackDefenseAbbrev"), true));
                    Choices.Add(new Trait("Steel Will",
                        StringResources.SR.GetString("SteelWill"),
                        StringResources.SR.GetString("SteelWill"), true));
                    break;
                case ClassChoicesEnum.Multiattack:
                    Header = "Multiattack";
                    Choices.Add(new Trait("Volley",
                        StringResources.SR.GetString("VolleyDes"),
                        StringResources.SR.GetString("VolleyAbbrev"), true));
                    Choices.Add(new Trait("Whirlwind Attack",
                        StringResources.SR.GetString("WhirlwindAttackDes"),
                        StringResources.SR.GetString("WhirlwindAttackAbbrev"), true));
                    break;
                case ClassChoicesEnum.SuperiorHuntersDefense:
                    Header = "Superior Hunters Defense";
                    Choices.Add(new Trait("Evasion",
                        StringResources.SR.GetString("EvasionHDDes"),
                        StringResources.SR.GetString("EvasionHDAbbrev"), true));
                    Choices.Add(new Trait("Stand Against the Tide",
                        StringResources.SR.GetString("StandAgainsttheTideDes"),
                        StringResources.SR.GetString("StandAgansttheTideAbbrev"), true));
                    Choices.Add(new Trait("Uncanny Dodge",
                        StringResources.SR.GetString("UncannyDodgeHDDes"),
                        StringResources.SR.GetString("UncannyDodgeHDAbbrev"), true));
                    break;
                // Draconic Bloodline
                case ClassChoicesEnum.DraconicAncestry:
                    Header = "Draconic Ancestry";
                    Choices.Add(new Trait("Black",
                        "Your draconic damage type is Acid",
                        "Your draconic damage type is Acid", true));
                    Choices.Add(new Trait("Blue",
                        "Your draconic damage type is Lightning",
                        "Your draconic damage type is Lightning", true));
                    Choices.Add(new Trait("Brass",
                        "Your draconic damage type is Fire",
                        "Your draconic damage type is Fire", true));
                    Choices.Add(new Trait("Bronze",
                        "Your draconic damage type is Lightning",
                        "Your draconic damage type is Lightning", true));
                    Choices.Add(new Trait("Copper",
                        "Your draconic damage type is Acid",
                        "Your draconic damage type is Acid", true));
                    Choices.Add(new Trait("Gold",
                        "Your draconic damage type is Fire",
                        "Your draconic damage type is Fire", true));
                    Choices.Add(new Trait("Green",
                        "Your draconic damage type is Poision",
                        "Your draconic damage type is Poision", true));
                    Choices.Add(new Trait("Red",
                        "Your draconic damage type is Fire",
                        "Your draconic damage type is Fire", true));
                    Choices.Add(new Trait("Silver",
                        "Your draconic damage type is Cold",
                        "Your draconic damage type is Cold", true));
                    Choices.Add(new Trait("White",
                        "Your draconic damage type is Cold",
                        "Your draconic damage type is Cold", true));
                    break;
                case ClassChoicesEnum.LandCircleSpells:
                    Header = "Druidic Circle";
                    Choices.Add(new Trait("Arctic Druid",
                        StringResources.SR.GetString("ArcticDruidDes"),
                        StringResources.SR.GetString("ArcticDruidAbbrev"), true));
                    Choices.Add(new Trait("Coastal Druid",
                        StringResources.SR.GetString("CoastDruidDes"),
                        StringResources.SR.GetString("CoastDruidAbbrev"), true));
                    Choices.Add(new Trait("Desert Druid",
                        StringResources.SR.GetString("DesertDruidDes"),
                        StringResources.SR.GetString("DesertDruidAbbrev"), true));
                    Choices.Add(new Trait("Forest Druid",
                        StringResources.SR.GetString("ForestDruidDes"),
                        StringResources.SR.GetString("ForestDruidAbbrev"), true));
                    Choices.Add(new Trait("Grassland Druid",
                        StringResources.SR.GetString("GrasslandDruidDes"),
                        StringResources.SR.GetString("GrasslandDruidAbbrev"), true));
                    Choices.Add(new Trait("Mountain Druid",
                        StringResources.SR.GetString("MountainDruidDes"),
                        StringResources.SR.GetString("MountainDruidAbbrev"), true));
                    Choices.Add(new Trait("Swamp Druid",
                        StringResources.SR.GetString("SwampDruidDes"),
                        StringResources.SR.GetString("SwampDruidAbbrev"), true));
                    Choices.Add(new Trait("Underdark Druid",
                        StringResources.SR.GetString("UnderdarkDruidDes"),
                        StringResources.SR.GetString("UnderdarkDruidAbbrev"), true));
                    break;
                case ClassChoicesEnum.FighterFightingStyle:
                    Header = "Fighter Fighting Style";
                    Choices.Add(new Trait("Archery",
                        StringResources.SR.GetString("Archery"),
                        StringResources.SR.GetString("Archery"), false));
                    Choices.Add(new Trait("Defense",
                        StringResources.SR.GetString("Defense"),
                        StringResources.SR.GetString("Defense"), false));
                    Choices.Add(new Trait("Dueling",
                        StringResources.SR.GetString("Dueling"),
                        StringResources.SR.GetString("Dueling"), false));
                    Choices.Add(new Trait("Great Weapon Fighting",
                        StringResources.SR.GetString("GreatWeaponFightingDes"),
                        StringResources.SR.GetString("GreatWeaponFightingAbbrev"), true));
                    Choices.Add(new Trait("Protection",
                        StringResources.SR.GetString("ProtectionDes"),
                        StringResources.SR.GetString("ProtectionAbbrev"), true));
                    Choices.Add(new Trait("Two Weapon Fighting",
                        StringResources.SR.GetString("TwoWeaponFightingDes"),
                        StringResources.SR.GetString("TwoWeaponFightingDes"), true));
                    break;
                case ClassChoicesEnum.RangerFightingStyle:
                    Header = "Ranger Fighting Style";
                    Choices.Add(new Trait("Archery",
                        StringResources.SR.GetString("Archery"),
                        StringResources.SR.GetString("Archery"), false));
                    Choices.Add(new Trait("Defense",
                        StringResources.SR.GetString("Defense"),
                        StringResources.SR.GetString("Defense"), false));
                    Choices.Add(new Trait("Dueling",
                        StringResources.SR.GetString("Dueling"),
                        StringResources.SR.GetString("Dueling"), false));
                    Choices.Add(new Trait("Two Weapon Fighting",
                        StringResources.SR.GetString("TwoWeaponFightingDes"),
                        StringResources.SR.GetString("TwoWeaponFightingDes"), true));
                    break;
                case ClassChoicesEnum.PaladinFightingStyle:
                    Header = "Paladin Fighting Style";
                    Choices.Add(new Trait("Defense",
                        StringResources.SR.GetString("Defense"),
                        StringResources.SR.GetString("Defense"), false));
                    Choices.Add(new Trait("Dueling",
                        StringResources.SR.GetString("Dueling"),
                        StringResources.SR.GetString("Dueling"), false));
                    Choices.Add(new Trait("Great Weapon Fighting",
                        StringResources.SR.GetString("GreatWeaponFightingDes"),
                        StringResources.SR.GetString("GreatWeaponFightingAbbrev"), true));
                    Choices.Add(new Trait("Protection",
                        StringResources.SR.GetString("ProtectionDes"),
                        StringResources.SR.GetString("ProtectionAbbrev"), true));
                    break;
                case ClassChoicesEnum.SorcererMetamagic:
                    Header = "Sorcerer Metamagic";
                    if (lvl >= 3)
                        ItemstoChoose = 2;
                    if (lvl >= 10)
                        ItemstoChoose = 3;
                    if (lvl >= 17)
                        ItemstoChoose = 4;

                    Choices.Add(new Trait("Careful Spell",
                        StringResources.SR.GetString("CarefulSpellDes"),
                        StringResources.SR.GetString("CarefullSpellAbbrev"), true));
                    Choices.Add(new Trait("Distant Spell",
                        StringResources.SR.GetString("DistantSpellDes"),
                        StringResources.SR.GetString("DistantSpellAbbrev"), true));
                    Choices.Add(new Trait("Empowered Spell",
                        StringResources.SR.GetString("EmpoweredSpellDes"),
                        StringResources.SR.GetString("EmpoweredSpellAbbrev"), true));
                    Choices.Add(new Trait("Extended Spell",
                        StringResources.SR.GetString("ExtendSpelDes"),
                        StringResources.SR.GetString("ExtendSpellAbbrev"), true));
                    Choices.Add(new Trait("Heightened Spell",
                        StringResources.SR.GetString("HeightenedSpellDes"),
                        StringResources.SR.GetString("HeightenedSpellAbbrev"), true));
                    Choices.Add(new Trait("Quickened Spell",
                        StringResources.SR.GetString("QuickenedSpellDes"),
                        StringResources.SR.GetString("QuickenedSpellAbbrev"), true));
                    Choices.Add(new Trait("Subtle Spell",
                        StringResources.SR.GetString("SubtleSpellDes"),
                        StringResources.SR.GetString("SubtleSpellAbbrev"), true));
                    Choices.Add(new Trait("Twinned Spell",
                        StringResources.SR.GetString("TwinnedSpellDes"),
                        StringResources.SR.GetString("TwinnedSpellAbbrev"), true));
                    break;
                case ClassChoicesEnum.PactBoon:
                    Header = "Pact Boon";
                    Choices.Add(new Trait("Pact of the Chain",
                        StringResources.SR.GetString("PactoftheChainDes"),
                        StringResources.SR.GetString("PactoftheChainAbbrev"), true));
                    Choices.Add(new Trait("Pact of the Blade",
                        StringResources.SR.GetString("PactoftheBladeDes"),
                        StringResources.SR.GetString("PactoftheBladeAbbrev"), true));
                    Choices.Add(new Trait("Pact of the Tome",
                        StringResources.SR.GetString("PactoftheTomeDes"),
                        StringResources.SR.GetString("PactoftheTomeAbbrev"), false));
                    break;
            }
        }
    }
}
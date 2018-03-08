using System.Collections.Generic;
using _5ECharacterCreator.Enums;
using _5ECharacterCreator.HelperStructs;

namespace _5ECharacterCreator
{
    public class Character
    {
        //public List<CharacterClass> Classes = new List<CharacterClass>();
        public CharacterClass Classes = null;
        //public List<Subclass> Subclasses = new List<Subclass>();
        public Subclass Subclasses = null;
        public Race Race;
        public Subrace Subrace;
        public string Sex;
        public Stats AbilityScore;
        public AlignmentEnum Alignment;
        public int Level;
        public int HP;
        public int AC;
        public BackgroundStruct Background;
        public List<SpellEnum> Spells = new List<SpellEnum>();
        public List<Proficiency> Proficiencies = new List<Proficiency>();
        public List<LanguageEnum> Languages = new List<LanguageEnum>();
        public List<IItem> Items = new List<IItem>();
        public int Speed;
        //public Image?
        public int Initiative;
        public string Name;
        public int XP;
        public List<Trait> Traits = new List<Trait>();
        public string Bonds;
        public string Flaws;
        public string Ideals;
        public int Age;
        public string Eyes;
        public string Hair;
        public int Weight;
        public string Height;
        public string Skin;
        public string Backstory;
        public List<string> AlliesAndOrganizations;
        public bool Spellcaster;
        public Proficiency SpellcastingAbility;
        public int SpellSaveDC;
        public int SpellAttackBonus;
        
    }
}
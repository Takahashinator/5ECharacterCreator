using _5ECharacterCreator.Enums;

namespace _5ECharacterCreator
{
    public abstract class IItem
    {
        public readonly string Name;
        public readonly int Weight;
        public readonly Proficiency Proficiency;
        public readonly bool MagicItem;
        public readonly string Description;
    }
}
namespace _5ECharacterCreator.HelperStructs
{
    public class Trait
    {
        public string FullDescription; // details of the trait
        public string SheetDescription; // Abbreviated description for the character sheet
        public string Header { get; } // One or few word header for the trait
        public bool IncludePDF;

        public Trait(string h, string full, string abbrev, bool include)
        {
            IncludePDF = include;
            Header = h;
            FullDescription = full;
            SheetDescription = abbrev;
        }
    }
}
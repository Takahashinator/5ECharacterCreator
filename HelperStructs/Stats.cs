namespace _5ECharacterCreator.HelperStructs
{
    public struct Stats
    {
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Int { get; set; }
        public int Wis { get; set; }
        public int Cha { get; set; }

        public int StrMod => (Str - 10) / 2;
        public int DexMod => (Dex - 10) / 2;
        public int ConMod => (Con - 10) / 2;
        public int IntMod => (Int - 10) / 2;
        public int WisMod => (Wis - 10) / 2;
        public int ChaMod => (Cha - 10) / 2;

        public Stats(int str, int dex, int con, int intel, int wis, int cha) : this()
        {
            Str = str;
            Dex = dex;
            Con = con;
            Int = intel;
            Wis = wis;
            Cha = cha;
        }

        public void Add(Stats s)
        {
            Str += s.Str;
            Dex += s.Dex;
            Con += s.Con;
            Int += s.Int;
            Wis += s.Wis;
            Cha += s.Cha;
        }

        public override string ToString()
        {
            var s = "";
            if (StrMod != 0)
            {
                s += "+" + StrMod + " Strength ";
            }
            if (DexMod != 0)
            {
                s += "+" + DexMod + " Dexterity ";
            }
            if (ConMod != 0)
            {
                s += "+" + ConMod + " Constitution ";
            }
            if (IntMod != 0)
            {
                s += "+" + IntMod + " Intelligence ";
            }
            if (WisMod != 0)
            {
                s += "+" + WisMod + " Wisdom ";
            }
            if (ChaMod != 0)
            {
                s += "+" + ChaMod + " Charisma ";
            }

            return s;
        }
    }
}
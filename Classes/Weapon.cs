using System.Collections.Generic;
using _5ECharacterCreator.Enums;

namespace _5ECharacterCreator
{
    public class Weapon : IItem
    {
        public new readonly string Name;
        public readonly WeaponType Type;
        public new readonly int Weight;
        public readonly bool IsMelee;
        public readonly bool Throwable;
        public readonly int NormalRange;
        public readonly int FarRange; // far range 0 = use only normal range
        public readonly string Damage;
        public readonly DamageType DamageType;
        public new readonly Proficiency Proficiency;
        public readonly List<WeaponProperty> Properties;
        public new readonly bool MagicItem;
        public new readonly string Description;

        public Weapon(WeaponType typeEnum)
        {
            Type = typeEnum;
            switch (typeEnum)
            {
                case WeaponType.Club:
                    Name = "Club";
                    Weight = 2;
                    IsMelee = true;
                    Throwable = true;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d4";
                    DamageType = DamageType.Bludgeoning;
                    Proficiency = Proficiency.SimpleWeapon;
                    Properties.Add(WeaponProperty.Light);
                    break;
                case WeaponType.Dagger:
                    Name = "Dagger";
                    Weight = 1;
                    IsMelee = true;
                    Throwable = true;
                    MagicItem = false;
                    NormalRange = 20;
                    FarRange = 60;
                    Damage = "1d4";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.SimpleWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Finesse, WeaponProperty.Light, WeaponProperty.Thrown });
                    break;
                case WeaponType.Greatclub:
                    Name = "Great Club";
                    Weight = 10;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d8";
                    DamageType = DamageType.Bludgeoning;
                    Proficiency = Proficiency.SimpleWeapon;
                    Properties.Add(WeaponProperty.TwoHanded);
                    break;
                case WeaponType.Handaxe:
                    Name = "Hand Axe";
                    Weight = 2;
                    IsMelee = true;
                    Throwable = true;
                    MagicItem = false;
                    NormalRange = 20;
                    FarRange = 60;
                    Damage = "1d6";
                    DamageType = DamageType.Slashing;
                    Proficiency = Proficiency.SimpleWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Light, WeaponProperty.Thrown });
                    break;
                case WeaponType.Javelin:
                    Name = "Javelin";
                    Weight = 2;
                    IsMelee = true;
                    Throwable = true;
                    MagicItem = false;
                    NormalRange = 30;
                    FarRange = 120;
                    Damage = "1d6";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.SimpleWeapon;
                    Properties.Add(WeaponProperty.Thrown);
                    break;
                case WeaponType.LightHammer:
                    Name = "Light Hammer";
                    Weight = 2;
                    IsMelee = true;
                    Throwable = true;
                    MagicItem = false;
                    NormalRange = 20;
                    FarRange = 60;
                    Damage = "1d4";
                    DamageType = DamageType.Bludgeoning;
                    Proficiency = Proficiency.SimpleWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Light, WeaponProperty.Thrown });
                    break;
                case WeaponType.Mace:
                    Name = "Mace";
                    Weight = 4;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d6";
                    DamageType = DamageType.Bludgeoning;
                    Proficiency = Proficiency.SimpleWeapon;
                    break;
                case WeaponType.Quarterstaff:
                    Name = "Quarterstaff";
                    Weight = 4;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d6/1d8";
                    DamageType = DamageType.Bludgeoning;
                    Proficiency = Proficiency.SimpleWeapon;
                    Properties.Add(WeaponProperty.Versatile);
                    break;
                case WeaponType.Sickle:
                    Name = "Sickle";
                    Weight = 2;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d4";
                    DamageType = DamageType.Slashing;
                    Proficiency = Proficiency.SimpleWeapon;
                    Properties.Add(WeaponProperty.Light);
                    break;
                case WeaponType.Spear:
                    Name = "Spear";
                    Weight = 3;
                    IsMelee = true;
                    Throwable = true;
                    MagicItem = false;
                    NormalRange = 20;
                    FarRange = 60;
                    Damage = "1d6/1d8";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.SimpleWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Thrown, WeaponProperty.Versatile, });
                    break;
                case WeaponType.LightCrossbow:
                    Name = "Light Crossbow";
                    Weight = 5;
                    IsMelee = false;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 80;
                    FarRange = 320;
                    Damage = "1d8";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.SimpleWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Ammunition, WeaponProperty.Loading, WeaponProperty.TwoHanded });
                    break;
                case WeaponType.Dart:
                    Name = "Dart";
                    Weight = 0;
                    IsMelee = false;
                    Throwable = true;
                    MagicItem = false;
                    NormalRange = 20;
                    FarRange = 60;
                    Damage = "1d4";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.SimpleWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Finesse, WeaponProperty.Thrown, });
                    break;
                case WeaponType.Shortbow:
                    Name = "Shortbow";
                    Weight = 2;
                    IsMelee = false;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 80;
                    FarRange = 320;
                    Damage = "1d6";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.SimpleWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Ammunition, WeaponProperty.TwoHanded, });
                    break;
                case WeaponType.Sling:
                    Name = "Sling";
                    Weight = 0;
                    IsMelee = false;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 30;
                    FarRange = 120;
                    Damage = "1d4";
                    DamageType = DamageType.Bludgeoning;
                    Proficiency = Proficiency.SimpleWeapon;
                    Properties.Add(WeaponProperty.Ammunition);
                    break;
                case WeaponType.Battleaxe:
                    Name = "Battleaxe";
                    Weight = 4;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d8/1d10";
                    DamageType = DamageType.Slashing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.Add(WeaponProperty.Versatile);
                    break;
                case WeaponType.Flail:
                    Name = "Flail";
                    Weight = 2;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d8";
                    DamageType = DamageType.Bludgeoning;
                    Proficiency = Proficiency.MartialWeapon;
                    break;
                case WeaponType.Glaive:
                    Name = "Glaive";
                    Weight = 6;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d10";
                    DamageType = DamageType.Slashing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.AddRange(new[] { WeaponProperty.TwoHanded, WeaponProperty.Heavy, WeaponProperty.Reach, });
                    break;
                case WeaponType.Greataxe:
                    Name = "Greataxe";
                    Weight = 7;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d12";
                    DamageType = DamageType.Slashing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Heavy, WeaponProperty.TwoHanded, });
                    break;
                case WeaponType.Greatsword:
                    Name = "Greatsword";
                    Weight = 6;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "2d6";
                    DamageType = DamageType.Slashing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Heavy, WeaponProperty.TwoHanded, });
                    break;
                case WeaponType.Halberd:
                    Name = "Halberd";
                    Weight = 6;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d10";
                    DamageType = DamageType.Slashing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Heavy, WeaponProperty.Reach, WeaponProperty.TwoHanded, });
                    break;
                case WeaponType.Lance:
                    Name = "Lance";
                    Weight = 6;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d12";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Reach, WeaponProperty.Special });
                    break;
                case WeaponType.Longsword:
                    Name = "Longsword";
                    Weight = 3;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d8/1d10";
                    DamageType = DamageType.Slashing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.Add(WeaponProperty.Versatile);
                    break;
                case WeaponType.Maul:
                    Name = "Maul";
                    Weight = 10;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "2d6";
                    DamageType = DamageType.Bludgeoning;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Heavy, WeaponProperty.TwoHanded, });
                    break;
                case WeaponType.Morningstar:
                    Name = "Morningstar";
                    Weight = 4;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d8";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.MartialWeapon;
                    break;
                case WeaponType.Pike:
                    Name = "Pike";
                    Weight = 18;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d10";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Heavy, WeaponProperty.TwoHanded, WeaponProperty.Reach, });
                    break;
                case WeaponType.Rapier:
                    Name = "Rapier";
                    Weight = 2;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d8";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.Add(WeaponProperty.Finesse);
                    break;
                case WeaponType.Scimitar:
                    Name = "Scimitar";
                    Weight = 3;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d6";
                    DamageType = DamageType.Slashing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Finesse, WeaponProperty.Light, });
                    break;
                case WeaponType.Shorsword:
                    Name = "Shortsword";
                    Weight = 2;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d6";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Finesse, WeaponProperty.Light, });
                    break;
                case WeaponType.Trident:
                    Name = "Trident";
                    Weight = 4;
                    IsMelee = true;
                    Throwable = true;
                    MagicItem = false;
                    NormalRange = 20;
                    FarRange = 60;
                    Damage = "1d6/1d8";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Thrown, WeaponProperty.Versatile, });
                    break;
                case WeaponType.WarPick:
                    Name = "War Pick";
                    Weight = 2;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d8";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.MartialWeapon;
                    break;
                case WeaponType.Warhammer:
                    Name = "Warhammer";
                    Weight = 2;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d8/1d10";
                    DamageType = DamageType.Bludgeoning;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.Add(WeaponProperty.Versatile);
                    break;
                case WeaponType.Whip:
                    Name = "Whip";
                    Weight = 3;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d4";
                    DamageType = DamageType.Slashing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Finesse, WeaponProperty.Reach, });
                    break;
                case WeaponType.Blowgun:
                    Name = "Blowgun";
                    Weight = 1;
                    IsMelee = false;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 25;
                    FarRange = 100;
                    Damage = "1d1";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Ammunition, WeaponProperty.Loading, });
                    break;
                case WeaponType.HandCrossbow:
                    Name = "Hand Crossbow";
                    Weight = 3;
                    IsMelee = false;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 30;
                    FarRange = 120;
                    Damage = "1d6";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Loading, WeaponProperty.Light, WeaponProperty.Ammunition, });
                    break;
                case WeaponType.HeavyCrossbow:
                    Name = "Heavy Crossbow";
                    Weight = 18;
                    IsMelee = false;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 100;
                    FarRange = 400;
                    Damage = "1d10";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Ammunition, WeaponProperty.Loading, WeaponProperty.Heavy, WeaponProperty.TwoHanded, });
                    break;
                case WeaponType.Longbow:
                    Name = "Longbow";
                    Weight = 2;
                    IsMelee = false;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 150;
                    FarRange = 600;
                    Damage = "1d8";
                    DamageType = DamageType.Piercing;
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Ammunition, WeaponProperty.Heavy, WeaponProperty.TwoHanded, });
                    break;
                case WeaponType.Net:
                    Name = "Net";
                    Weight = 3;
                    IsMelee = false;
                    Throwable = true;
                    MagicItem = false;
                    NormalRange = 5;
                    FarRange = 15;
                    Damage = "1d0";
                    Proficiency = Proficiency.MartialWeapon;
                    Properties.AddRange(new[] { WeaponProperty.Special, WeaponProperty.Thrown, });
                    break;
                case WeaponType.Unarmed:
                default:
                    Name = "Unarmed";
                    Weight = 0;
                    IsMelee = true;
                    Throwable = false;
                    MagicItem = false;
                    NormalRange = 0;
                    FarRange = 0;
                    Damage = "1d1";
                    DamageType = DamageType.Bludgeoning;
                    Proficiency = Proficiency.SimpleWeapon;
                    Properties.Add(WeaponProperty.Special);
                    break;
            }
        }
    }
}
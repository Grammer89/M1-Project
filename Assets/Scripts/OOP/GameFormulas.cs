
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using System;

[Serializable]
public static class GameFormulas
{
    public static bool HasElementAdvantage(Stats.ELEMENT attackElement, Hero defender)
    {
        if (attackElement == defender.GetWeakness() && defender.GetWeakness() != Stats.ELEMENT.NONE)
        { return true; }
        else { return false; }
    }
    public static bool HasElementDisdvantage(Stats.ELEMENT attackElement, Hero defender)
    {
        if (attackElement == defender.GetResistance() && defender.GetWeakness() != Stats.ELEMENT.NONE)
        { return true; }
        else { return false; }
    }
    public static float EvaluateElementalModifier(Stats.ELEMENT attackElement, Hero defender)
    {
        if (HasElementAdvantage(attackElement, defender) == true)
        { return 1.5f; }
        else if (HasElementDisdvantage(attackElement, defender) == true)
        { return 0.5f; }
        else { return 1f; }
    }
    public static bool HasHit(Stats attacker, Stats defender)
    {
        int HitChance = attacker.aim - defender.eva;
        int randomNumber = UnityEngine.Random.Range(0, 100);
        if (randomNumber > HitChance)
        {
            Debug.Log("MISS");
            return false;
        }
        else { return true; }
    }
    public static bool IsCrit(int critValue)
    {
        int randomNumber = UnityEngine.Random.Range(0, 100);
        if (randomNumber < critValue)
        {
            Debug.Log("CRIT");
            return true;
        }
        else { return false; }
    }

    public static int CalculateDamage(Hero attacker, Hero defender)
    {


        // For to acquire BonusStats regards the Weapon
        // We need at first get variable Weapon from the variable(Both in this case)
        // at second get BonusStat with function Getter about BonusStats;

        //Attacker Stats
        Weapon WeaponAttacker = attacker.GetWeapon();
        Stats WeaponBonusStats = WeaponAttacker.GetBonusStats();
        Stats statsAttacker = Stats.Sum(attacker.GetBaseStats(), WeaponBonusStats);

        //Defender Stats
        Weapon WeaponDefender = defender.GetWeapon();
        WeaponBonusStats = WeaponDefender.GetBonusStats();
        Stats statsDefender = Stats.Sum(defender.GetBaseStats(), WeaponBonusStats);

        //Calculate Base Damage
        float baseDamage;
        float multiplyDamage = (EvaluateElementalModifier(WeaponAttacker.GetElem(), defender));
        Weapon.DAMAGE_TYPE damageTypeAttacker = WeaponAttacker.GetDamageType();
        if (damageTypeAttacker == Weapon.DAMAGE_TYPE.PHYSICAL)
        {
            baseDamage = (statsAttacker.atk - statsDefender.def) * multiplyDamage;
        }
        else if (damageTypeAttacker == Weapon.DAMAGE_TYPE.MAGICAL)
        {
            baseDamage = (statsAttacker.atk - statsDefender.res) * multiplyDamage;
        }
        else
        {
            baseDamage = 0;
            return 0;
        }

        bool crit = IsCrit((int)baseDamage);
        if (crit == true)
        { baseDamage *= 2; }

        if (baseDamage > 0)
        { return (int)baseDamage; }
        else
        { return 0; }
    }
}

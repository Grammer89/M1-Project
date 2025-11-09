using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[Serializable]
public class Hero
{
    ////Declaration Variable
    private string name;
    private int hp;
    private Stats baseStats;
    private Stats.ELEMENT resistance;
    private Stats.ELEMENT weakness;
    private Weapon weapon;
    //Constructor

    public Hero(string name, int hp, Stats baseStats, Stats.ELEMENT resistance,
                Stats.ELEMENT weakness, Weapon weapon)
    {
        SetName(name);
        SetHp(hp);
        SetBaseStats(baseStats);
        SetResistance(resistance);
        SetWeakness(weakness);
        SetWeapon(weapon);
    }
    //Getter
    public string GetName()
    { return name; }
    public int GetHp()
    { return hp; }
    public Stats GetBaseStats()
    { return baseStats; }
    public Stats.ELEMENT GetResistance()
    { return resistance; }
    public Stats.ELEMENT GetWeakness()
    { return weakness; }
    public Weapon GetWeapon()
    { return weapon; }
    //Setter
    public void SetName(string name)
    {
        if (!string.IsNullOrEmpty(name))
        { this.name = name; }
    }
    public void SetHp(int amount)
    {
        if (amount + hp < 0)
        {
            hp = 0;
        }
        else
        {
            hp = amount + hp;
        }
    }
    public void SetBaseStats(Stats baseStats)
    { this.baseStats = baseStats; }
    public void SetResistance(Stats.ELEMENT resistance)
    { this.resistance = resistance; }
    public void SetWeakness(Stats.ELEMENT weakness)
    { this.weakness = weakness; }
    public void SetWeapon(Weapon weapon)
    { this.weapon = weapon; }

    //Functionality
    void AddHp(int amount)
    { SetHp(amount); }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            damage *= -1;
        }

        AddHp(damage);
    }
    public bool IsAlive()
    {
        if (hp > 0)
        { return true; }
        else
        { return false; }
    }
}

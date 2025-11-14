using System;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[Serializable]
public class Hero
{
    ////Declaration Variable
    [SerializeField] private string name;
    [SerializeField] private int hp;
    [SerializeField] private Stats baseStats;
    [SerializeField] private Stats.ELEMENT resistance;
    [SerializeField] private Stats.ELEMENT weakness;
    [SerializeField] private Weapon weapon;
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
        else
        { this.name = "Hero"; }
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
    {
        if (weapon != null)
        { this.weapon = weapon; }
        else
        { this.weapon.SetName("Two Hands"); }
    }

    //Functionality
    void AddHp(int amount)
    {
        SetHp(amount);
    }

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

    public bool CheckBeforeStart(Hero hero)
    {
        // Check among weakness - resistance - weapon.elem for each hero
        if (hero.GetWeakness() != Stats.ELEMENT.NONE)
        {
            if (hero.GetWeakness() == hero.GetResistance())
            {
                Debug.LogError("L'eroe " + hero.GetName() + " non può avere sia resistenza che debolezza uguali");
                return false;
            }
            Weapon weapon = hero.GetWeapon();
            if (hero.GetWeakness() == weapon.GetElem())
            {
                Debug.LogError("L'eroe " + hero.GetName() + " non può essere debole a questo elemento e mangeggiare contemporaneamente l'arma con il medesimo elemento");
                return false;
            }
            return true;
        }
        return true;
    }
}

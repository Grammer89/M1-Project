using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{
    public Hero Squall;
    public Hero Seifer;
    // Start is called before the first frame update
    void Start()
    {
        //Create First Hero
        Stats bonusStatsSquall = new Stats(50, 0, 0, 25, 0, 0, 0);
        Stats baseStatsSquall = new Stats(50, 25, 30, 25, 0, 0, 0);
        Weapon weaponSquall = new Weapon("Leonheart", Weapon.DAMAGE_TYPE.PHYSICAL, Stats.ELEMENT.FIRE, bonusStatsSquall);
        Squall = new("Squall", 720, baseStatsSquall, Stats.ELEMENT.FIRE, Stats.ELEMENT.LIGHTING, weaponSquall);
        Debug.Log("HP inizial Squall: " + Squall.GetHp());
        //Create Second Hero
        Stats bonusStatsSeifer = new Stats(35, 0, 15, 0, 0, 15, 50);
        Stats baseStatsSeifer = new Stats(45, 15, 40, 35, 20, 15, 15);
        Weapon weaponSeifer = new Weapon("Shimatsuken", Weapon.DAMAGE_TYPE.MAGICAL, Stats.ELEMENT.LIGHTING, bonusStatsSeifer);
        Seifer = new("Seifer", 850, baseStatsSeifer, Stats.ELEMENT.LIGHTING, Stats.ELEMENT.FIRE, weaponSeifer);
        Debug.Log("HP iniziali Seifer: " + Seifer.GetHp());
    }

    // Update is called once per frame
    void Update()
    {
        if ((Squall.IsAlive() == false) || (Seifer.IsAlive() == false))
        {
            return;
        }
        Fight(Squall, Seifer);
    }

    void Fight(Hero heroA, Hero heroB)
    {
        Weapon weaponHeroA = heroA.GetWeapon();
        Stats statsHeroA = Stats.Sum(heroA.GetBaseStats(), weaponHeroA.GetBonusStats());

        Weapon weaponHeroB = heroB.GetWeapon();
        Stats statsHeroB = Stats.Sum(heroB.GetBaseStats(), weaponHeroB.GetBonusStats());

        if (statsHeroA.spd > statsHeroB.spd)
        {
            FightingPhase(heroA, heroB, statsHeroA, statsHeroB, weaponHeroA);
            FightingPhase(heroB, heroA, statsHeroB, statsHeroA, weaponHeroB);
        }
        else
        {
            FightingPhase(heroB, heroA, statsHeroB, statsHeroA, weaponHeroB);
            FightingPhase(heroA, heroB, statsHeroA, statsHeroB, weaponHeroA);

        }
    }
    void FightingPhase(Hero heroA, Hero heroB,
                       Stats statsHeroA, Stats statsHeroB,
                       Weapon weaponHeroA)
    {
        //Check if the defenser is defeated
        if ( (heroB.IsAlive() == false) || (heroA.IsAlive() == false) )
        { return; }

        Debug.Log(heroA.GetName() + " attacca " + heroB.GetName());

        //Check if the attack is Hit or Miss
        bool hit = GameFormulas.HasHit(statsHeroA, statsHeroB);
        if (hit == false)
        { return; }
        //Check if defender is Weakness or Resist
        bool advantage = GameFormulas.HasElementAdvantage(weaponHeroA.GetElem(), heroB);
        if (advantage == true)
        { Debug.Log("WEAKNESS"); }
        bool disvantage = GameFormulas.HasElementDisdvantage(weaponHeroA.GetElem(), heroB);
        { Debug.Log("RESIST"); }

        //Calculate Damage
        int damage = GameFormulas.CalculateDamage(heroA, heroB);
        Debug.Log(heroA.GetName() + " ha inflitto a " + heroB.GetName() + " " + damage + " danni");

        heroB.TakeDamage(damage);
        if (heroB.IsAlive() == false)
        {
            Debug.Log(heroA.GetName() + " ha sconfitto " + heroB.GetName());
        }
    }
}

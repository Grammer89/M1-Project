using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{
    [SerializeField] private Hero Squall;
    [SerializeField] private Hero Seifer;
    private bool check;
    // Start is called before the first frame update
    void Start()
    {

        check = Squall.CheckBeforeStart(Squall);
        if (check == false)
        {
            return;
        }
        check = Seifer.CheckBeforeStart(Seifer);
        if (check == false)
        {
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (check == false)
        {
            return;
        }

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
        if ((heroB.IsAlive() == false) || (heroA.IsAlive() == false))
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
        if (advantage == true)
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

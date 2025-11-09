
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.Rendering.UI;

[Serializable]


public class Weapon
{
    //Declaration Enum
    public enum DAMAGE_TYPE
    {
        PHYSICAL = 20,
        MAGICAL = 21,
    }
    //Declaration Variable
    private string name;
    private DAMAGE_TYPE dmgType;
    private Stats.ELEMENT elem;
    private Stats bonusStats;
    //Constructor
    public Weapon(string name, DAMAGE_TYPE dmgType, Stats.ELEMENT elem, Stats bonusStats)
    {
        this.name = name;
        this.dmgType = dmgType;
        this.elem = elem;
        this.bonusStats = bonusStats;
    }

    //Getter
    public string GetName()
    { return name; }

    public DAMAGE_TYPE GetDamageType()
    { return dmgType; }

    public Stats.ELEMENT GetElem()
    { return elem; }
    public Stats GetBonusStats()
    { return bonusStats; }

    //Setter
    public void SetName(string name)
    {
        if (!string.IsNullOrEmpty(name))
        { this.name = name; }
    }

    public void SetDamageType(DAMAGE_TYPE dmgType)
    { this.dmgType = dmgType; }

    public void GetElem(Stats.ELEMENT elem)
    { this.elem = elem; }
    public void SetBonusStats(Stats bonusStats)
    { this.bonusStats = bonusStats; }


}

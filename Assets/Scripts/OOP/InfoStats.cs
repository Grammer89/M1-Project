using System;
using System.Security.Cryptography;
using UnityEngine;

[Serializable]

public struct Stats
{

    public enum ELEMENT
    {
        NONE = 0,
        FIRE = 1,
        ICE = 2,
        LIGHTING = 3,
    }

    public int atk;
    public int def;
    public int res;
    public int spd;
    public int crt;
    public int aim;
    public int eva;


    //Construct
    public Stats(int atk, int def , int res, int spd, int crt,int aim, int eva)
    {
       this.atk = atk;
       this.def = def;
       this.res = res;
       this.spd = spd;
       this.crt = crt;
       this.aim = aim;
       this.eva = eva;
    }

    //Functionality
    public static Stats Sum(Stats S1, Stats S2)
    {
        Stats S3 = new Stats();
        S3.atk = S1.atk + S2.atk;
        S3.def = S1.def + S2.def;
        S3.res = S1.res + S2.res;
        S3.spd = S1.spd + S2.spd;
        S3.crt = S1.crt + S2.crt;
        S3.aim = S1.aim + S2.aim;
        S3.eva = S1.eva + S2.eva;
        return S3;
    }


}


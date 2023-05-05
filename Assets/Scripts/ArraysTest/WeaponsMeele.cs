using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct MeleeWeapons
{

    public string m_name;
    public int m_dmg;
    public int m_lvl;
    public WEAPON_TYPE m_type;

    public MeleeWeapons(string name, int dmg, int lvl, WEAPON_TYPE wType)
    {
        m_name = name;
        m_dmg = dmg;
        m_lvl = lvl;
        m_type = wType;
    }

    public enum WEAPON_TYPE
    {
        TWOHANDED,
        SINGLE_HANDED,
        THROWABLE
    }
}

public class WeaponsMeele : MonoBehaviour
{
    bool show = true;
    public MeleeWeapons[] meleeWeapons = new MeleeWeapons[]
    {
        new MeleeWeapons("Cobalt Greatsword", 215, 2, MeleeWeapons.WEAPON_TYPE.TWOHANDED),
        new MeleeWeapons("Dage", 45, 1, MeleeWeapons.WEAPON_TYPE.THROWABLE),
        new MeleeWeapons("Steel Sword", 105, 2, MeleeWeapons.WEAPON_TYPE.SINGLE_HANDED),
        new MeleeWeapons("Ancient Warhammer", 130, 1, MeleeWeapons.WEAPON_TYPE.TWOHANDED),
        new MeleeWeapons("Rock", 10, 2, MeleeWeapons.WEAPON_TYPE.THROWABLE),
        new MeleeWeapons("Rusty Mace", 68, 2, MeleeWeapons.WEAPON_TYPE.SINGLE_HANDED),
        new MeleeWeapons("Sharten", 289, 4, MeleeWeapons.WEAPON_TYPE.SINGLE_HANDED),
        new MeleeWeapons("Earthcrack", 369, 3, MeleeWeapons.WEAPON_TYPE.TWOHANDED),
        new MeleeWeapons("Haste", 80, 6, MeleeWeapons.WEAPON_TYPE.THROWABLE),
        new MeleeWeapons("Bloody Sword", 450, 7, MeleeWeapons.WEAPON_TYPE.SINGLE_HANDED)
    };

    public List<MeleeWeapons> twoHanded = new List<MeleeWeapons>();
    public List<MeleeWeapons> singleHanded = new List<MeleeWeapons>();
    public List<MeleeWeapons> throwable = new List<MeleeWeapons>();
    public List<MeleeWeapons> sortedWeapons = new List<MeleeWeapons>();


    void Update()
    {
        if (show)
        {
            //SortByDamage();
            //SortByLevel();
            SortByAlphabet();
            //SortByType();
            show = false;
        }
    }

    public void SortByAlphabet()
    {
        Array.Sort(meleeWeapons, (x, y) => x.m_name.CompareTo(y.m_name));

        foreach (var meleeWeapon in meleeWeapons)
        {
            Debug.Log(meleeWeapon.m_name);
        }
    }

    public void SortByDamage()
    {

        for (int i = 0; i < meleeWeapons.Length; i++)
        {
            for (int j = 0; j < meleeWeapons.Length - 1; j++)
            {
                if (meleeWeapons[j].m_dmg > meleeWeapons[j + 1].m_dmg)
                {
                    int temp = meleeWeapons[j + 1].m_dmg;
                    meleeWeapons[j + 1].m_dmg = meleeWeapons[j].m_dmg;
                    meleeWeapons[j].m_dmg = temp;
                }
            }

        }

        for (int i = 0; i < meleeWeapons.Length; i++)
        {
            Debug.Log(meleeWeapons[i].m_name + " DMG: " + meleeWeapons[i].m_dmg);
        }

    }

    public void SortByLevel()
    {
        for (int i = 0; i < meleeWeapons.Length; i++)
        {
            for (int j = 0; j < meleeWeapons.Length - 1; j++)
            {
                if (meleeWeapons[j].m_lvl > meleeWeapons[j + 1].m_lvl)
                {
                    int temp = meleeWeapons[j + 1].m_lvl;
                    meleeWeapons[j + 1].m_lvl = meleeWeapons[j].m_lvl;
                    meleeWeapons[j].m_lvl = temp;
                }
            }

        }

        for (int i = 0; i < meleeWeapons.Length; i++)
        {
            Debug.Log(meleeWeapons[i].m_name + " Level: " + meleeWeapons[i].m_lvl);
        }
    }

    public void SortByType()
    {
        foreach(var meleeWeapons in meleeWeapons)
        {
            if(meleeWeapons.m_type == MeleeWeapons.WEAPON_TYPE.TWOHANDED)
            {
                twoHanded.Add(meleeWeapons);
            }
            if(meleeWeapons.m_type == MeleeWeapons.WEAPON_TYPE.SINGLE_HANDED)
            {
                singleHanded.Add(meleeWeapons);
            }
            if(meleeWeapons.m_type == MeleeWeapons.WEAPON_TYPE.THROWABLE)
            {
                throwable.Add(meleeWeapons);
            }
            //FINDING THE BEST WAY POSSIBLE TO DEBUG THE LISTS.
        }
        
    }
}


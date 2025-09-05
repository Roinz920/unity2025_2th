using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EntityStats",menuName = "Custom/Stat System/EnityStats", order = 90)]
public class Entity_statsData : ScriptableObject, ICloneable
{
    public Stat maxHealth;
    public Stat Strength;
    public Stat Dexterity;
    public Stat Intelligence;
    public Stat Vitality;

    public object Clone()
    {
        return Instantiate(this);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Entity_stats : MonoBehaviour
{
    [SerializeField] private Entity_statsData _statData;
    public Entity_statsData StatData { get; set; }

    public float GetMaxHealth()
    {
        float baseHP = _statData.maxHealth.GetValue();
        float bonusHP = _statData.Vitality.GetValue() * 5;
                
        return baseHP + bonusHP;
    }

    private void Awake()
    {
        StatData = (Entity_statsData)_statData.Clone();
        StatData.Vitality.AddModifier(5, "Item"); // 아이템으로 인해 체력스탯이 5가 상승했다.
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            StatData.Vitality.RemoveModifier("Item");
        }
    }
}

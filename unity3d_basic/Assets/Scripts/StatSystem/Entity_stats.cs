using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
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
        StatData.Vitality.RemoveModifier("Item"); // Item 경로로부터 얻은 스캣을 제거하라.
    }
    public Stat GetStatbyType(StatType type)
    {
        switch (type)
        {
            case StatType.Strength: return StatData.Strength;
            case StatType.Dexterity: return StatData.Dexterity;
            case StatType.Intelligence: return StatData.Intelligence;
            case StatType.Vitality: return StatData.Vitality;
            case StatType.UnDefined: { Debug.Log("정의되지 않은 스탯 타입을 반환하려 했습니다."); return null; }
            default: return null;                
        }

        /*
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                StatData.Vitality.RemoveModifier("Item");
            }
        }
        */
    }
}
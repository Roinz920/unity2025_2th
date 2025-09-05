using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private float baseValue; // 초기 스탯
    [SerializeField] private List<StatModifier> modifiers; // 아이템 장착 여부, 버프 유무, 레벨 증가 유무에 따라 계속 바뀜. 자료구조 Vector 대신 C#에서는 List 사용
    
    public float GetValue()
    {
        return GetFinalValue();
    }

    public void AddModifier(float value, string source)
    {
        StatModifier modToAdd = new StatModifier(value, source);
        modifiers.Add(modToAdd); // C#의 Add는 pushback과 동일한 기능
    }
    public void RemoveModifier(string source) // buff, equip & unequip
    {
        modifiers.RemoveAll(mod => mod.source == source); // 람다식 표현. 아래 코드를 한줄로 표현한 것과 동일한 코드

        /*
        foreach (var mod in modifiers)
        {
            if(mod.source == source)
            {
                modifiers.Remove(mod);
            }
        }
        */
    }

    private float GetFinalValue()
    {
        float finalValue = baseValue;

        // 아이템, 버프, 레벨업

        foreach(var mod in modifiers)
        {
            finalValue += mod.value;
        }

        return finalValue;
    }
}

[System.Serializable]
public class StatModifier
{
    public float value;
    public string source;   // 아이템, 버프, 레벨업 등에 따른 수치

    public StatModifier(float value, string source)
    {
        this.value = value;
        this.source = source;
    }
}

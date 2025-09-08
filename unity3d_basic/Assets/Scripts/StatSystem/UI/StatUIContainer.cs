using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUIContainer : MonoBehaviour
{
    [SerializeField] Entity_stats playerStat;

    public StatUIElement[] stats;

    private void Start()
    {
        // STR - 0, DEX - 1, INT - 2, VIT - 3
        StatUpdate();
    }

    private void OnEnable()
    {
        Bus<IStartUpdateEvent>.OnEvent += HandleStatUIUpdate;
    }

    private void OnDisable()
    {
        Bus<IStartUpdateEvent>.OnEvent -= HandleStatUIUpdate;
    }

    private void HandleStatUIUpdate(IStartUpdateEvent evt)
    {
        StatUpdate();
    }

    private void StatUpdate()
    {
        stats[0].SetUI(playerStat.StatData.Strength.GetValue());
        stats[1].SetUI(playerStat.StatData.Dexterity.GetValue());
        stats[2].SetUI(playerStat.StatData.Intelligence.GetValue());
        stats[3].SetUI(playerStat.StatData.Vitality.GetValue());
    }
}

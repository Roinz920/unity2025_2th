using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_health : MonoBehaviour
{
    private Entity_stats stats;
    [SerializeField] protected float currentHP;

    private void Start()
    {
        stats = GetComponent<Entity_stats>();
        currentHP = stats.GetMaxHealth();
    }

}

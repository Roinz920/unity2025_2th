using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Default NPC", menuName = "ScriptableObject/NPCInfo", order = 101)]
public class NPCInfo : ScriptableObject
{
    public int MinSpeed;
    public int MaxSpeed;
    public int PatrolRadius;
    public float stopDistance = 0.1f;
    public float patrolDistance = 5.0f;
    public Sprite NpcSprite;
    public string NpcName;

}

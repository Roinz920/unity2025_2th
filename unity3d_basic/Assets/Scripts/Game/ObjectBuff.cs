using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Buff
{
    public StatType type = StatType.UnDefined;
    public float Value = 5.0f;

}

public class ObjectBuff : MonoBehaviour
{
    // Tag가 player인 객체와 충돌했을 때 OnTriggerEnter2D 또는 OnCollisionEnter2D

    Entity_stats statsToMod;
    SpriteRenderer buffSprite;

    [Header("Buff Detail")]
    [SerializeField] Buff[] buffs;
    [SerializeField] private float buffTime = 5.0f;    
    [SerializeField] private string buffName = "Item";

    private void Start()
    {
        buffSprite = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTag.PlayerTag))
        {
            statsToMod = collision.GetComponent<Entity_stats>();
            StartCoroutine(BuffCoroutine());
        }
    }
    IEnumerator BuffCoroutine()
    {        
        foreach(Buff buff in buffs)
        {
            statsToMod.GetStatbyType(buff.type).AddModifier(buff.Value, buffName);
        }

        
        //Debug.Log($"플레이어의 현재 체력 스탯 : {statsToMod.StatData.Vitality.GetValue()}");
        Bus<IStartUpdateEvent>.Raise(new IStartUpdateEvent());

        // ??초 후에 증가되었던 임시 스탯을 제거하고, 오브젝트를 파괴하라
        buffSprite.color = Color.clear;
        yield return new WaitForSeconds(buffTime);

        foreach(Buff buff in buffs)
        {
            statsToMod.GetStatbyType(buff.type).RemoveModifier(buffName);
        }
        Bus<IStartUpdateEvent>.Raise(new IStartUpdateEvent());
        Destroy(gameObject);
    }
}


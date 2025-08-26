using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackChecker : MonoBehaviour
{
    public Battle owner;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        // collision 오브젝트 안에 공격이 가능한 컴포넌트가 존재한다면
        if (collision.TryGetComponent<Battle>(out Battle battle))
        {
            owner.Attack();       
        }
        // 공격하라
    }
}

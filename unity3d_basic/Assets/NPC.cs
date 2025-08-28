using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : MonoBehaviour
{
    [SerializeField] private NPCInfo NPC_Info;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;

    private void Awake()
    {
        // NPC 클래스와 같은 오브젝트에 부착되어있는 컴포넌트를 가져와보세요

        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        // 컴포넌트에 데이터를 연결했으면, 실제 게임 데이터로 설정
        spriteRenderer.sprite = NPC_Info.NpcSprite;
        rigidbody2D.gravityScale = 0;
    }
    private void Start()
    {
        Patrol();
    }

    private void Update()
    {
        Patrol();
    }
    public void Patrol()
    {
        // 이동해라
        MoveTargetPoint(1);
        // 일정 시간 대기한다
        //WaitTime(3);
    }

    private void MoveTargetPoint(float WaitTime)
    {
        float moveSpeed = Random.Range((float)NPC_Info.MinSpeed, (float)NPC_Info.MaxSpeed);

        Vector2 randomPosition = Random.insideUnitCircle * NPC_Info.PatrolRadius;

        Debug.Log(randomPosition);

        transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position+randomPosition, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, randomPosition) < 0.1f)
        {
            Invoke(nameof(Patrol), WaitTime * Time.deltaTime);
        }
    }
    public void WaitTime(float time)
    {
        
    }
}

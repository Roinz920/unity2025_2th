using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public enum CollisionEvent
{
    Friendly, Aggressivly, UnDefined
}

public class NPC : MonoBehaviour
{
    [SerializeField] private NPCInfo NPC_Info;
    [SerializeField] CollisionEvent collisionEvent = CollisionEvent.UnDefined;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;

    
    [SerializeField] private Vector2 currentTargetPos;
    [SerializeField] private bool IsMoving =true;   // 목적지 도착 후, 한번만 위치를 재설정하기 위함
    Transform playerPos;

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
        SetRandomPosition();
    }

    private void Update()
    {
        if (IsPatrol()) { Patrol(); }
        else { Chase(); }
        
    }
    public void Patrol()
    {
        // 이동해라
        MoveTargetPoint();
    }

    public void Chase()
    {
        //playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        SetPosition(playerPos.position);
        MoveTargetPoint();
    }

    // 현재 상태를 체크해주는 함수
    bool IsPatrol()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        if (Vector2.Distance(transform.position, playerPos.position) < NPC_Info.patrolDistance)
            return false;
        else return true;
    }

    private void MoveTargetPoint()
    {
        float moveSpeed = Random.Range((float)NPC_Info.MinSpeed, (float)NPC_Info.MaxSpeed);

        // SetRandomPosition();

        // Debug.Log(currentTargetPos);

        


        if (Vector2.Distance(transform.position, currentTargetPos) < NPC_Info.stopDistance)
        {
            rigidbody2D.velocity = Vector2.zero;
            IsMoving = true;

            //if (IsMoving)
            //{
            //IsMoving = false;
            //Invoke(nameof(SetRandomPosition), 1.0f);
            //}

            if(IsPatrol()) { SetRandomPosition(); }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, currentTargetPos, moveSpeed * Time.deltaTime);
        }
    }

    public void SetRandomPosition()
    {
        // 위치의 랜던값 표현
        currentTargetPos = (Vector2)transform.position + Random.insideUnitCircle * NPC_Info.PatrolRadius;
        IsMoving = false;
    }

    public void SetPosition(Vector2 pos)
    {
        currentTargetPos = pos;
    }
    private IEnumerator SetRandomPositionCoroutine()
    {        
        SetRandomPosition();
        yield return new WaitForSeconds(1f);        
    }

    // Gizmo를 그리는 특수한 함수
    private void OnDrawGizmos()
    {
        DrawChaseCircle();
    }
    private void OnDrawGizmosSelected()
    {
        //DrawChaseCircle();
    }
    private void DrawChaseCircle()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, NPC_Info.patrolDistance);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // NPC가 플레이어와 충돌했을 때의 이벤트 발생
            if(collisionEvent == CollisionEvent.Friendly)
            {
                Bus<IColWithPlayerEvent>.Raise(new IColWithPlayerEvent());
                gameObject.SetActive(false);
                //Bus<IFriendlyCollsionEvent>.Raise();
            }
            else if (collisionEvent == CollisionEvent.Aggressivly)
            {
                
                //Bus<IAggressivlyCollisionEvent>.Raise();
            }
            else
            {
                Debug.LogWarning("정의되지 않은 이벤트 발생");
            }

        }
    }
}

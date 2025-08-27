using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 2f;        // 이동 속도
    [SerializeField] private float changeTargetDelay = 0.5f; // 새 목표 위치로 다시 고르는 최소 딜레이
    [SerializeField] private Vector2 moveRange = new Vector2(8f, 4f); // 이동 가능한 월드 범위 (x, y)

    private Vector2 targetPosition;

    private void Start()
    {
        SetNewTarget();
    }

    private void Update()
    {
        // 목표 지점으로 부드럽게 이동
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // 목표 지점에 거의 도착했으면 새로운 랜덤 좌표 설정
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            Invoke(nameof(SetNewTarget), changeTargetDelay);
        }
    }

    private void SetNewTarget()
    {
        float x = Random.Range(-moveRange.x, moveRange.x);
        float y = Random.Range(-moveRange.y, moveRange.y);

        targetPosition = new Vector2(x, y);
    }
}

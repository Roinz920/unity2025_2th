using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 동전을 먹었을 때에 작동하라
public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    [SerializeField] private int coinAmount = 2;
    [SerializeField] private int coinMaxAmount = 10;
    [SerializeField] private float coinSpawnDelay = 0.5f;

    private int currentCoinCount = 0;
    private bool maxCoinState = false;
    private void OnEnable()
    {
        Bus<IGetCoinEvent>.OnEvent += HandleGetCoin;
    }

    private void OnDisable()
    {
        Bus<IGetCoinEvent>.OnEvent -= HandleGetCoin;
    }

    private void HandleGetCoin(IGetCoinEvent evt)
    {

        if (maxCoinState) { return; }

        StartCoroutine(SpawnCoinRoutine());

         

    }

    private IEnumerator SpawnCoinRoutine()
    {
        for (int i = 0; i < coinAmount; i++)
        {
            if (currentCoinCount >= coinMaxAmount)
            {
                maxCoinState = true;
                yield break; // 코루틴 종료
            }

            // 게임에 플레이어가 획득한 경우에 코인을 생성하고 싶다.    
            Vector2 randomSpawnPos = UnityEngine.Random.insideUnitCircle * 10;
            Instantiate(CoinPrefab, transform.position + (Vector3)randomSpawnPos, Quaternion.identity);

            currentCoinCount++;

            yield return new WaitForSeconds(coinSpawnDelay);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Vector3.zero, 10);
    }
}

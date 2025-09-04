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

    [SerializeField] private bool maxCoinState = false;

    [SerializeField] private int spawnCoinCount = 0;
    [SerializeField] List<Coin> spawnedList = new();
    [SerializeField] public int spawnedCount { get; set; }

    private void OnEnable()
    {
        Bus<IGetCoinEvent>.OnEvent += HandleGetCoin;
        Bus<ICoinSpawnEvent>.OnEvent += HandleSpawnCoin;
    }

    private void OnDisable()
    {
        Bus<IGetCoinEvent>.OnEvent -= HandleGetCoin;
        Bus<ICoinSpawnEvent>.OnEvent += HandleSpawnCoin;
    }

    private void HandleSpawnCoin(ICoinSpawnEvent evt)
    {
        spawnedList.Add(evt.Coin);
        spawnedCount++;
    }

    private void HandleGetCoin(IGetCoinEvent evt)
    {
        if (maxCoinState) { return; }
        spawnedList.Remove(evt.Coin);
        spawnedCount--;
        StartCoroutine(SpawnCoinRoutine());
    }

    private IEnumerator SpawnCoinRoutine()
    {
        for (int i = 0; i < coinAmount; i++)
        {
            if (spawnCoinCount >= coinMaxAmount)
            {
                maxCoinState = true;
                yield break; // 코루틴 종료
            }

            // 게임에 플레이어가 획득한 경우에 코인을 생성하고 싶다.    
            Vector2 randomSpawnPos = UnityEngine.Random.insideUnitCircle * 10;
            Instantiate(CoinPrefab, transform.position + (Vector3)randomSpawnPos, Quaternion.identity);

            spawnCoinCount++;

            yield return new WaitForSeconds(coinSpawnDelay);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Vector3.zero, 10);
    }
}

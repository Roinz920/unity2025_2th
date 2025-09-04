using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [field:SerializeField] public int coinValue { get; private set; } = 5;
    private void Start()
    {
        Bus<ICoinSpawnEvent>.Raise(new ICoinSpawnEvent(this));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // 동전을 획득햇습니다. 라는 이벤트를 실행하라.

            // 이벤트 발생
            Bus<IGetCoinEvent>.Raise(new IGetCoinEvent(this));
            Bus<IScoreUpdateEvent>.Raise(new IScoreUpdateEvent(50)); // 이벤트를 발생시켜라는 명령
            //ScoreManager.Instance.Score += 50; // 직업 ScoreManager 데이터를 수정하는 코드.
            //Destroy(this.gameObject);
            gameObject.SetActive(false);
            // 이벤트 코드를 실행시키는 형태
            // Bus<T>.Raise(new T());
        }
    }

}

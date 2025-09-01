using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [field:SerializeField] public int coinValue { get; private set; } = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // 동전을 획득햇습니다. 라는 이벤트를 실행하라.

            // 이벤트 발생
            Bus<IGetCoinEvent>.Raise(new IGetCoinEvent(coinValue));
            Destroy(this.gameObject);
            // 이벤트 코드를 실행시키는 형태
            // Bus<T>.Raise(new T());

        }
    }

}

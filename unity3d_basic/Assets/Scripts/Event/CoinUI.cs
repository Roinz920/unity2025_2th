using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    [field:SerializeField] private int currentCoin;
    // 코인이 변경되었을 때에만 실행.

    private void OnEnable()
    {
        // 이벤트를 처리해주는 공통 스크립트(Bus)가 이벤트라는 승객들을 처리해주기 위함
        Bus<IGetCoinEvent>.OnEvent += HandleGetCoin;
    }
    private void OnDisable()
    {
        Bus<IGetCoinEvent>.OnEvent -= HandleGetCoin;
    }

    private void HandleGetCoin(IGetCoinEvent evt)
    {
        currentCoin += evt.Value;
        coinText.SetText($"Current Coin : {currentCoin}");
    }   

    private void Start()
    {
        currentCoin = 0; // 플레이어의 동전 정보로부터 값을 가져와서 적용
        coinText = GetComponent<TextMeshProUGUI>();
        Bus<IGetCoinEvent>.Raise(new IGetCoinEvent(currentCoin));
    }

}

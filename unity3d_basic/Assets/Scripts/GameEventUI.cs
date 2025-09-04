using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEventUI : MonoBehaviour
{
    //[Header("NPC UI")]
    //public GameObject NPCPanel;
    //public Image NpcSprite;

    [Header("GameOver UI")]
    public GameObject GameOverPanel;

    [Header("GameClear UI")]
    public GameObject GameClearPanel;

    private void Start()
    {
        // Unity Scene에서 실수로 활성화 해둔 상태여도, 코드로 비활성화 시켜준다.
        //NPCPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GameClearPanel.SetActive(false);
    }

    private void OnEnable()
    {
        Bus<IGameOverEvent>.OnEvent += HandleGameOver;
        Bus<IGameClearEvent>.OnEvent += HandleGameClear;
    }

    private void OnDisable()
    {
        Bus<IGameOverEvent>.OnEvent -= HandleGameOver;
        Bus<IGameClearEvent>.OnEvent += HandleGameClear;
    }

    private void HandleGameOver(IGameOverEvent evt)
    {
        Time.timeScale = 0.1f;
        GameOverPanel.SetActive(true);
    }
    private void HandleGameClear(IGameClearEvent evt)
    {
        GameClearPanel.SetActive(true);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestscoreText;

    private int currentScore;
    
    private void OnEnable()
    {
        Bus<IScoreUpdateEvent>.OnEvent += HandleScoreUpdate;
        
    }

    private void OnDisable()
    {
        Bus<IScoreUpdateEvent>.OnEvent -= HandleScoreUpdate;
    }

    private void HandleScoreUpdate(IScoreUpdateEvent evt)
    {
        currentScore += evt.Score;
        scoreText.SetText($"Score \t: {currentScore}");
    }

    public void SetScoreInfo()
    {
        currentScore = ScoreManager.Instance.Score;
        scoreText.SetText($"Score \t: {currentScore}");
        ScoreManager.Instance.LoadScore();
        bestscoreText.SetText($"BestScore \t: {ScoreManager.Instance.BestScore}");
       
    }

    private void SaveBestScore()
    {
        ScoreManager.Instance.SaveScore(currentScore);
    }

    private void Start()
    {
        SetScoreInfo();
    }

    // Bus<IscoreUpdateEvent>를 사용해서 업데이트하도록 하면 개선 가능
    private void Update()
    {
        //SetScoreInfo();
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("현재 점수를 저장합니다.");
            SaveBestScore();
        }
    }
}

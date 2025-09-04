using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // static을 사용하면 모든 클래스가 접근할 수 있게 해준다
    // 그런데 만약 ScoreManager가 2개 이상 존재한다면, 어쩐 ScoreManager에 접근해야할지 모호해짐
    // 그러므로 하나만 존재하도록 방지코드를 써야한다.
    public static ScoreManager Instance;

    private void Awake()
    {
        // 이 클래스가 단독으로 존재해주도록 조건을 만들어준다
        // SingleTon 패턴

        if (Instance != null&&Instance !=this) //내가 아닌 다른 녀석의 Instance가 존재할 경우
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // 파괴하지 못하도록 설정하는 코드. 데이터 클래스를 유지하기 위함
    }

    public int Score;
    public int BestScore;
    public const string _BESTSCORE = "BestScore";
    
    public void SaveScore(int currentScore)
    {
        // 어딘 가의 (숨겨진) 장소에 데이터를 저장해둔다.
        // 만들어진 저장 기능을 활용하겠다.

        if (currentScore < BestScore) { return; }
        PlayerPrefs.SetInt(_BESTSCORE, currentScore);

    }

    public void LoadScore()
    {
        // 저장해둔 장소로부터 데이터를 불러온다.
        // 게임을 처음 시작할 때에는 BestScore 데이터가 존재하지 않음
        // 존재하지 않은 데이터를 참조하려고 하면 에러 발생
        if (PlayerPrefs.HasKey(_BESTSCORE))
        {
            BestScore = PlayerPrefs.GetInt(_BESTSCORE);
        }
        else BestScore = 0;
    }

}

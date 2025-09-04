using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void GameClear()
    {
        if (IsGameClear())
        {
            // Bus<I~~Event>.Raise(new ~~());
            Bus<IGameClearEvent>.Raise(new IGameClearEvent());
        }
    }
    
    public bool IsGameClear()
    {
        //if() // 게임 클리어를 위한 조건이 필요한 경우, if문 작성
        //{
        //    return false;
        //}
        return true;
    }
    public void GameOver()
    {
        if (IsGameOver())
        {
            // 이벤트를 생성하여 게임오버되었습니다. 라는 메시지 출력
            // Bus<I~~Event>.Raise(new ~~());
            Bus<IGameOverEvent>.Raise(new IGameOverEvent());
        }
    }

    public bool IsGameOver()
    {
        return true;
    }

}

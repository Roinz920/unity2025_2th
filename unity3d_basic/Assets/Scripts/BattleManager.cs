using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Turn
    int turnValue;
    public bool playerTurn = true;

    public void TurnChange()
    {
        playerTurn = !playerTurn;

        EnemyTurn();
    }

    private void EnemyTurn()
    {
        EnemyAI();
        playerTurn = true;
    }

    public Battle Player;
    public Battle Enemy;

    public void EnemyAI()
    {
        int RandomValue = UnityEngine.Random.Range(0, 3);
        Debug.Log($"랜덤 값의 정확성 확인 {RandomValue}");
        switch(RandomValue)
        {
            case 0: Enemy.Attack(); break;
            case 1: Enemy.Recover(10); break;
            case 2: Enemy.ShieldUp(5); break;
        }
    }
}

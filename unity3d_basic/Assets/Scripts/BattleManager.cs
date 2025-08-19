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
    }
}

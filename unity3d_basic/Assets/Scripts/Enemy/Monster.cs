using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 부모의 함수를 가져와서 사용하는 방법의 학습
// 부모의 함수를 가져와 다시 정의한다 (재정의) override

public class Monster : Battle
{
    public void Attack(Battle other)
    {
        //  battleManager에서 player의 턴이라면 실행하지 마시오.
        if (battleManager.playerTurn == false) 
        { 
            if (battleManager.playerTurn) return; 
        }

        base.Attack(); // base : 기반 함수
        Debug.Log($"공격! (Monster)");

        // battleManager에서 턴을 종료합니다. - 몬스터에서는 코드 작성을 할 필요가 없다.
    }

    public override void Recover(int amount)
    {
        if (battleManager.playerTurn == false) { return; }

        base.Recover(amount);
    }

    public override void ShieldUp(int amount)
    {
        if (battleManager.playerTurn == false) { return; }

        base.ShieldUp(amount);
    }
}

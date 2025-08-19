using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyExample : MonoBehaviour
{
    // 멤버 변수, 멤버 함수

    private int hp;
    private int atk;

    // 프로퍼티 사용형태 (1)
    public int HP { get; set; }

    // 프로퍼티 사용형태 (2)
    public int HP2 { get { if (hp <= 0) { hp = 0; } return hp; } set { hp = value; } }

    // 프로퍼티 사용형태 (3)
    public int DEF { get; private set; } // 외부에서 값을 변경하지 말도록 하는 방식

    public int MaxLevel { get; private set; } // 게임 시작할 때, 최대 레벨을 설정. 다른 클래스에서 변경할 수 없도록 설정하기 위함.

    public int GetHP() { return hp; }
    public void SetHP(int _hp) { hp = _hp; }

    /*
     *  프로퍼티 (Property)
     *  사용법 : 변수 선언 → public (타입) (변수 이름) // 첫글자를 대문자로 작성하는 것이 일반적인 규칙.
     *  public int HP {get; set;}
     */

    /// <summary>
    /// hp를 절반으로 변경해주는 코드입니다. 반드시 이 함수를 이용하여 HP를 조절해주세요.
    /// </summary>
    public void UseThisFunction()
    {
        hp /= 2;
    }
}

public class AnotherClass
{
    PropertyExample example;

    public void Test()
    {
        example.UseThisFunction();
        //example.hp = 10;

        example.HP = 10;
        int maxHP = example.HP;
    }

    void Start()
    {
        example = new();
        Test();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyExample : MonoBehaviour
{
    // ��� ����, ��� �Լ�

    private int hp;
    private int atk;

    // ������Ƽ ������� (1)
    public int HP { get; set; }

    // ������Ƽ ������� (2)
    public int HP2 { get { if (hp <= 0) { hp = 0; } return hp; } set { hp = value; } }

    // ������Ƽ ������� (3)
    public int DEF { get; private set; } // �ܺο��� ���� �������� ������ �ϴ� ���

    public int MaxLevel { get; private set; } // ���� ������ ��, �ִ� ������ ����. �ٸ� Ŭ�������� ������ �� ������ �����ϱ� ����.

    public int GetHP() { return hp; }
    public void SetHP(int _hp) { hp = _hp; }

    /*
     *  ������Ƽ (Property)
     *  ���� : ���� ���� �� public (Ÿ��) (���� �̸�) // ù���ڸ� �빮�ڷ� �ۼ��ϴ� ���� �Ϲ����� ��Ģ.
     *  public int HP {get; set;}
     */

    /// <summary>
    /// hp�� �������� �������ִ� �ڵ��Դϴ�. �ݵ�� �� �Լ��� �̿��Ͽ� HP�� �������ּ���.
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

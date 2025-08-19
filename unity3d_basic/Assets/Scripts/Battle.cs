using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BattleEntity
{
    public float HP;
    public float Atk;
    public float Def;
    public string AttackType;

    public BattleEntity() { }

    public BattleEntity(float hP, float atk)
    {
        HP = hP;
        Atk = atk;
    }

    public BattleEntity(float hP, float atk, float def)
    {
        HP = hP;
        Atk = atk;
        Def = def;
    }
}

[System.Serializable]
public class BattleUI
{
    public Image HpBar;
    public TextMeshProUGUI BattleEntity;

    public void SetBattleUI(BattleEntity battleEntity)
    {
        BattleEntity.SetText($"ATK : {battleEntity.Atk}, DEF : {battleEntity.Def}");
    }

    public void SetHPBar(float current, float max)
    {
        HpBar.fillAmount = current / max;
    }

}


public class Battle : MonoBehaviour
{

    public BattleEntity battleEntity;
    public BattleUI battleUI;
    public BattleManager battleManager;

    public bool IsPlayer;
    public float CurrentHP
    {
        get
        {
            if (currentHP <= 0)
            {
                // �ǰݽ��� ȿ����, ����Ʈ, �ִϸ��̼� ���� �̺�Ʈ ����
                currentHP = 0;
                Death();
            }
            else
            {
                // ������� ȿ����, ����Ʈ, �ִϸ��̼� ���� �̺�Ʈ ����
            }            
            return currentHP;
        }
        private set 
        { 
            if(value > battleEntity.HP)
            {
                value = battleEntity.HP;
            }
            currentHP = value; 
        }
    }// Battle Ŭ���������� ���� ü�� ������ ������ �� �ִ�.

    [SerializeField] private float currentHP;

    private void Start()
    {
        // battleEntity = new BattleEntity(100, 50, 5);

        Debug.Log($"HP : {battleEntity.HP}, ATK : {battleEntity.Atk}, DEF : {battleEntity.Def}");
        battleUI.SetBattleUI(battleEntity);
        CurrentHP = battleEntity.HP;
    }

    private void Update()
    {
        battleUI.SetHPBar(CurrentHP, battleEntity.HP);
                
    }

    // ��뿡�� �������� �޴´� (TakeDamage)   : CurrentHP - (ATK, ���¿� ���� ����)
    public void TakeDamage(Battle other)
    {
        float FinalDamage = other.battleEntity.Atk - battleEntity.Def;
        if (FinalDamage <= 0) FinalDamage = 1;
        CurrentHP -= FinalDamage;

        Debug.Log($"���� ������ : {FinalDamage}, �������� ���ݷ� : {other.battleEntity.Atk}, ���� : {battleEntity.Def}");

        /*
    
        */
        // ���� ü���� 0���� Ŭ ��

        // ���� ü���� 0���� �۰ų� ���� ��
    }
    // �׾��� ���� ����ó�� (Die, Death)       : currentHP�� 0���� �۾����� ���� �̺�Ʈ

    public void Death()
    {
        Debug.Log($"����Ͽ����ϴ�. ���� ü�� {currentHP}");
    }

    public void Recover (int amount)
    {
        if (IsPlayer && !battleManager.playerTurn) return;
        currentHP += amount;
    }

    public void ShieldUp (int amount)
    {
        if (IsPlayer && !battleManager.playerTurn) return;

        battleEntity.Def += amount;
        battleUI.SetBattleUI(battleEntity);
    }
}





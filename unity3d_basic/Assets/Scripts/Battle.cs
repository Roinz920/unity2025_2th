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
                // 피격시의 효과음, 이펙트, 애니메이션 등의 이벤트 실행
                currentHP = 0;
                Death();
            }
            else
            {
                // 사망시의 효과음, 이펙트, 애니메이션 등의 이벤트 실행
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
    }// Battle 클래스에서만 현재 체력 변수를 수정할 수 있다.

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

    // 상대에게 데미지를 받는다 (TakeDamage)   : CurrentHP - (ATK, 방어력에 따라 감소)
    public void TakeDamage(Battle other)
    {
        float FinalDamage = other.battleEntity.Atk - battleEntity.Def;
        if (FinalDamage <= 0) FinalDamage = 1;
        CurrentHP -= FinalDamage;

        Debug.Log($"최종 데미지 : {FinalDamage}, 공격자의 공격력 : {other.battleEntity.Atk}, 방어력 : {battleEntity.Def}");

        /*
    
        */
        // 남은 체력이 0보다 클 때

        // 남은 체력이 0보다 작거나 같을 때
    }
    // 죽었을 때에 로직처리 (Die, Death)       : currentHP가 0보다 작아졌을 때의 이벤트

    public void Death()
    {
        Debug.Log($"사망하엿습니다. 현재 체력 {currentHP}");
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





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

    public float currentHP;

    private void Start()
    {
        // battleEntity = new BattleEntity(100, 50, 5);

        Debug.Log($"HP : {battleEntity.HP}, ATK : {battleEntity.Atk}, DEF : {battleEntity.Def}");
        battleUI.SetBattleUI(battleEntity);
        currentHP = battleEntity.HP/2;
    }

    private void Update()
    {
        battleUI.SetHPBar(currentHP, battleEntity.HP);
    }

    // 상대에게 데미지를 받는다 (TakeDamage)   : 
    // 죽었을 때에 로직처리 (Die, Death)       : currentHP가 0보다 작아졌을 때의 이벤트
}





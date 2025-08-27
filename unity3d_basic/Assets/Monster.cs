using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;


namespace Example
{
    // 오늘의 목표 : 코드로 게임에 등장하는 오브젝트를 조립한다.
    // 컴퓨터와 대화(C#)를 해서 몬스터가 필요한 정보를 정보를 전달.
    // 이동 속도(MonsterMove), sprite 정보

    public class Monster : MonoBehaviour
    {
        // 몬스터가 움직이는 코드를 생성한다.
        // 움직이는 속도 필요.
        // 몬스터의 형상 Sprite
        // 위치, 회전, 크기
        public MonsterInfo monsterInfo;
        public float moveSpeed;        
        private void Start()
        {
            MonsterConstructor();
        }

        [ContextMenu("몬스터 생성")]
        private void MonsterConstructor()
        {
            GameObject instance = new GameObject();
            instance.transform.localScale = Vector3.one * monsterInfo.size;
            SpriteRenderer sr = instance.AddComponent<SpriteRenderer>();
            sr.color = monsterInfo.color;
            sr.sprite = monsterInfo.monsterSprite;
            //moveSpeed = monsterInfo.moveSpeed;
            MonsterMove mMove = instance.AddComponent<MonsterMove>();
            CapsuleCollider2D cc2d = instance.AddComponent<CapsuleCollider2D>();
            cc2d.offset = new Vector2(0, -0.175f);
            cc2d.size = new Vector2(0.7f, 0.95f);
            Rigidbody2D rb2D = instance.AddComponent<Rigidbody2D>();
            rb2D.gravityScale = 0;
            rb2D.freezeRotation = true;

            instance.name = monsterInfo.monsterName;

            //Instantiate(instance, Vector3.zero, Quaternion.identity);
        }
    }
}
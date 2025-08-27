using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Example
{
    [CreateAssetMenu(fileName = "Default Monster Name", menuName = "ScriptableObject/MonsterInfo", order = 100)]
    public class MonsterInfo : ScriptableObject
    {
        public float moveSpeed = 1f;
        public Sprite monsterSprite;
        public float size = 1.0f;
        public string monsterName;
        public Color color;
    }
}

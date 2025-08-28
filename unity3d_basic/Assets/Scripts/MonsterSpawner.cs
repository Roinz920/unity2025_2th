using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example {
    public class MonsterSpawner : MonoBehaviour
    {
        // 특정 시점, 특정 이벤트가 발생되고 나서 몬스터를 생성하고 싶다.
        [Header("몬스터 생성 정보")]
        [SerializeField] Transform[] spawnPositions; // cs에서 배열을 표현하는 방식
        [SerializeField] GameObject[] spawnMonsters;
        [SerializeField] MonsterInfo[] monsterInfos;
        [SerializeField] int spawnAmount = 5;
        [SerializeField] float spawnIntervalTime = 0.5f;
        private Coroutine spawnCoroutine;
        private Monster monster = new();

        // Start is called before the first frame update
        void Start()
        {

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Spawn();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                monster = ConstructMonster();
                monster.MonsterConstructor();
            }
        }

        // monster의 데이터를 생성해주는 함수
        public Monster ConstructMonster()
        {
            Monster newMonster = new();
            int random = UnityEngine.Random.Range(0, monsterInfos.Length);
            newMonster.monsterInfo = monsterInfos[random]; // monsterInfos 배열중의 하나를 선택하라.
            return newMonster;
        }
        /// <summary>
        /// 게임 월드에 특정 위치에 몬스터를 생성하는데, 몇 마리를 생성할까
        /// 한번에 몬스터가 등장할 것인가, 시간에 걸쳐서 서서히 생성할 것인가
        /// 유니티에서 함수 이름이 Spawn이고 위의 두 줄의 기능을 하는 함수를 만들어줘.
        /// </summary>
        public void Spawn()
        {
            if (spawnCoroutine == null)
            {
                spawnCoroutine = StartCoroutine(SpawnCorountine());

                //spawnCoroutine = StartCoroutine(nameof(SpawnCorountine));

                // 두 방식 중 어떤 코루틴 호출방식을 사용하면 좋을까?
                // 두 방식 중 원하는 방식을 사용하되, 한가지 방식으로 통일해줄 것. (2개 이상의 코루틴을 사용할 경우에도)
            }

        }

        private IEnumerator SpawnCorountine()
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                int randomPosIdx = UnityEngine.Random.Range(0, spawnPositions.Length);
                int randomMonIdx = UnityEngine.Random.Range(0, spawnMonsters.Length);

                Instantiate(spawnMonsters[randomMonIdx], spawnPositions[randomPosIdx]);

                yield return new WaitForSeconds(spawnIntervalTime);
            }

            // 코루틴 종료 → null 초기화
            spawnCoroutine = null;
        }
    }
}

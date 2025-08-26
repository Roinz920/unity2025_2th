using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyObject : MonoBehaviour
{
    // Ready 스크립트가 Start! 텍스트가 작성되면, Square 오브젝트의 색깔을 기존 색깔과 다른 색으로 변경해보시오.
    // Start 함수를 코루틴으로 변경하여 구현해보세요.

    // 바꾸고 싶은 오브젝트를 변수로 선언.
    [SerializeField] SpriteRenderer sr;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(4f);
        sr.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

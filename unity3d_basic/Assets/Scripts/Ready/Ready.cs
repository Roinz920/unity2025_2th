using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Ready : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI readyText;
    [SerializeField] int startSecond = 5;
    [SerializeField] float intervalTime = 1f;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        

        for (int i=0; i< startSecond; i++)
        {
            readyText.SetText((startSecond - i).ToString());
            yield return new WaitForSeconds(intervalTime);
        }

        /* 
        readyText.SetText("5");
        // 1초 뒤에 다음코드를 실행하라.        
        readyText.SetText("4");
        // 1초 뒤에 다음코드를 실행하라.
        readyText.SetText("3");
        // 1초 뒤에 다음코드를 실행하라.
        readyText.SetText("2");
        // 1초 뒤에 다음코드를 실행하라.
        readyText.SetText("1");
        // 1초 뒤에 다음코드를 실행하라.
        */
        readyText.SetText("START!");
        yield return new WaitForSeconds(intervalTime);
        readyText.gameObject.SetActive(false);
        yield return new WaitForSeconds(intervalTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

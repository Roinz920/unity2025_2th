using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] Button ReStartButton;
    [SerializeField] Button QuitButton;

    private void OnEnable()
    {
        ReStartButton.onClick.AddListener(ReStart);
        // Unity에서 Button 또한 Event를 사용해서 작동하고 있음.
        // Button 컴포넌트의 On Click()에 +를 눌러 ReStart() 함수를 지정하는것과 동일한 효과
        QuitButton.onClick.AddListener(Quit);
    }
    private void OnDisable()
    {
        ReStartButton.onClick.RemoveListener(ReStart);
        QuitButton.onClick.RemoveListener(Quit);
    }
    public void ReStart()
    {
        //Debug.Log("게임을 재시작합니다.");
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        //Debug.Log("게임을 종료합니다.");
        Application.Quit();
    }
}

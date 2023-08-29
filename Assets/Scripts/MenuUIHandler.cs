using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI currentName;
    public TextMeshProUGUI scoreText;
    private void Start()
    {
        if (MainManager1.Instance != null)
        {
            SetData(MainManager1.Instance.highestScore, MainManager1.Instance.recordName);
        }
    }
    public void StartGame()
    {
        MainManager1.Instance.currentName = currentName.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    void SetData(int score, string name)
    {
        scoreText.text = "Best Score: " + name + " : " + score;
    }
}

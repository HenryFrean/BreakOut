using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winnerPanel;
    [SerializeField] GameObject[] livesImg;
    [SerializeField] Text gameTimeText;
    [SerializeField] AudioClip buttonPress;

    bool loadingScene;

    AudioController audioController;

    private void Start()
    {
        audioController = FindObjectOfType<AudioController>();
    }

    public void ActivateLosePanel()
    {
        losePanel.SetActive(true);
    }

    public void ActivateWinnerPanel(float gameTime)
    {
        winnerPanel.SetActive(true);
        gameTimeText.text = "Game Time: " + Mathf.Floor(gameTime) + "s";
    }

    public void RestartCurrentScene()
    {
        if(loadingScene == true)
        {
            return;
        }
        audioController.PlaySfx(buttonPress);
        StartCoroutine(LoadNextScene("Game"));
    }

    public void GoToMainMenu()
    {
        if (loadingScene == true)
        {
            return;
        }
        audioController.PlaySfx(buttonPress);
        StartCoroutine(LoadNextScene("MainMenu"));
    }

    public void LoadSceneTwo()
    {
        if (loadingScene == true)
        {
            return;
        }
        audioController.PlaySfx(buttonPress);
        StartCoroutine(LoadNextScene("LevelTwo"));
    }

    public void LoadSceneThree()
    {
        if (loadingScene == true)
        {
            return;
        }
        audioController.PlaySfx(buttonPress);
        StartCoroutine(LoadNextScene("LevelThree"));
    }

    public void LoadSceneFour()
    {
        if (loadingScene == true)
        {
            return;
        }
        audioController.PlaySfx(buttonPress);
        StartCoroutine(LoadNextScene("LevelFour"));
    }

    public void LoadSceneFive()
    {
        if (loadingScene == true)
        {
            return;
        }
        audioController.PlaySfx(buttonPress);
        StartCoroutine(LoadNextScene("LevelFive"));
    }

    public void LoadSceneSix()
    {
        if (loadingScene == true)
        {
            return;
        }
        audioController.PlaySfx(buttonPress);
        StartCoroutine(LoadNextScene("LevelSix"));
    }

    public void LoadSceneSeven()
    {
        if (loadingScene == true)
        {
            return;
        }
        audioController.PlaySfx(buttonPress);
        StartCoroutine(LoadNextScene("LevelSeven"));
    }

    public void LoadSceneEight()
    {
        if (loadingScene == true)
        {
            return;
        }
        audioController.PlaySfx(buttonPress);
        StartCoroutine(LoadNextScene("LevelEight"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadNextScene(string sceneName)
    {
        loadingScene = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

    public void UpdateUILives(byte currentLives)
    {
        for (int i = 0; i < livesImg.Length; i++)
        {
            if (i >= currentLives)
            {
                livesImg[i].SetActive(false);
            }
        }
    }
}

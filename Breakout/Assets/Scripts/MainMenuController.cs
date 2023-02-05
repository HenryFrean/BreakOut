using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{  
    [SerializeField] AudioClip buttonPress;

    AudioController audioController;
    bool loadingScene;

    public void StartGame()
    {
        if (loadingScene)
            return;

        StartCoroutine(LoadGameScene());
    }

    IEnumerator LoadGameScene()
    {
        loadingScene = true;
        FindObjectOfType<AudioController>().PlaySfx(buttonPress);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

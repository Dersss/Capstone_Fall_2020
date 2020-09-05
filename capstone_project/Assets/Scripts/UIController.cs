using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public string mainMenuScene;
    public GameObject pauseMenu;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (isPaused) {
                ResumeGame();

            } else {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void ResumeGame() {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart() {
        SceneManager.LoadScene("Level1");
        UnityEngine.Debug.Log("Restarted the scene.");
    }

    public void ReturnToMain() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }
}

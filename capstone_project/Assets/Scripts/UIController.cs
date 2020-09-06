using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public string MainMenu;
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
                Cursor.lockState = CursorLockMode.Locked;
            } else {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
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
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ReturnToMain() {
        Time.timeScale = 1f;
        Debug.Log("Main menu loading..");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

    }
}

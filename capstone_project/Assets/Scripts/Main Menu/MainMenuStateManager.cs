using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStateManager : MonoBehaviour
{
    public GameObject MainStateObject, LevelSelectStateObject, OptionsStateObject;
    private AudioSource buttonAudioSource;

    void Start()
    {
        buttonAudioSource = gameObject.GetComponent<AudioSource>();
        MainStateObject.SetActive(true);
        LevelSelectStateObject.SetActive(false);
        OptionsStateObject.SetActive(false);
    }

    public void SwitchToLevelSelect()
    {
        MainStateObject.SetActive(false);
        LevelSelectStateObject.SetActive(true);
        LevelSelectStateObject.GetComponentInChildren<LevelSelectManager>().PopulateLevelList();
        playButtonAudio();
    }

    public void BackToMainFromLevelSelect()
    {
        LevelSelectStateObject.SetActive(false);
        MainStateObject.SetActive(true);
        LevelSelectStateObject.GetComponentInChildren<LevelSelectManager>().ResetLevelList();
        playButtonAudio();
    }
    public void SwitchToOptions()
    {
        MainStateObject.SetActive(false);
        OptionsStateObject.SetActive(true);
        playButtonAudio();
    }
    public void BackToMainFromOptions()
    {
        OptionsStateObject.SetActive(false);
        MainStateObject.SetActive(true);
        playButtonAudio();
    }

    public void QuitButtonFunction()
    {
        playButtonAudio();
        Debug.Log("Quit!");
        Application.Quit();
    }

    private void playButtonAudio()
    {
        buttonAudioSource.Play();
    }
}

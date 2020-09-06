using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
{
    public int SceneBuildIndex;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneBuildIndex);
    }
}

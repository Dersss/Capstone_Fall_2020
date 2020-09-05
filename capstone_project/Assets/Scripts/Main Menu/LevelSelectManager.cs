using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    public GameObject ListObject, LevelButtonPrefab;
    private GameObject listViewportObject, listContentObject;
    private float minimumContentHeight, buttonHeight, buttonWidth;
    private List<GameObject> levelButtons = new List<GameObject>();

    void Start()
    {
        listViewportObject = ListObject.transform.GetChild(0).gameObject;
        listContentObject = listViewportObject.transform.GetChild(0).gameObject;

        minimumContentHeight = listViewportObject.GetComponent<RectTransform>().rect.height;
        buttonHeight = LevelButtonPrefab.GetComponent<RectTransform>().rect.height;
        buttonWidth = LevelButtonPrefab.GetComponent<RectTransform>().rect.width;
    }

    //eventually data-driven, called when level select is activated 
    public void PopulateLevelList()
    {
        //runs Start if it hasn't been run yet, in the case of the menu manager calling this before it runs
        if(listViewportObject == null)
        {
            Start();
        }

        //import list of levels, probably from XML or something
        //for now, sample data
        int count;
        for (count = 0; count < 4; count++)
        {
            levelButtons.Add(Instantiate(LevelButtonPrefab, listContentObject.transform));
            levelButtons[count].transform.localPosition = new Vector3(buttonWidth/2, -buttonHeight/2 + (count*-buttonHeight), 0);
            levelButtons[count].GetComponentInChildren<UnityEngine.UI.Text>().text = "Level " + count;
            //levelButtons[count].GetComponentInChildren<UnityEngine.UI.Image>().sprite = 
            //set button event to right scene
        }

        if(count*buttonHeight > minimumContentHeight)
        {
            SetContentHeight(count*buttonHeight);
        } else
        {
            SetContentHeight(minimumContentHeight);
        }
    }


    //called when level select is deactivated
    public void ResetLevelList()
    {
        for (int i = 0; i < levelButtons.Count;i++)
        {
            Destroy(levelButtons[i]);
        }
        levelButtons.Clear();
        SetContentHeight(minimumContentHeight);
    }

    private void SetContentHeight(float height)
    {
        listContentObject.GetComponent<RectTransform>().sizeDelta = new Vector2(listContentObject.GetComponent<RectTransform>().sizeDelta.x, height);
    }
}

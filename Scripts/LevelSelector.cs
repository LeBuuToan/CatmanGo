using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public Button[] lvlButtons;

    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAT", 2);

        for(int i =0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
                lvlButtons[i].interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1_Button()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2_Button()
    {
        //SceneManager.LoadScene("Level1");
    }

    public void Level3_Button()
    {
        //SceneManager.LoadScene("Level1");
    }

    public void Level4_Button()
    {
        //SceneManager.LoadScene("Level1");
    }

    public void Level5_Button()
    {
        //SceneManager.LoadScene("Level1");
    }

    public void Level6_Button()
    {
        //SceneManager.LoadScene("Level1");
    }

    public void Level7_Button()
    {
        //SceneManager.LoadScene("Level1");
    }

    public void Level8_Button()
    {
        //SceneManager.LoadScene("Level1");
    }

    public void Level9_Button()
    {
       //SceneManager.LoadScene("Level1");
    }

    public void Level10_Button()
    {
        //SceneManager.LoadScene("Level1");
    }
}

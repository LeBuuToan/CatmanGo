using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Image SettingImage;
    public Image MenuImage;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;     
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Setting()
    {
        SettingImage.gameObject.SetActive(true);
        MenuImage.gameObject.SetActive(false);
    }

    public void ExitSetting()
    {
        SettingImage.gameObject.SetActive(false);
        MenuImage.gameObject.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}

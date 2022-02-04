using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{
    private GameController gc;
    private UIManager ui;

    public GameObject textDisplay;
    public float secondleft;
    public bool takingAway = false;
    public float moreTime;

    public bool plusTime = false;
    public GameObject plusTimeImage;

    float timeCount = 2;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        ui = GameObject.Find("UIManager").GetComponent<UIManager>();

        Time.timeScale = 1f;

        textDisplay.GetComponent<Text>().text = secondleft.ToString();      
    }

    void Update()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (gc.counterDownDone == false || ui.paused == true || gc.m_isGameover == true)
        {
            return;
        }

        textDisplay.GetComponent<Text>().text = Mathf.Round(secondleft).ToString();

        if (secondleft > 0)
        {
            takingAway = true;
            TimerTake();
            StopSpawnPlusTime();
        }
        else if (secondleft <= 0)
        {
            takingAway = false;
            gc.m_isGameover = true;
        }

        if (plusTimeImage == true)
        {
            timeCount -= Time.deltaTime;
        }
    }

    // Thoi gian dem nguoc
    void TimerTake()
    {
        if(takingAway == true)
        {
            secondleft -= Time.deltaTime;
        }
    }


    // Tang thoi gian cho Player
    public void MoreTime()
    {
        secondleft = secondleft + moreTime;
        plusTimeImage.SetActive(true);
    }

    // Tat hien thi + thoi gian
    void StopSpawnPlusTime()
    {
        if(timeCount <= 1)
        {
            plusTimeImage.SetActive(false);
            timeCount = 2;
        }
    }
}

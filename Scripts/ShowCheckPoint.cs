using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCheckPoint : MonoBehaviour
{
    private PlayerCheckPoint playerCP;

    public GameObject checkPoint;
    int oneCP = 0;
    float timeCount = 2;

    void Start()
    {
        playerCP = FindObjectOfType<PlayerCheckPoint>();
    }

    void FixedUpdate()
    {
        CheckPoint();

        if ((playerCP.flag1Position == true || playerCP.flag2Position == true) && oneCP == 0)
        { 
            checkPoint.SetActive(true);
            timeCount -= Time.deltaTime;
        }          
    }

    //Dieu khien hien thi Check Point
    void CheckPoint()
    {
        if (timeCount <= 0)
        {           
            checkPoint.SetActive(false);
            oneCP = 1;
        }
    }
}




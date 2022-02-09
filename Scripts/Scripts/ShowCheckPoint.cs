using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCheckPoint : MonoBehaviour
{
    public GameObject checkPoint;
    //int oneCP;
    float timeCount = 2;

    void FixedUpdate()
    {
        CheckPoint();

        if (PlayerCheckPoint.Instance.flagPosition == 2 && timeCount > 0)
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
        }
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCountDown : MonoBehaviour
{
    private GameController gc;

    public void SetCountDownNow()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();

        gc.counterDownDone = true;
          
    }
}

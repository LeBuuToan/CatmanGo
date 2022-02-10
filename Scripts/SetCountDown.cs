using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCountDown : MonoBehaviour
{
    public void SetCountDownNow()
    {
        GameController.Instance.counterDownDone = true;         
    }
}

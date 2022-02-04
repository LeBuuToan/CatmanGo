using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusTime : MonoBehaviour
{
    public GameObject textDisplay;
    public int plusTime;

    //Hien thi Time tren Text
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        textDisplay.GetComponent<Text>().text = "+" + plusTime + "s";
    }
 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private TimerCountDown timeCD;
    
    void Start()
    {
        timeCD = FindObjectOfType<TimerCountDown>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            timeCD.MoreTime();
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            TimerCountDown.Instance.MoreTime();
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : Singleton<PlayerCheckPoint>
{
    public GameObject[] flag;
    public int flagPosition;

    Vector3 spawnPoint1;
    Vector3 spawnPoint2;
    public bool flag2Position;

    // Update is called once per frame
    void LateUpdate()
    {
        if (Player.Instance.respawnPlayer == true || gameObject.transform.position.y < -18f)
        {
            if (flagPosition == 1)
            {
                gameObject.transform.position = spawnPoint1;
            }

            if (flagPosition == 2)
            {
                gameObject.transform.position = spawnPoint2;
            }
        }
    }

    //Bat va cham lay Check Point
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CheckPoint1"))
        {
            flagPosition = 1;
            spawnPoint1 = gameObject.transform.position;        
            spawnPoint1 = flag[0].transform.position;
        }

        if (other.gameObject.CompareTag("CheckPoint2"))
        {
            flagPosition = 2;
            spawnPoint2 = gameObject.transform.position;
            spawnPoint2 = flag[1].transform.position;
            Destroy(flag[0]);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{
    private Player player;

    public GameObject[] flag;

    Vector3 spawnPoint1;
    public bool flag1Position;

    Vector3 spawnPoint2;
    public bool flag2Position;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.respawnPlayer == true || gameObject.transform.position.y < -18f)
        {
            if (flag1Position == true)
            {
                gameObject.transform.position = spawnPoint1;
            }

            if (flag2Position == true)
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
            flag1Position = true;
            spawnPoint1 = gameObject.transform.position;        
            spawnPoint1 = flag[0].transform.position;
        }

        if (other.gameObject.CompareTag("CheckPoint2"))
        {
            flag1Position = false;
            flag2Position = true;
            spawnPoint2 = gameObject.transform.position;
            spawnPoint2 = flag[1].transform.position;
            Destroy(flag[0]);
        }
    }
}

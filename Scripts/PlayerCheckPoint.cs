using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{
    private Player player;

    public GameObject flag1;
    public bool flag1Position = false;
    Vector3 spawnPoint1;

    public GameObject flag2;
    public bool flag2Position = false;
    Vector3 spawnPoint2;
    

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
            spawnPoint1 = gameObject.transform.position;
            flag1Position = true;
            spawnPoint1 = flag1.transform.position;
        }

        if (other.gameObject.CompareTag("CheckPoint2"))
        {
            spawnPoint2 = gameObject.transform.position;
            flag1Position = false;
            flag2Position = true;
            spawnPoint2 = flag2.transform.position;
            Destroy(flag1);
        }
    }
}

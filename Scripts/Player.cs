using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private GameController gc;
    private UIManager ui;

    public float spawnTime;

    float m_spawnTime;

    private Touch touch;
    public float moveSpeed;

    public Animator anim;

    public bool jump = false;
    public bool run = false;

    int oneJump;

    public Rigidbody playerRb;

    public float dashSpeed;
    public bool isDashing;

    public AudioSource myAudio;

    public AudioClip jumpSound;

    float timeCount = 2;
    public bool respawnPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        ui = GameObject.Find("UIManager").GetComponent<UIManager>();

        playerRb = GetComponent<Rigidbody>();
        myAudio = GetComponent<AudioSource>();
        m_spawnTime = 0;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (gc.counterDownDone == false || ui.paused == true || gc.m_isGameover == true)
        {
            m_spawnTime = 0;
            run = false;
            return;
        }

        m_spawnTime -= Time.deltaTime;

        if (m_spawnTime < 0)
        {
            Time.timeScale = 1f;
            DragMove();
       
            m_spawnTime = spawnTime;
        }
    }

    void FixedUpdate()
    {
        if (isDashing == true)
        {
            Dashing();
        }

        SpawnControl();
        if (respawnPlayer == true)
        {
            timeCount -= Time.time;
        }
    }

    //Dash
    private void Dashing()
    {
        playerRb.AddForce(transform.forward * dashSpeed, ForceMode.VelocityChange);
        isDashing = false;
        jump = false;
        oneJump = 2;
    }

    //Dieu khien Player
    public void DragMove()
    { 
        if (Input.touchCount > 0)
        {                
            Touch touch = Input.GetTouch(0);
 
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                   transform.position.x + touch.deltaPosition.x * Time.deltaTime * moveSpeed,
                   transform.position.y,
                   transform.position.z);

                run = true;
            }          
        }
        else
        {
            run = false;
        }
    }

    //Animation
    void OnAnimatorMove()
    {
        if (oneJump == 1 && jump == true) 
        {           
            isDashing = true;
            anim.SetBool("isJump", true);
            
            transform.position = new Vector3(
                   transform.position.x,
                   transform.position.y + 3f,
                   transform.position.z + 0.3f);

            oneJump += 1;
        }
        else if (jump == false)
        {           
            anim.SetBool("isJump", false);
        }

        if (run == true)
        {
            anim.SetBool("isRun", true);
           
            transform.position = new Vector3(
                   transform.position.x,
                   transform.position.y,
                   transform.position.z + 0.09f);
        }
        else if (run == false)
        {
            anim.SetBool("isRun", false);
        }
    }

    //Va Cham Trigger
    public void OnTriggerEnter(Collider other)
    {
        /*
        if(other.gameObject.tag == "Coin")
        {
            
        }
        

        if (other.gameObject.tag == "DeathZone")
        {
            //Debug.Log("Death");
            //gc.m_isGameover = true;
            //respawnPlayer = true;
        }
        */

        if (other.gameObject.tag == "DeathPoint")
        {
            //Debug.Log("Death");
            //gc.m_isGameover = true;
            respawnPlayer = true;
        }
    }

    //Va cham Collision
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {           
            //Debug.Log("Cham Dat!");
            jump = false;
            oneJump = 0;
        }
    }

    //Nut Jump
    public void JumpButton()
    {
        try
        {
            if (gc.counterDownDone == true && oneJump == 0)
            {              
                oneJump += 1;
                JumpControl();    
            }
        }
        catch
        {

        }            
    }

    //Dieu khien Jump
    void JumpControl()
    {      
        if (oneJump == 1 && myAudio && jumpSound)
        {
            jump = true;
            //myAudio.PlayOneShot(jumpSound, 1);                            
        }  
    }

    //Spawn Player ve CheckPoint
    void SpawnControl()
    {
        if(timeCount <= 1)
        {
            if(respawnPlayer == true)
            {
                respawnPlayer = false;
                oneJump = 0;
                timeCount = 2;
            }                      
        }
    }   
}

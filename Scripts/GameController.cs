using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    UIManager m_ui;
    private Player player;

    public bool counterDownDone = false;
    public GameObject CountDownImage;
    public GameObject PlayerGo;
    public GameObject SwipeIconImage;
    public GameObject JumpButton;

    public float spawnTime;

    float m_spawnTime;

    public bool m_isGameover = false;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        player = FindObjectOfType<Player>();

        Time.timeScale = 1f;
    }

    void FixedUpdate()
    {
        if (m_isGameover)
        {
            m_spawnTime = 0;
            PlayerGo.SetActive(false);
            JumpButton.SetActive(false);
            m_ui.showGameOverPanel(true);
            return;
        }

        m_spawnTime -= Time.deltaTime;

        if (m_spawnTime <= 0)
        {
            if (counterDownDone)
            {
                CountDownImage.SetActive(false);
            }

            m_spawnTime = spawnTime;
        }

        if (player.run == true)
        {
            SwipeIconImage.SetActive(false);
        }
    }
}
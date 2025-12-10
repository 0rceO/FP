using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDmg : MonoBehaviour
{   
    SoundManager soundManager;
    public int life = 5;
    [SerializeField] GameObject lifeText;
    [SerializeField] GameObject deathPanel;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        lifeText.GetComponent<TextMeshProUGUI>().text = "HP: " + life.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {
            life = 0;
            Death();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Target")
        {
            soundManager.playSFX(soundManager.playerHurt);

            life -= 1;
            Debug.Log("Player Hit" + life);
            lifeText.GetComponent<TextMeshProUGUI>().text = "HP: " + life.ToString();
            
        }    
    }

    void Death()
    {
        deathPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }
}

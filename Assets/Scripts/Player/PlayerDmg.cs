using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDmg : MonoBehaviour
{   
    SoundManager soundManager;
    public int maxLife = 5;
    int currentLife;
    [SerializeField] GameObject lifeText;
    [SerializeField] GameObject deathPanel;

    [SerializeField] GameObject weaponObject;
    [SerializeField] Animator handAnimator;

    int callDeathFunction = 0;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        currentLife = maxLife;
        lifeText.GetComponent<TextMeshProUGUI>().text = currentLife.ToString() + " / " + maxLife.ToString();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLife <= 0)
        {
            currentLife = 0;
            if (callDeathFunction == 0)
            {
                StartCoroutine(Death());
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Target")
        {
            soundManager.playSFX(soundManager.playerHurt);

            currentLife -= 1;
            Debug.Log("Player Hit" + currentLife);
            lifeText.GetComponent<TextMeshProUGUI>().text = currentLife.ToString() + " / " + maxLife.ToString();

        }    
    }

    IEnumerator Death()
    {
        handAnimator.SetTrigger("Dead");
        weaponObject.SetActive(false);
        callDeathFunction = 1;

        yield return new WaitForSeconds(2);

        deathPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }
}

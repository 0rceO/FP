using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDmg : MonoBehaviour
{
    public int life = 5;
    [SerializeField] GameObject lifeText;

    // Start is called before the first frame update
    void Start()
    {
        lifeText.GetComponent<TextMeshProUGUI>().text = "HP: " + life.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {
            life = 0;
            Debug.Log("Dead");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Target")
        {
            life -= 1;
            Debug.Log("Player Hit" + life);
            lifeText.GetComponent<TextMeshProUGUI>().text = "HP: " + life.ToString();
        }    
    }
}

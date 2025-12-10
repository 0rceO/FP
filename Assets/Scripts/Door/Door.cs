using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    SoundManager soundManager;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    public string getDescription()
    {
        return "Need 50 points to open the Door";
    }

    public void interact()
    {
        Points pointsManager = GameObject.FindGameObjectWithTag("Points").GetComponent<Points>();
        if (pointsManager != null && pointsManager.points >= 50)
        {
            soundManager.playSFX(soundManager.doorOpen);
            pointsManager.points -= 50;
            Destroy(gameObject);
        }else
        {
            soundManager.playSFX(soundManager.lockedDoor);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public string getDescription()
    {
        return "Need 50 points to open the Door";
    }

    public void interact()
    {
        Points pointsManager = GameObject.FindGameObjectWithTag("Points").GetComponent<Points>();
        if (pointsManager != null && pointsManager.points >= 50)
        {
            pointsManager.points -= 50;
            Destroy(gameObject);
        }
    }
}

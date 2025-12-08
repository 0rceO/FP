using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeDoor : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject escapePanel;
    public string getDescription()
    {
        return "Need 0 points to open the Door";
    }

    public void interact()
    {
        Points pointsManager = GameObject.FindGameObjectWithTag("Points").GetComponent<Points>();
        if (pointsManager != null && pointsManager.points >= 0)
        {
            escapePanel.SetActive(true);
            Time.timeScale = 0f;
            
        }
    }
}

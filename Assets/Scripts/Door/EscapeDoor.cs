using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeDoor : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject escapePanel;
    public string getDescription()
    {
        return "Need 300 points to Escape";
    }

    public void interact()
    {
        Points pointsManager = GameObject.FindGameObjectWithTag("Points").GetComponent<Points>();
        if (pointsManager != null && pointsManager.points >= 0)
        {
            escapePanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }
}

    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject MainMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        MainMenuUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        Time.timeScale = 1f;
        playerUI.SetActive(true);
        MainMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}

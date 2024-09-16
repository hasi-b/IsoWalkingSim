using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine.Rendering;
using System;
using DG.Tweening;
public class SceneManagerUI : MonoBehaviour
{

    public GameObject GateGameObject;

    public static SceneManagerUI instance;

    [SerializeField]public static int counter;

    public GameObject Khamba;
    public GameObject Player;


    public bool Resume = false;

    public Canvas canvas;
    public GameObject mainmenuvolume;
    public GameObject gameplayvolume;
    public CanvasGroup optionPanel;
    public CanvasGroup MainMenuPanel;
    public Camera mainMenuCamera;
    public Camera gameplayCamera;
    private CinemachineBrain cinemachineBrain;
    private bool gamePaused = false;


    public GameObject[] panels; // Array of panels to display
    public int currentPanel = 0; // Index of initial panel to display
    private int previousPanel = 0;


    private void Awake()
    {

        instance = this;


        counter = 0;


        Player.GetComponent<PlayerInputSystem>().enabled = false;

        GateGameObject.tag = "Untagged"; 

    }



    void Start()
    {
        // Start with the main menu camera enabled and the gameplay camera disabled
        cinemachineBrain = gameplayCamera.GetComponent<CinemachineBrain>();

        mainMenuCamera.enabled = true;
        gameplayCamera.enabled = false;
        cinemachineBrain.enabled = false;

        for (int i = 1; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }

    }

    void Update()
    {
        // Check for the "Escape" key to pause/unpause the game and return to the main menu


        if (Input.GetKeyDown(KeyCode.Escape) && Resume == true)
        {
            if (gamePaused)
            {
                // Unpause the game and switch to the gameplay camera
                Time.timeScale = 1;
                canvas.gameObject.SetActive(false);
                gameplayCamera.enabled = true;
                cinemachineBrain.enabled = true;
                gamePaused = false;
            }
            else
            {
                // Pause the game and switch to the main menu camera
                Time.timeScale = 0;
                canvas.gameObject.SetActive(true);

                gamePaused = true;
            }
        }





        if (counter > 3)
        {
            GateGameObject.tag = "NPC";
           
        }


    }

    void TransitionToPanel(int panelIndex)
    {
        // Get the current and target panels
        GameObject current = panels[currentPanel];
        GameObject target = panels[panelIndex];

        // Slide the current panel out
        //cu/*rrent.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.5f);

        // Enable the target panel
        target.SetActive(true);

        // Scale up the target panel
        //target.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        //target.transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f);



        // Disable the current panel
        current.SetActive(false);

        // Update the current panel index and previous panel index
        previousPanel = currentPanel;
        currentPanel = panelIndex;
    }

    public void NextPanel()
    {
        int nextIndex = currentPanel + 1;
        if (nextIndex >= panels.Length)
        {
            nextIndex = 0;
        }
        TransitionToPanel(nextIndex);
    }

    public void PreviousPanel()
    {
        TransitionToPanel(previousPanel);
    }


    public void OnResumeButtonPressed()
    {
        Time.timeScale = 1;
        canvas.gameObject.SetActive(false);
        gameplayCamera.enabled = true;
        cinemachineBrain.enabled = true;
        gamePaused = false;
    }


    public void OnPlayButtonPressed()
    {

        mainmenuvolume.SetActive(false);
        gameplayvolume.SetActive(true);
        mainMenuCamera.enabled = false;
        gameplayCamera.enabled = true;
        cinemachineBrain.enabled = true;



        Player.GetComponent<PlayerInputSystem>().enabled = true;

        Resume = true;

        Khamba.SetActive(false);








    }





   

    public void OnQuitButtonPressed()
    {

        Application.Quit();
    }

}

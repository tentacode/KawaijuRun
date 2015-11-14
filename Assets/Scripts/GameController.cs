﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public MainCharacterController mainCharacterController;
    public InputController inputController;
    public GameObject splashScreen;
    public GameObject mainUI;

    void Update () 
    {
        if (mainCharacterController.getState() == MainCharacterController.States.Dead && inputController.IsTap()) {
            RestartGame();
        }

        if (mainCharacterController.getState() == MainCharacterController.States.Start && inputController.IsTap()) {
            StartGame();
        }
	}

    void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void StartGame()
    {
        mainCharacterController.SetState(MainCharacterController.States.Idle);

        splashScreen.SetActive(false);
        mainUI.SetActive(true);
    }
}

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public MainCharacterController mainCharacterController;
    public InputController inputController;
    public GameObject splashScreen;
    public GameObject mainUI;

    void Update () 
    {
        if (mainCharacterController.getState() == MainCharacterController.States.Start && inputController.IsTap()) {
            StartGame();
        }

        if (inputController.IsTap()) {
            Debug.Log(mainCharacterController.getState());
        }

        if (mainCharacterController.getState() == MainCharacterController.States.Dead && inputController.IsTap()) {
            RestartGame();
        }

	}

    void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void StartGame()
    {
        mainCharacterController.SetState(MainCharacterController.States.Idle);

        setAllBackgroundLaunchPosition();

        splashScreen.SetActive(false);
        mainUI.SetActive(true);
    }

    void setAllBackgroundLaunchPosition()
    {
        GameObject[] backgroundsController = GameObject.FindGameObjectsWithTag("Background");

        foreach(GameObject go in backgroundsController)
        {
            go.GetComponent<BackgroundScroller>().setLaunchPosition();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public Button startButton;
    public GameObject startMenu;

    public float restartDelay = 2f;

    public GameObject completeLevelUI;

    public GameObject player;

    public Text MilestoneText;

    private void OnEnable()
    {
        PlayerCollision.OnHitObstacle += EndGame;
        Score.milestone += DisplayMilestone;
    }

    private void OnDisable()
    {
        PlayerCollision.OnHitObstacle -= EndGame;
        Score.milestone -= DisplayMilestone;
    }

    public void DisplayMilestone(int number)
    {
        Debug.Log("This Event Worked!");
        MilestoneText.text = number.ToString("0");
        MilestoneText.enabled = true;

        Invoke("CloseMilestone", 1.0f);
    }

    public void CloseMilestone()
    {
        MilestoneText.enabled = false;
        Score.milestone -= DisplayMilestone;
    }
    public void CompleteLevel ()
    {
        completeLevelUI.SetActive(true);
    }
    public void EndGame(Collision collisionInfo)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        PlayerCollision.OnHitObstacle -= EndGame;

        if (collisionInfo != null)
        {
            Debug.Log("Hit: " + collisionInfo.collider.name);
        }

        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<PlayerMovement>().gameStart = false;
        startMenu.SetActive(true);
    }

    public void OnStartButton ()
    {
        FindObjectOfType<PlayerMovement>().gameStart = true;
        startMenu.SetActive(false);
    }
}

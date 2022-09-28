using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;
    public int playerScore;

    public bool Reach = false;

    public delegate void Milestone(int mark);
    public static event Milestone milestone;

    void Update()
    {
        scoreText.text = player.position.z.ToString("0");

        if (scoreText.text == "100" && Reach == false)
        {
            Reach = true;
            milestone(100);
            Invoke("ResetMilestone", 0.2f);
        }

        if (scoreText.text == "200" && Reach == false)
        {
            Reach = true;
            milestone(200);
            Invoke("ResetMilestone", 0.2f);
        }
    }

    public void ResetMilestone()
    {
        Reach = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public delegate void HitObstacle(Collision collisionInfo);
    public static event HitObstacle OnHitObstacle;

    public PlayerMovement movement;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            if (OnHitObstacle != null)
            {
                OnHitObstacle(collisionInfo);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockObs : MonoBehaviour
{
    public GameObject block;
    public GameObject player;

    int stop;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(stop < 1)
            {
                stop++;
            }
        }
    }


}

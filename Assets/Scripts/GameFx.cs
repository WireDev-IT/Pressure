using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFx : MonoBehaviour
{
    public AudioSource[] soundFx;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            soundFx[0].Play();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            soundFx[1].Play();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            soundFx[2].Play();
        }
    }
}

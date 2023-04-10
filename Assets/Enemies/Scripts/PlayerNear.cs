using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNear : MonoBehaviour
{
    public bool playerNear = false;
    AudioSource chompsound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            chompsound = GetComponent<AudioSource>();
            playerNear = true;
            chompsound.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
        }
    }

    public bool IsPlayerNear()
    {
        return playerNear;
    }
}


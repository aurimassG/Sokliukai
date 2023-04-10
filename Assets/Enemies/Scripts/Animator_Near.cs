using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Near : MonoBehaviour
{
    private Animator animator;
    private PlayerNear objectDetector;

    private void Start()
    {
        animator = GetComponent<Animator>();
        objectDetector = GetComponent<PlayerNear>();
    }

    private void Update()
    {
        if (objectDetector.IsPlayerNear())
        {
            animator.SetTrigger("PlayerNear");
        }
        else
        {
            animator.SetTrigger("PlayerNotNear");
        }
    }
}

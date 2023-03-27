using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.tag == "Player")
        //{
        //    Debug.Log("Mirei nuo spasto");
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
        if(collision.GetComponent<PlayerMovement>() != null)
        {
            Debug.Log("Mirei nuo spasto");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

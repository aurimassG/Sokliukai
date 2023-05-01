using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.GetComponent<PlayerMovement>() != null)
        {
            var healthComponent = collision.GetComponent<Health>();
            healthComponent.TakeDamage(1);

            //Debug.Log("Mirei nuo spasto");
           // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

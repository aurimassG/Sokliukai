using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Foe_Kills : MonoBehaviour
{
    //Health hp;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var hp = collision.gameObject.GetComponent<Health>();
            if (hp != null)
            {
                hp.TakeDamage(1);
            }
        }
    }
}


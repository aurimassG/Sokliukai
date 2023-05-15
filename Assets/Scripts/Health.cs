using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealt = 3;
    public int currentHealth;
    public Animator animator;
    public AudioSource audio;

    private Vector3 respawnPoint;
    public GameManagerScript gameManager;
    private bool isDead;
    void Start()
    {
        currentHealth = maxHealt;
    }
    void Update()
    {
        if (transform.position.y <= -30)
        {
            TakeDamage(1);
            Respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }
    public void TakeDamage(int amount)
    {
            currentHealth -= amount;
      
            animator.SetTrigger("Hurt");
            audio.Play();
        
        
        if (currentHealth <= 0 && !isDead)
        {
            
            isDead = true;
            gameManager.gameOver();
            Time.timeScale = 0;
            Debug.Log("Pasibaige gyvybes");
        }
        
    }

    public void Respawn()
    {
        transform.position = respawnPoint;
    }

}

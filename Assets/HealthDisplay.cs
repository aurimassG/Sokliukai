using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int Health;
    public int MaxHealth;

    public Sprite emptyHearth;
    public Sprite fullHearth;
    public Image[] hearts;

    public Health playerhealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Health = playerhealth.currentHealth;
        MaxHealth = playerhealth.maxHealt;

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < Health)
            {
                hearts[i].sprite = fullHearth;
            }
            else
            {
                hearts[i].sprite = emptyHearth ;
            }

        }
    }
}

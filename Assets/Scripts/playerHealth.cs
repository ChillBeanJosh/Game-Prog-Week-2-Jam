using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("current health is: " + currentHealth);

        if (currentHealth <= 0)
        {
            PlayerKilled();
        }
    }

    private void PlayerKilled()
    {
        Debug.Log("Player is dead");
        Destroy(gameObject);
    }



}

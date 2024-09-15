using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

    public float moveSpeed;

    public float attackDamage;
    public float attackRange;
    public float attackCooldown;

    private bool isAttacking = false;


    private void Update()
    {
        //If there is a refrence to the player transformation, it will begin MoveToPlayer().
        if (player != null)
        {
            MoveToPlayer();
        }
        
    }


    void MoveToPlayer()
    {
        //Calculates the distance between the player and enemy object, used for attack range.
        float distance = Vector3.Distance(transform.position, player.position);

        //Moves towards the player
        if (distance > attackRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        else
        {
            if (!isAttacking)
            {
               // StartCoroutine(Attack());
            }
        }
    }


    private IEnumerator Attack()
    {
        isAttacking = true;

        //Refrence to player health script.
        playerHealth playerHealth = player.GetComponent<playerHealth>();


        //Deals Damage.
        if (playerHealth != null)
        {
            Debug.Log("Damage dealt is: " + attackDamage);
            playerHealth.TakeDamage(attackDamage);
        }

        //Attack cooldown.
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;

    }

}

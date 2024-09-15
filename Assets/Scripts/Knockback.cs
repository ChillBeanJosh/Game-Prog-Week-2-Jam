 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockback;
    public float timeTillDestroy;

    public LayerMask enemyLayer;
    public Animator animator;



    //Active when detection the enemy layer.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();

            //Knockback effect.
            if (enemyRb != null)
            {
                animator.SetTrigger("isSwinging");

                Vector3 knockbackDirection = other.transform.position - transform.position;
                knockbackDirection.y = 0;

                enemyRb.AddForce(knockbackDirection.normalized * knockback, ForceMode.Impulse);

                //Destroys the enemy after specified time frame.
                Destroy(other.gameObject, timeTillDestroy);
            }
        } 
    }
}

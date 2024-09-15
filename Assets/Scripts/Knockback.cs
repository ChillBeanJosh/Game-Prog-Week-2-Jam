 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockback;
    public float timeTillDestroy;

    public LayerMask enemyLayer;



    //Active when detection the enemy layer.
    private void OnTriggerStay(Collider other)
    {
        if ((enemyLayer & (1 << other.gameObject.layer)) != 0)
        {
            ApplyKnockback(other);

            StartCoroutine(Destroy());
        }
    }

    //creates the knockback force and applies it to the rigidbody of the collided enemy.
    private void ApplyKnockback(Collider enemy)
    {
        Vector3 knockbackDirection = (transform.position - enemy.transform.position).normalized;

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(knockbackDirection * knockback, ForceMode.Impulse);
        }

        Debug.Log("Enemy has been knocked back");
    }

    //After waiting x amount of seconds, destroys the collided game object.
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(timeTillDestroy);
        Destroy(gameObject);
    }
}

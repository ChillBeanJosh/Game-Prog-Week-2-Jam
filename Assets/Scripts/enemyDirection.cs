using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDirection : MonoBehaviour
{

    public Transform Target;

    //Used to that the enemy is looking towards the player when approching.
    void Update()
    {
        transform.LookAt(Target);
    }
}

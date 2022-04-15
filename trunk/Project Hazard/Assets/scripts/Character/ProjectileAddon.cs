using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{


void OnTriggerEnter(Collider other)
{
    HealthyEnemy H = other.GetComponent<HealthyEnemy>();
    if( H == null) return;
    {
        H.HealthPoints -= 10f;  
    }
    Destroy(gameObject);
}

}

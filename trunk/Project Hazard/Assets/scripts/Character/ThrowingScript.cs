using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingScript : MonoBehaviour
{

    
public Transform cam;
public Transform attackPoint;
public GameObject TridentToThrow;

public int TotalThrows;
public float ThrowCooldown;

public KeyCode throwKey = KeyCode.Mouse1;
public float throwForce;
public float throwUpwardForce;

bool readyToThrow;

  public void Start()
    {
    readyToThrow = true;
    }
public void Update()
{
    if(Input.GetKeyDown(throwKey) && readyToThrow && TotalThrows >0)
    {
        Throw();
    }
}

public void Throw()
{
    readyToThrow = false;

    //instantiate object to throw.

    GameObject projectile = Instantiate (TridentToThrow, attackPoint.position, cam.rotation);

    //Get rigidbody component

    Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();

//Calculate Direction

Vector3 forceDirection =cam.transform.forward;
RaycastHit hit;
if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
{
    forceDirection = (hit.point - attackPoint.position).normalized;
}

    //Add Force

    Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;


// This designates the force be applied once rather than consistently
    projectileRB.AddForce(forceToAdd, ForceMode.Impulse);



//Decreases the amount of throws left
    TotalThrows--;

//This Implements the Coold Down of throwing tridents

Invoke(nameof(ResetThrow), ThrowCooldown);

}
public void ResetThrow()
{
    readyToThrow = true;
}
}
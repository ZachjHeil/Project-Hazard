using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBladeSwingerss : MonoBehaviour
{


public GameObject Sword;
public bool canAttack = true;
public float attackCoolDown = 1f;
PlasmaBladeWielder WieldPlasmaStat;



void Start()
{
    WieldPlasmaStat = GameObject.FindObjectOfType<PlasmaBladeWielder>();
}


void Update()
{
    if(Input.GetMouseButtonDown(0))
    {
        if(canAttack)
        {
            PlasmaBladeAttack();
        }
    }


}

public void PlasmaBladeAttack()
{
    canAttack = false;
    Animator anim = Sword.GetComponent<Animator>();
    anim.SetTrigger("Sword_Swing");
    StartCoroutine(ResetAttackCD());
}

void OnTriggerEnter(Collider other)
{
    HealthyEnemy H = other.GetComponent<HealthyEnemy>();
    if( H == null) 
    {
        return;
    }
    if(H != null)
    {
    H.HealthPoints -= WieldPlasmaStat.plasSwingDmg;
    }
}

IEnumerator ResetAttackCD()
{
    yield return new WaitForSeconds(attackCoolDown);
    canAttack = true;
}


}

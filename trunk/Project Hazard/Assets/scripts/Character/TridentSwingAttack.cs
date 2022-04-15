using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TridentSwingAttack : MonoBehaviour
{


public GameObject Trident_Attack_01;
public bool canAttack = true;
public float attackCoolDown = 1.0f;
TridentWielding WieldTridentStat;

void Start()
{
    WieldTridentStat = GameObject.FindObjectOfType<TridentWielding>();
}
void Update()
{
    if(Input.GetMouseButtonDown(0))
    {
        if(canAttack)
        {
            TridentAttack();
        }
    }


}

public void TridentAttack()
{
    canAttack = false;
    Animator anim = Trident_Attack_01.GetComponent<Animator>();
    anim.SetTrigger("Base_Attack");
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
        H.HealthPoints -= WieldTridentStat.tridSwingDmg ;
        //Debug.Log(H.HealthPoints);
        //Debug.Log(GameObject.FindGameObjectWithTag("Player").);
    }
}

IEnumerator ResetAttackCD()
{
    yield return new WaitForSeconds(attackCoolDown);
    canAttack = true;
}


}

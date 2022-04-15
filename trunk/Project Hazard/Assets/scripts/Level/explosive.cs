using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosive : MonoBehaviour
{
    public Elevator Elevator;

    void Start()
    {
        Elevator = FindObjectOfType<Elevator>();
    }
    
    void Update()
    {
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Elevator.explosive = true;
            Destroy(this.gameObject);
        }
    }
}

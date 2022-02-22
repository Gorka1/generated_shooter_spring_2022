using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Control : MonoBehaviour
{
    // this script is to control target specific behaviors
    [SerializeField] float health;
    [SerializeField] bool immortal = false;

    public void removeHealth(float dmg) { 
        health -= dmg;
        if (health <= 0 && !immortal) {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot_Barrel : MonoBehaviour
{
    private GameObject parent;
    private void Start() {
        parent = this.parent;
    }

    public void rot_object(float newAngle) {
        transform.RotateAround(parent.transform.position, Vector3.up, newAngle);
    }
}

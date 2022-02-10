using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Data : MonoBehaviour
{
    public Bullet_Scriptable bulletData;
    private int damage;     // do you need these var.s??
    private float size;
    private int range;

    private void Start() {
        this.GetComponent<SpriteRenderer>().sprite = bulletData.bulletImage;
        this.GetComponent<CircleCollider2D>().radius = bulletData.size;
    }

    private void Update() {
        // check to see how far it's travelled from its starting pos, if greater than range, self distruct
        // or do a timer, whatever is better for runtime
    }
}

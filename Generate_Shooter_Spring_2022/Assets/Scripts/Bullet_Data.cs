using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Data : MonoBehaviour
{
    public Rigidbody2D rb;
    public Bullet_Scriptable bulletData;
    private int damage;     // do you need these var.s??
    private float size;
    private int range;
    private float initTime; // keep track of time elapsed since init

    private void Start() {
        initTime = Time.time;
        this.GetComponent<SpriteRenderer>().sprite = bulletData.bulletImage;
        this.GetComponent<SpriteRenderer>().color = bulletData.bulletColor;
        // this.GetComponent<CircleCollider2D>().radius = bulletData.size;
        // transform.localScale = transform.localScale * size;
        rb.velocity = transform.right * bulletData.speed;
        Debug.Log(this.GetComponent<Rigidbody2D>().velocity);
        Debug.Log(transform.rotation.eulerAngles);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Target") {
            // do damage to the target
        }
        Destroy(this.gameObject);
    }

    private void Update() {
        // check to see how far it's travelled from its starting pos, if greater than range, self distruct
        // or do a timer, whatever is better for runtime

        // a timer (easier to do)
        float currTime = Time.time - initTime;
        if (currTime > bulletData.range) {
            Destroy(this.gameObject);
        }
        Debug.Log(currTime);
    }
}

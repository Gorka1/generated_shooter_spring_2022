using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Script : MonoBehaviour
{
    public Bullet_Scriptable bulletData;
    public GameObject bulletObj;
    public float fireRate;
    public int ammoCount;
    public float bulletVel = 100;
    [SerializeField]
    private List<GameObject> barrels;

    private void Start() {
        // get all the barrels of the gun obj
        GameObject tempObj;
        for (int i = 0; i < this.gameObject.transform.childCount; i++) {
            tempObj = this.gameObject.transform.GetChild(i).gameObject;
            if (tempObj.tag == "Barrel") {
                barrels.Add(tempObj);
            }
        }
    }

    private void spawnBullet(Vector3 location, Vector3 forwardDirec) {
        GameObject newBullet;
        // instantiating a clone of itself, not a bullet obj
        newBullet = Instantiate(bulletObj, location, Quaternion.LookRotation(forwardDirec));
        newBullet.GetComponent<Bullet_Data>().bulletData = bulletData;
        // force is not being added properly !!!
        newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.forward * bulletVel);
    }

    private void fire() {
        foreach (GameObject barrel in barrels)
        {
            spawnBullet(barrel.transform.position, barrel.transform.forward);
        }
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            fire();
        }
    }
}
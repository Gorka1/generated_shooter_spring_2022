using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Script : MonoBehaviour
{
    public Bullet_Scriptable bulletData;
    public GameObject bulletObj;
    public float fireRate;
    bool canFire = true;
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

    private void spawnBullet(Vector3 location, Quaternion forwardDirec) {
        GameObject newBullet;
        newBullet = Instantiate(bulletObj, location, forwardDirec);
        newBullet.GetComponent<Bullet_Data>().bulletData = bulletData;
        // Debug.Log(newBullet.transform.forward);
    }

    // needed for player_control firing
    public bool getCanFire() { return canFire; }

    // uses WaitForSeconds() for firerate, thus has to be an IEnum
    public IEnumerator fire() {
        canFire = false;
        foreach (GameObject barrel in barrels)
        {
            spawnBullet(barrel.transform.position, barrel.transform.rotation);
        }
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}

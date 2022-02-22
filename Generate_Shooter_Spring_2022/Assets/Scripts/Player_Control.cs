using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float range = 2f;
    public Rigidbody2D rb;
    //public GameObject targetBox;  // hold over from when colliders where used for target
    public GameObject currWeapon;
    // public Bullet_Scriptable currBullet;
    
    // Target_Box targetBoxScript;
    [SerializeField] private GameObject currTarget;
    Vector2 movement;

    private GameObject find_closest_target() {
        float currDist = 0;
        float currMin = Mathf.Infinity;
        GameObject returnObj = null;
        GameObject[] foundTargets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject currObj in foundTargets) {
            currDist = Vector2.Distance(this.transform.position, currObj.transform.position);
            if (currDist < currMin && currDist <= range) {
                returnObj = currObj;
                currMin = currDist;
            }
        }
        return returnObj;
    }

    private void turn_to_position(Vector3 inputPos) {
        inputPos.z = 0f;
        Vector3 objectPos = transform.position;
        inputPos.x = inputPos.x - objectPos.x;
        inputPos.y = inputPos.y - objectPos.y;

        float angle = Mathf.Atan2(inputPos.y, inputPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void switch_weapon(){
        
    }

    private void Start() {
        // targetBoxScript = targetBox.GetComponent<Target_Box>();
        //currTarget = targetBox;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButton("Fire1") && currWeapon.GetComponent<Gun_Script>().getCanFire()) {
            Debug.Log("Firing");
            StartCoroutine(currWeapon.GetComponent<Gun_Script>().fire());
        }
    }

    private void FixedUpdate() {
        // each frame get the closest target
        currTarget = find_closest_target();
        if (currTarget != null) {
            turn_to_position(currTarget.transform.position);
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

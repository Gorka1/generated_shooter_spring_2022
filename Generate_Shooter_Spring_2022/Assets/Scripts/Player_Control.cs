using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float range = 2f;
    public Rigidbody2D rb;
    public GameObject targetBox;
    
    Target_Box targetBoxScript;
    [SerializeField] private GameObject currTarget;
    Vector2 movement;

    // gets an
    // private GameObject get_closest(List<GameObject> input_list) {
    //     if (input_list.Count == 0) {
    //         return null;
    //     } else {
    //         GameObject curr_obj = null;
    //         float curr_low_val = 0;
    //         float curr_dist = 0;
    //         for (int i = 0; i < input_list.Count; i++) {
    //             curr_dist = Vector2.Distance(transform.position, input_list[i].transform.position);
    //             if (curr_obj == null || curr_dist < curr_low_val) {
    //                 curr_obj = input_list[i];
    //                 curr_low_val = curr_dist;
    //             }
    //         }
    //         return curr_obj;
    //     }
    // }

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
        targetBoxScript = targetBox.GetComponent<Target_Box>();
        //currTarget = targetBox;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        // if (targetBoxScript.get_target_list().Count == 0) {
        //     GameObject curr_target = get_closest(targetBoxScript.get_target_list());
        //     // turn the player to the curr_target

        // }
        // if (currTarget == null) {
        //     currTarget = targetBoxScript.get_target();
        // }
        currTarget = find_closest_target();
        if (currTarget != null) {
            turn_to_position(currTarget.transform.position);
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

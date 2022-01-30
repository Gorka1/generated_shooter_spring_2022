using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public GameObject targetBox;
    
    Target_Box targetBoxScript;
    Vector2 movement;

    // gets an
    private GameObject get_closest(List<GameObject> input_list) {
        if (input_list.Count == 0) {
            return null;
        } else {
            GameObject curr_obj = null;
            float curr_low_val = 0;
            float curr_dist = 0;
            for (int i = 0; i < input_list.Count; i++) {
                curr_dist = Vector2.Distance(transform.position, input_list[i].transform.position);
                if (curr_obj == null || curr_dist < curr_low_val) {
                    curr_obj = input_list[i];
                    curr_low_val = curr_dist;
                }
            }
            return curr_obj;
        }
    }

    private void Start() {
        targetBoxScript = targetBox.GetComponent<Target_Box>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        if (targetBoxScript.get_target_list().Count == 0) {
            GameObject curr_target = get_closest(targetBoxScript.get_target_list());
            // turn the player to the curr_target

        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

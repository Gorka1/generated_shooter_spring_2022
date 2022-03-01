using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Star_Nodes : MonoBehaviour
{
    public float x_dist;
    public float y_dist;
    public float raycast_dist;
    [SerializeField]
    // private BoxCollider2D selfBox;

    private void Start() {
        //selfBox = gameObject.GetComponent<BoxCollider2D>();
        gen_neighbors();
    }

    void gen_neighbors() {
        // selfBox.enabled = false;
        // raycast in all 8 directions to check if there's space
        for (int x = -1; x <= 1; x++) {
            for (int y = -1; y <= 1; y++) {
                if (y != 0 && x != 0) {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(x,y), raycast_dist);
                    if (hit.collider == null) {
                        Instantiate(gameObject, new Vector2(transform.position.x + x_dist, transform.position.y + y_dist), transform.rotation);
                    }
                }
            }
        }
        // selfBox.enabled = false;
    }
}

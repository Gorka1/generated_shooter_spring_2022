using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Box : MonoBehaviour
{
    // keeps track of all target obj within box range, add/removing them from list as they come and go
    static public List<GameObject> target_list; //rmb: static means all class instances share it

    // Start is called before the first frame update
    void Start()
    {
        target_list = new List<GameObject>();
    }

    public List<GameObject> get_target_list(){
        return target_list;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Target") {
            target_list.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Target" && target_list.Contains(other.gameObject) ) {
            target_list.Remove(other.gameObject);
        }
    }
}

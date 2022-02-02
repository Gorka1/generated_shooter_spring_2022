using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Box : MonoBehaviour
{
    // keeps track of all target obj within box range, add/removing them from list as they come and go
    [SerializeField] private List<GameObject> targetList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // targetList = new List<GameObject>();
    }

    // will return the closest target
    private GameObject get_closest(){
        GameObject returnObj = this.gameObject;
        float currDist = 0;
        float currLowVal = Mathf.Infinity;
        foreach(GameObject currObj in targetList) {
            currDist = Vector2.Distance(GetComponentInParent<Transform>().position, currObj.transform.position);
            if (returnObj == this.gameObject || currDist < currLowVal) {
                returnObj = currObj;
                currLowVal = currDist;
            }
        }
        return returnObj;
    }

    // gets a target, if no target found, returns itself
    public GameObject get_target(){
        if (targetList.Count == 0) {
            return this.gameObject;
        } else {
            return get_closest();
        }
    }

    public List<GameObject> get_target_list(){
        return targetList;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Target") {
            targetList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Target" && targetList.Contains(other.gameObject) ) {
            targetList.Remove(other.gameObject);
        }
    }
}

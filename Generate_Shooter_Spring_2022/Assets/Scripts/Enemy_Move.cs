using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public float speed;
    public float distance;
    public bool search = false;
    public Vector2 currTarget;
    public List<Vector2> targetList;
    [SerializeField] private A_Star aStarScript;
    [SerializeField] private GameObject playerGO;

    // Start is called before the first frame update
    void Start()
    {
        aStarScript = gameObject.GetComponent<A_Star>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            targetList = aStarScript.a_star_pos_list(playerGO.transform.position);
            if (targetList.Count > 0) {
                currTarget = targetList[0];
                targetList.RemoveAt(0);
            }
        }
        if (search) {
            transform.position = Vector2.MoveTowards(transform.position, currTarget, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, currTarget) < distance) {
                currTarget = targetList[0];
                targetList.RemoveAt(0);
            }
        }
    }
    
    // private bool check_if_close(Vector2){

    // }
}

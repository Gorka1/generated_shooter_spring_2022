using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is a basic A* implementation for path finding
class Node {
    public Vector2 nodePos;
    public Vector2 targetPos;
    private float raycast_dist = 2;
    private float x_dist = 1;
    private float y_dist = 1;
    public Node parent;
    public int level;
    public float priority;

    public Node(Vector2 newPos, Node newParent, Vector2 newTargetPos, int newLevel = 0) {
        nodePos = newPos;
        parent = newParent;
        level = newLevel;
        targetPos = newTargetPos;
        priority = newLevel + Vector2.Distance(targetPos, nodePos);
    }

    public List<Node> gen_neighbors() {
        Debug.Log("Node gen_neighbors called");
        List<Node> returnList = new List<Node>();
        for (int x = -1; x <= 1; x++) {
            for (int y = -1; y <= 1; y++) {
                if (y != 0 && x != 0) {
                    Debug.Log("Node gen_neighbors raycast shot");
                    RaycastHit2D hit = Physics2D.Raycast(nodePos, new Vector2(x,y), raycast_dist);
                    if (hit.collider == null) { // never null cause it always hits the obj collider
                        Debug.Log("Node gen_neighbors no collider found, adding new node");
                        returnList.Add(new Node(new Vector2(nodePos.x + x_dist, nodePos.y + y_dist), this, targetPos, level++));
                        Debug.Log(returnList.Count);
                    }
                }
            }
        }
        Debug.Log("Node gen_neighbors finished, returning data");
        Debug.Log(returnList.Count);
        Debug.Log(returnList);
        return returnList;
    }
}
public class A_Star : MonoBehaviour
{
    private Node aStarSearch(Vector2 startPos, Vector2 endPos, float distRange = 5) {
        Debug.Log("aStarSearch called");
        PriorityQueue mainQueue = new PriorityQueue();
        bool finished = false;
        // Plan:
        // Find the a* nodes closest to startPos (the first 5 found)
        // expand those nodes to a priority queue based on the following equation
            // node value = path cost so far (prev nodes) + dist of pos to endPos
            // NOTE: to keep track of path cost, you need to work with a struct that stores the path cost and the node gameobject
        // pop out the best value node, and expand that too
        // stop when you find a node close enough to the endPos
        Node currNode = new Node(startPos, null, endPos);
        // mainQueue.enqueue(currNode);

        // main loop for a* algo
        while (!finished && currNode != null) {
            Debug.Log("A* while loop run");
            if (Vector2.Distance(currNode.nodePos, endPos) < distRange) {
                // found the node
                Debug.Log("Found the final node");
                return currNode;
            } else {
                // generate the children
                // foreach (Node n in currNode.gen_neighbors()){
                //     Debug.Log("Enqueuing new nodes");
                //     mainQueue.enqueue(n);
                // }
                List<Node> currList = currNode.gen_neighbors();
                Debug.Log("currList");
                Debug.Log(currList.Count);
                Debug.Log(currList);
                for (int i = 0; i < currList.Count; i++) {
                    mainQueue.enqueue(currList[i]);
                }
            }
            currNode = mainQueue.dequeue();
        }
        return null;
    }

    public List<Vector2> a_star_pos_list(Vector2 targetPos) {
        Debug.Log("a_star_pos_list called");
        List<Vector2> retList = new List<Vector2>();
        Node currNode = aStarSearch(this.transform.position, targetPos);
        Debug.Log("a_star_pos_list a* search call finished");
        Debug.Log(currNode.level);
        if (currNode == null) { return retList; }
        // backtrace the nodes, and reverse that list
        while (currNode != null) {
            retList.Add(currNode.nodePos);
        }
        retList.Reverse();
        Debug.Log("a_star_pos_list finished, returning list");
        Debug.Log(retList.Count);
        return retList;
    }
}

class PriorityQueue{
    List<Node> mainList;
    public PriorityQueue() {
        mainList = new List<Node>();
    }

    public void enqueue(Node data) {
        Debug.Log("PriorityQueue enqueue called");
        Debug.Log(mainList.Count);
        if (mainList.Count == 0) { mainList.Add(data); return; }
        int push_pos = 0;
        bool running = true;
        int counter = 0;
        // loops through mainList until it finds a lesser element
        while (running) {
            if (mainList.Count <= counter) {
                running = false;
                push_pos = mainList.Count - 1;
            } else if (mainList[counter].priority > data.priority) {
                running = false;
                push_pos = counter;
            }
            counter++;
        }
        mainList.Insert(push_pos, data);
    }

    public Node dequeue() {
        if (mainList.Count != 0) {
            Node returnNode = mainList[0];
            mainList.RemoveAt(0);
            return returnNode;
        }
        return null;    // empty node to be returned
    }

    public bool exists(Node inputNode) {
        for (int i = 0; i < mainList.Count; i++) {
            if (mainList[i].nodePos == inputNode.nodePos) {
                return true;
            }
        }
        return false;
    }
}

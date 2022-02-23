using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is a basic A* implementation for path finding
struct Node {
    public GameObject go;
    // node parent;
    public Object parent;  // check to see if a struct can be held in an object (google says yes)
    public float priority;
    public bool valid = false;  // structs aren't nullable, use this instead
}
public class A_Star : MonoBehaviour
{
    public List<Vector2> aStarSearch(Vector2 startPos, Vector2 endPos, float distRange) {
        List<Vector2> returnList = new List<Vector2>();
        PriorityQueue mainQueue = new PriorityQueue();
        bool finished = false;
        // Plan:
        // Find the a* nodes closest to startPos (the first 5 found)
        // expand those nodes to a priority queue based on the following equation
            // node value = path cost so far (prev nodes) + dist of pos to endPos
            // NOTE: to keep track of path cost, you need to work with a struct that stores the path cost and the node gameobject
        // pop out the best value node, and expand that too
        // stop when you find a node close enough to the endPos
        GameObject closestGONode = findClosestNode();
        Node currNode = new Node();
        currNode.go = closestGONode;
        currNode.priority = Vector2.Distance(startPos, currNode.go.transform.position);
        currNode.parent = null;
        currNode.valid = true;
        mainQueue.enqueue(currNode);

        // main loop for a* algo
        while (!finished && currNode.valid) {
            if (Vector2.Distance(currNode.go.transform.position, endPos) < distRange) {
                // found the node
            } else {
                // generate the children
            }
        }

        return returnList;
    }

    public GameObject findClosestNode() {
        return null;
    }

}

class PriorityQueue{
    List<Node> mainList;
    public PriorityQueue() {
        mainList = new List<Node>();
    }

    public void enqueue(Node data) {
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
        return new Node();    // empty node to be returned
    }

    public bool exists(Node inputNode) {
        for (int i = 0; i < mainList.Count; i++) {
            if (mainList[i].go == inputNode.go) {
                return true;
            }
        }
        return false;
    }
}

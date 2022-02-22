using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is a basic A* implementation for path finding
public class A_Star : MonoBehaviour
{
    public List<Vector2> aStarSearch(Vector2 startPos, Vector2 endPos) {
        // Plan:
        // Find the a* nodes closest to startPos (the first 5 found)
        // expand those nodes to a priority queue based on the following equation
            // node value = path cost so far (prev nodes) + dist of pos to endPos
            // NOTE: to keep track of path cost, you need to work with a struct that stores the path cost and the node gameobject
        // pop out the best value node, and expand that too
        // stop when you find a node close enough to the endPos

    }
}

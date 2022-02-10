using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet_Scriptable", menuName = "Generate_Shooter_Spring_2022/Bullet_Scriptable", order = 0)]
public class Bullet_Scriptable : ScriptableObject {
    public int damage;      // amount of damage
    public float size;      // radius of bullet
    public int range;       // range/duration of bullets
    public Sprite bulletImage;
}

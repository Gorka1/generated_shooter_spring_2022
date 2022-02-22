using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet_Scriptable", menuName = "Generate_Shooter_Spring_2022/Bullet_Scriptable", order = 0)]
public class Bullet_Scriptable : ScriptableObject {
    public float damage;      // amount of damage
    public float size;      // radius of bullet
    public float range;       // range/duration of bullets
    public float speed;       // speed of the bullet
    public Sprite bulletImage;
    public Color bulletColor;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : Movement {
    public GameObject target;

    public float speed;

    // Update is called once per frame
    void Update() {
        linear = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.z - transform.position.z);

        linear.Normalize();
        linear *= speed;
    }
}

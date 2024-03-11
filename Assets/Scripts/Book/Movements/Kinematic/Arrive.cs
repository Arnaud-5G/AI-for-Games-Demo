using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : Movement {
    public GameObject target;

    public float speed;

    public float thresholdRadius;

    public float accelerationTime;
    // Update is called once per frame
    void Update() {
        linear = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.z - transform.position.z);

        if(linear.magnitude > thresholdRadius) {
            linear /= accelerationTime;

            if(linear.magnitude > speed) {
                linear.Normalize();
                linear *= speed;
            }
        } else {
            linear = new Vector2();
        }
    }
}

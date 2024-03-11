using UnityEngine;

public class Kinematic : MonoBehaviour {
    public float timeScale = 1;

    public Vector2 velocity;
    public float rotation;

    public Vector2 maxVelocity;
    public float maxRotation;

    public Movement movement;
    public bool forceOrientation;

    // Update is called once per frame
    void Update() {
        float half_t_sq = 0.5f * getTime() * getTime();
        Vector2 position = velocity * getTime() + movement.linear * half_t_sq;
        transform.position += new Vector3(position.x, 0, position.y);
        transform.eulerAngles += new Vector3(0, rotation * getTime() + movement.angular * half_t_sq, 0);

        velocity = movement.linear;
        rotation = movement.angular;

        // velocity += movement.linear * getTime();
        // rotation += movement.angular * getTime();

        // velocity.x = Mathf.Abs(velocity.x) < maxVelocity.x ? velocity.x : maxVelocity.x * Mathf.Sign(velocity.x);
        // velocity.y = Mathf.Abs(velocity.y) < maxVelocity.y ? velocity.y : maxVelocity.y * Mathf.Sign(velocity.y);
        // rotation = Mathf.Min(Mathf.Abs(rotation), maxRotation) * Mathf.Sign(rotation);

        if(forceOrientation) fixedOrientation();
    }

    void fixedOrientation() {
        if(velocity.magnitude > 0) {
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(velocity.y, -velocity.x) * Mathf.Rad2Deg - 90, 0);
        }
    }

    float getTime() {
        return Time.deltaTime * timeScale;
    }
}

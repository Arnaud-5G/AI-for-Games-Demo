using UnityEngine;

public class Kinematic : MonoBehaviour {
    public Vector2 position;
    public float orientation;

    public Vector2 velocity;
    public float rotation;

    // Update is called once per frame
    void Update() {
        float half_tag_sq = 0.5f * Time.deltaTime * Time.deltaTime;

    }
}

using UnityEngine;

public class GameManager : MonoBehaviour {
    public Kinematic[] characters;
    public Camera camera;
    public bool drags;
    public GameObject target;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start() {
        foreach(Kinematic character in characters) {
            character.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update() {
        if(!Input.GetMouseButton(0)) {
            drags = false;
            target = null;
        }

        if(drags) {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = camera.ScreenPointToRay(mousePos);
            if(Physics.Raycast(ray, out RaycastHit hit)) {
                target.transform.position = new Vector3(hit.point.x + offset.x, target.transform.position.y, hit.point.z + offset.z);
            }
        } else if(Input.GetMouseButton(0)) {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = camera.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out RaycastHit hit)) {
                target = hit.collider.gameObject;
                if(!target.TryGetComponent<Draggable>(out _)) {
                    target = null;
                } else {
                    offset = target.transform.position - hit.point;
                    drags = true;
                }
            }
        }
    }

    public void StartSim() {
        foreach(Kinematic character in characters) {
            character.timeScale = 1;
        }
    }
}

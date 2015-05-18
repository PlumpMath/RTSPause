using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Transform))]
public class MoveCamera : MonoBehaviour {
    public float speed;

	// Update is called once per frame
	void Update () {
        Move(GetMovement());
	}

    Vector3 GetMovement() {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        return move;
    }
    void Move(Vector3 dir) {
        transform.Translate(dir * Time.unscaledDeltaTime * speed, Space.World);
    }
}

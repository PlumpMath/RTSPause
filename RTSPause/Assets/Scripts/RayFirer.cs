using UnityEngine;
using System.Collections;

public class RayFirer : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        bool pressed = false;
        Click button = Click.None;

        if (Input.GetMouseButtonDown(0)) {
            pressed = true;
            button = Click.Left;
        } else if (Input.GetMouseButtonDown(1)) {
            pressed = true;
            button = Click.Right;
        }

        if (pressed) {
            FireRay(button);
        }
	}

    private void FireRay(Click button) {
        // Check for error
        if (button == Click.None) Debug.LogError("Fired ray without mouse press!");

        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(r, out hit, Mathf.Infinity)) {
            IClickable click = hit.collider.GetComponent(typeof(IClickable)) as IClickable;
            if (click != null) {
                click.Clicked(button, hit.point);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        float mousePos = (Input.mousePosition.x / Screen.width) * 16;
        Vector2 vectorPos = new Vector2(mousePos, transform.position.y);
        transform.position = vectorPos;
	}
}

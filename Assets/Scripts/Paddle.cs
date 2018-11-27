using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthUnits;
    [SerializeField] float minimumX = 1.75f;
    [SerializeField] float maximumX = 14.25f;
	// Update is called once per frame
	void Update () {
        float mousePos = (Input.mousePosition.x / Screen.width) * screenWidthUnits;
        Vector2 vectorPos = new Vector2(transform.position.x, transform.position.y);
        vectorPos.x = Mathf.Clamp(mousePos,minimumX,maximumX); 
        transform.position = vectorPos;
	}
}

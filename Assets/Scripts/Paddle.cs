using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] public float screenWidthUnits;
    [SerializeField] public float minimumX = 1.75f;
    [SerializeField] public float maximumX = 14.25f;

	// Update is called once per frame
	void Update () {
        float mousePos = (Input.mousePosition.x / Screen.width) * screenWidthUnits;
        Vector2 vectorPos = new Vector2(transform.position.x, transform.position.y);
        vectorPos.x = Mathf.Clamp(mousePos,minimumX,maximumX); 
        transform.position = vectorPos;
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
}

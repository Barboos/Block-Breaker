using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //Configuration paramaters
    [SerializeField] float minX, maxX;

    [SerializeField] float screenWidthInUnits;
    private float mousePosition;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mousePosition = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mousePosition, minX, maxX);
        transform.position = paddlePosition;
    }
}

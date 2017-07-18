using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject player;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary) //when someone touches the sceen and holds (TouchPhase.Stationary) something happens
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).position; //the vector2 postion (transform) of the user touch 
            double halfScreen = Screen.width / 2.0;

            //code to check if the touch is on the left or the right side to move the player that way 
            if (touchDeltaPosition.x < halfScreen)
            {
                player.transform.Translate(Vector3.left * 5 * Time.deltaTime);
            }
            else if(touchDeltaPosition.x > halfScreen)
            {
                player.transform.Translate(Vector3.right * 5 * Time.deltaTime);
            }
        }
    }
}

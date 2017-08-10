using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public GameObject player;
    public Transform playerTransform;
    public float jumpForce = 500f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Button jumpButton;

    Animator anim;
    Rigidbody2D rigidBody;
    bool grounded = false;
    float groundRadius = 0.2f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); //reference to the players rigidbody2D
        anim = GetComponent<Animator>(); //reference to the attatched animator
        jumpButton = GetComponent<Button>(); //reference to the jump button
    }

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
            else if (touchDeltaPosition.x > halfScreen)
            {
                player.transform.Translate(Vector3.right * 5 * Time.deltaTime);
            }
        }
    }

    void FixedUpdate()
    {
        //shoot out a little circle checking to see if ground is present (overlapcircle), which comes from the ground check 'GO' transform and checks the Layermask for what is ground which 
        //in the inpector will be everything but the players layer itself
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); 
        anim.SetBool("Ground", grounded); //a bool in the animator window so we can see if grounded or not in the inspector 

        //anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);  keep watchin video to see what this is 
    }

    public void Jump() //the function the button will call 
    {
        if (grounded) 
        {
            anim.SetBool("Ground", false); //set the bool in the animator to false if not on the ground
            rigidBody.AddForce(new Vector2(0, jumpForce)); //a force to make the character jump only if grounded is true
        }
    }
}

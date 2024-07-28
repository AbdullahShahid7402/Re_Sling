using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlingController : MonoBehaviour
{
    // variables for default position and scale of the sling shot controller so it can be set to the default size and position
    private Vector2 DefaultPosition, DefaultScale;
    // stores the radius of the controller and also acts as a hitbox limit for initial contact with the controller
    private float radius;
    // stores whether a touch input that was detected to have controller interaction
    private bool TouchSpotted;
    // Start is called before the first frame update
    void Start()
    {
        TouchSpotted = false;
        // set the value of radius that is basically also going to help as hitbox of the controller
        radius = 0.5f;
        // set default position of the controller for the sling shot
        DefaultPosition.x = 0f;
        DefaultPosition.y = -3f;
        this.transform.position = DefaultPosition;
        // the default scale of the controller for the controller 
        DefaultScale.x = radius;
        DefaultScale.y = radius;
        this.transform.localScale = DefaultScale;
    }

    // Update is called once per frame
    void Update()
    {
        controller_activation();
        controller_movement();
        controller_reset();
    }

    // detect if any of the touch inputs uses controller and if it does it activates a private variable
    // to show for next frame of the game that an input was detected and can be used to move the controller
    public void controller_activation()
    {
        // see if there is no input and in that case return
        if (Input.touchCount == 0)
            return;
        // iterate through each touch input and see if any one is in range of the controller then assign movement to the controller
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touchInput = Input.GetTouch(i);
            // get its position
            Vector2 touchPosition = touchInput.position;
            // convert to world points so that it can be compared to sprite position later
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, Camera.main.nearClipPlane));
            // see if it is in the radius of the controller and if it isnt ...
            // just move to next iteration to check if any othe input works fine
            if (Vector2.Distance(worldPosition,this.transform.position) > radius)
                continue;
            // but if it is... assign its index to the Touch spotted variable for future use
            TouchSpotted = true;
            return;
        }
    }

    // check if the input was detected and if it was .... move the controller accordingly
    public void controller_movement()
    {
        // see if the button was not selected ... and don't do anything if that is the case
        if (!TouchSpotted)
            return;
        // reset the touch in case the function returns at any stage due to out of bounds or no touch issue
        TouchSpotted = false;
        // see if there is still a touch input cause if there isnt this function cannot go ahead
        if (Input.touchCount == 0)
            return;
        int MinIndex = -1;
        float MaxDistance = radius * 4;
        float ControllerRange = radius * 2;
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touchInput = Input.GetTouch(i);
            // get its position
            Vector2 touchPosition = touchInput.position;
            // convert to world points so that it can be compared to sprite position later
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, Camera.main.nearClipPlane));
            // calculate distance
            float distance = Vector2.Distance(worldPosition,this.transform.position);
            // see which touch input is closest to the controller and within a certain radius
            if(MaxDistance >= distance)
            {
                MaxDistance = distance;
                MinIndex = i;
            }
        }
        // in case the touch was too far or not detected at all
        if (MinIndex == -1)
            return;
        Touch touchInputFinal = Input.GetTouch(MinIndex);
        // get its position
        Vector2 touchPositionFinal = touchInputFinal.position;
        // convert to world points so that it can be compared to sprite position later
        Vector2 worldPositionFinal = Camera.main.ScreenToWorldPoint(new Vector3(touchPositionFinal.x, touchPositionFinal.y, Camera.main.nearClipPlane));
        // set the worldPosition point to a limit so that it cant go beyond a certain point on screen
        if (Vector2.Distance(worldPositionFinal,DefaultPosition) > ControllerRange)
        {
            // subtract default positiion to get this vector back to origin
            worldPositionFinal -= DefaultPosition;
            // normalize the vector so that it can be ladter scaled according to the desired range
            worldPositionFinal.Normalize();
            // scaling to desired range
            worldPositionFinal *= ControllerRange;
            // adding the default position to get the resultant vector off origin to where it should be on screen
            worldPositionFinal += DefaultPosition;
        }
        // assign the position to the controller
        this.transform.position = worldPositionFinal;
        TouchSpotted = true;
    }

    // in case the input is released return the controller to its initial positions
    public void controller_reset()
    {
        // in case the player re initiates the contact with controller... do not go to initial position
        if (TouchSpotted)
            return;
        // get the distance
        float distance = Vector2.Distance(this.transform.position,DefaultPosition);
        // in case the distance is too less just get to the initial position
        if (distance < 0.01)
        {
            this.transform.position = DefaultPosition;
            return;
        }
        // make a ector that makes a calculation of haf distance location 
        // between current position and the default position
        // this makes the animation look smooth and fluid 
        Vector2 move;
        move.x = (DefaultPosition.x - this.transform.position.x)/2;
        move.y = (DefaultPosition.y - this.transform.position.y)/2;
        move.x += this.transform.position.x;
        move.y += this.transform.position.y;
        // set that as current position of the controller
        this.transform.position = move;
        return;
    }
}

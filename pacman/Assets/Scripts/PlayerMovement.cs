using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    //variables for game
    public float speed = 10f; // control movenemt speed

    Vector2 lastMousePos;  // store position of mouse

    bool moving; // keep track of movement

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //if left mouse button is clicked
        {
            lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // change value of lastMouse
            moving = true; // change moving to true = object is moving
        }

        if (moving && (Vector2)transform.position != lastMousePos) // if object is moving and is not at the last position of mouse
        {
            float step = speed * Time.deltaTime; // create variable for the movement
            transform.position = Vector2.MoveTowards(transform.position, lastMousePos, step); // move the object
        }
        else
        {
            moving = false;
        }
    }

    //function for collision
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall") // if player hits a car, or water
        {
            //Debug.Log("Hit"); for debugging
            SceneManager.LoadScene("Start Scene"); // restart game
        }
    }
}

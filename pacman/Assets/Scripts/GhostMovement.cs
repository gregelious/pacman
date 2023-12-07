using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{

    public float xSpeed = 0; //horizontal speed
    private bool goUp = true; // true = up, false = down
    private bool goDown = false; // true = right, false = left
    private bool goLeft = false;
    private bool goRight = false;

    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 0.0125f; // normal speed
    }

    // Update is called once per frame
    void Update()
    {
        if (goUp == true) // if going up
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + xSpeed); // goes right
        }
        else if (goDown == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - xSpeed); // goes r
        }
        else if (goLeft == true)
        {
            transform.position = new Vector2(transform.position.x - xSpeed, transform.position.y); // goes r
        }
        else if (goRight == true)
        {
            transform.position = new Vector2(transform.position.x + xSpeed, transform.position.y); // goes r
        }
    }

    //function for collision
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall") // if player hits a car, or water
        {
            if (goUp == true || goDown == true)
            {
                if (Random.Range(0, 100) < 50)
                {
                    goLeft = true;
                }
                else
                {
                    goRight = true;
                }
                goUp = false;
                goDown = false;
            }
            else
            {
                if (Random.Range(0, 100) < 50)
                {
                    goUp = true;
                }
                else
                {
                    goDown = true;
                }
                goLeft = false;
                goRight = false;
            }
        }
    }
}

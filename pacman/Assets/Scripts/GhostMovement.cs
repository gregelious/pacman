using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostMovement : MonoBehaviour
{
    Health damage;// damage is an object using Health class

    public GameObject hitPoints; //hisPoints is an object

    public float xSpeed = 0; //horizontal speed
    private bool goUp = true; // true = up, false = down
    private bool goDown = false; // true = right, false = left
    private bool goLeft = false;
    private bool goRight = false;

    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 0.005f; // normal speed
        damage = hitPoints.GetComponent<Health>(); //initializes Enemies
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
        //Random.Range(0, 100) < 50
        if (other.tag == "Player")
        {
            damage.TakeDamage(1); // takes one damage
            SceneManager.LoadScene("SampleScene");
        }
        else if (other.tag == "Reverse")
        {
            if (goUp == true)
            {
                goDown = true;

                goUp = false;

                goLeft = false;
                goRight = false;
            }
            else if (goDown == true)
            {
                goUp = true;


                goDown = false;
                goLeft = false;
                goRight = false;
            }
            else if (goLeft == true)
            {
                goLeft = false;

                goUp = false;
                goDown = false;

                goRight = true;
            }
            else if (goRight == true)
            {
                goLeft = true;

                goUp = false;
                goDown = false;

                goRight = false;
            }
        }
        else if (other.tag == "LeftRight" && (goUp == true || goDown == true))
        {
            if (Random.Range(0, 100) < 50)
            {
                goLeft = true;

                goUp = false;
                goDown = false;

                goRight = false;
            }
            else
            {
                goLeft = false;

                goUp = false;
                goDown = false;

                goRight = true;
            }
        }
        else if (other.tag == "UpDown" && (goLeft == true || goRight == true))
        {
            if (Random.Range(0, 100) < 50)
            {
                goUp = true;


                goDown = false;
                goLeft = false;
                goRight = false;
            }
            else
            {
                goDown = true;

                goUp = false;

                goLeft = false;
                goRight = false;
            }
        }
        else if (other.tag == "UpLeft" && goUp == true)
        {
            goLeft = true;

            goUp = false;
            goDown = false;

            goRight = false;
        }
        else if (other.tag == "UpRight" && goUp == true)
        {
            goLeft = false;

            goUp = false;
            goDown = false;

            goRight = true;
        }
        
        else if (other.tag == "DownLeft" && goDown == true)
        {
            goLeft = true;

            goUp = false;
            goDown = false;

            goRight = false;
        }
        else if (other.tag == "DownRight" && goDown == true)
        {
            goLeft = false;

            goUp = false;
            goDown = false;

            goRight = true;
        }
        
        else if (other.tag == "LeftUp" && goLeft == true)
        {
            goUp = true;


            goDown = false;
            goLeft = false;
            goRight = false;
        }
        else if (other.tag == "LeftDown" && goLeft == true)
        {
            goDown = true;

            goUp = false;

            goLeft = false;
            goRight = false;
        }
        
        else if (other.tag == "RightUp" && goRight == true)
        {
            goUp = true;


            goDown = false;
            goLeft = false;
            goRight = false;
        }
        else if (other.tag == "RightDown" && goRight == true)
        {
            goDown = true;

            goUp = false;

            goLeft = false;
            goRight = false;
        }
    }
}

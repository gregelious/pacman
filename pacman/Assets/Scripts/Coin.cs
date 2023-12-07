using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function for collision
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") // if the player touches it
        {
            Debug.Log("touched");
            //transform.position = new Vector2(transform.position.x + 100, transform.position.y + 100); // it goes far away, looks like it's gone
            Destroy(gameObject); // self destructs
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    //variables 
    private Vector2 direction; //controls direction of movement / up (0,1) / down (0,-1) / left (-1,0) / right (1,0) / zero (0,0)  

    List<Transform> segments;    //variable to store all the parts of the body of the snake 
    public Transform bodyPrefab; //variable to store the body 

    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform> (); //creates a new list 
        segments.Add(transform);           //add the head of the snake to the list 
    }

    // Update is called once per frame
    void Update()
    {
        //change direction of the snake 
        if (Input.GetKeyDown(KeyCode.W)) //When W key is pressed... 
        {
            direction = Vector2.up; //go up 
        }
        else if (Input.GetKeyDown(KeyCode.A)) //When A key is pressed... 
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.S)) //When S key is pressed...
        {
            direction = Vector2.down; //go down 
        }
        else if (Input.GetKeyDown(KeyCode.D)) //When D key is pressed... 
        {
            direction = Vector2.right; //go right 
        }
    }

    //FixedUpdate is called at a fixed interval. 
    void FixedUpdate()
    {

        //move to body of the snake 
        for (int i = segments.Count -1; i > 0; i--) //for each segments of the snake 
        {
            segments[i].position = segments[i - 1].position; //move the body 
        }

            //don't need to put a transform because there is already transform code in variable "segments" 
            
            //if statement gives clear statement on what to do next 
            //for statement 
            // while statement: while this is true..do this (easiest way to make an infinite loop) 


        this.transform.position = new Vector2( //get the position 
            Mathf.Round(this.transform.position.x) + direction.x, //round the number add value to X 
            Mathf.Round(this.transform.position.y) + direction.y  //round the number add value to Y 
            ); 
    } 

    void Grow() //This wont do anything on its own cause it must be called. 
        //This code only adds a new body part 
        //To have this move with the snake, we must make the for statement that is above 
    { 
        Transform segment = Instantiate(this.bodyPrefab);           //creates a new body part 
        segment.position = segments[segments.Count - 1].position;   //position it on the back of the snake 
        segments.Add(segment);                                      //add it to the list 
    }

    //Function for collision 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow(); 
        }
    }
}

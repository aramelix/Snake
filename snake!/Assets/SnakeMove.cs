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
    private void FixedUpdate()
    {
        this.transform.position = new Vector2( //get the position 
            Mathf.Round(this.transform.position.x) + direction.x, //round the number add value to X 
            Mathf.Round(this.transform.position.y) + direction.y  //round the number add value to Y 
            ); 
    } 

    void Grow() //This wont do anything on its own cause it must be called. 
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

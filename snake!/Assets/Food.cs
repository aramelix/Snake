using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //variables 
    public BoxCollider2D grid; 

    // Start is called before the first frame update
    void Start()
    {
        RandomPos(); //randomize position of the food 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RandomPos()
    {
        Bounds bounds = grid.bounds;                            //declare the limits of the space 

        //randomizing where the food goes within the grid 
        //Random.Range(lowest value,highest value) 
        //In this case it is lowest and highest value of x and lowest and highest value of y 

        float x = Random.Range(bounds.min.x, bounds.max.x);     //give a random value to x within the limit 
        float y = Random.Range(bounds.min.y, bounds.max.y);     //give a random value to y within the limit 

        transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y)); //round values of x&y anc change position of the food 
        //^ This transform tells the food to spawn in a location where the snake and the food line up every time 

    }

    //Code for collision 
    void OnTriggerEnter2D (Collider2D other) 
    {
       if(other.tag == "Player")
        {
            RandomPos(); 
        }
    }
}

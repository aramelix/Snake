using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    //variables 
    private Vector2 direction; //controls direction of movement / up (0,1) / down (0,-1) / left (-1,0) / right (1,0) / zero (0,0)  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //change direction of the snake 
        if (Input .GetKeyDown(KeyCode.W)) //When W key is pressed... 
        {
            direction = Vector2.up; //go up 
        }
    }
}

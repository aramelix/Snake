using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

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
}

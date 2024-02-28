using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.SocialPlatforms.Impl;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.left; 
    private List<Transform> segments;
    public Transform snakePrefabs;
    public ScoreManager scoreManager;  
    private bool isOver = false; 

    private void Start() 
    {   
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>(); 
        segments = new List<Transform>();
        segments.Add(this.transform);  
    }

    private void Update() 
    { 
        if(direction.x != 0.0f) { 
            if(Input.GetKeyDown(KeyCode.W)) 
                direction = Vector2.up;
            else if(Input.GetKeyDown(KeyCode.S))
                direction = Vector2.down; 
        }
        
        if(direction.y != 0.0f) { 
            if(Input.GetKeyDown(KeyCode.A))
                direction = Vector2.left; 
            else if(Input.GetKeyDown(KeyCode.D))
                direction = Vector2.right; 
        }
    }

    private void FixedUpdate() 
    {   
        if(!isOver){
            for (int i = segments.Count-1; i > 0; i--) 
                segments[i].position = segments[i-1].position; 

            int x = Mathf.RoundToInt(transform.position.x) + (int) direction.x; 
            int y = Mathf.RoundToInt(transform.position.y) + (int) direction.y; 

            transform.position = new Vector3(
                x,
                y, 
                0.0f
            ); 
        }
    }

    private void grow() 
    { 
        Transform transform = Instantiate(snakePrefabs); 
        transform.position = new Vector3(
            this.transform.position.x,
            this.transform.position.y, 
            0.0f
        ); 
        segments.Add(transform); 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {   
        if(collider.tag == "Food") { 
            grow(); 
            scoreManager.addScore(); 
        }

         if(collider.tag == "Obstacle") { 
            scoreManager.gameOver(); 
            isOver = true; 
        }

    }
}

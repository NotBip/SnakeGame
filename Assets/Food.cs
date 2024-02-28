using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea; 
    
    private void Start() 
    { 
        randomize(); 
    }

    private void randomize() 
    { 
        Bounds bounds = gridArea.bounds; 

        int x = (int) Random.Range(bounds.min.x, bounds.max.x); 
        int y = (int) Random.Range(bounds.min.y, bounds.max.y); 

        this.transform.position = new Vector3(
            x,
            y,
            0.0f
        ); 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {   
        if(collider.tag == "Player")
            randomize(); 
    }


}

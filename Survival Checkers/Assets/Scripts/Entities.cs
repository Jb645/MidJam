using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Entity", menuName ="Entity")]
public class Entities : ScriptableObject
{
    public new string name;
    
    public int health;
    
    public Sprite artwork;

    public Collision2D collider;

    public void Print()
    {
        Debug.Log("Health: " + health
            +"\nArtwork: "+artwork);
        
    }

    public void AffectHealth(int changeHealthBy)
    {
        if(health > 0 )
        {
            health += changeHealthBy;
            Debug.Log(health);
            
        }
        else
        {
            Debug.Log("dead");
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Entities player;
    public Image Artwork;
    public Text health;


    // Start is called before the first frame update
    void Start()
    {

        Artwork.sprite = player.artwork;
        health.text = player.health.ToString();
       
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}

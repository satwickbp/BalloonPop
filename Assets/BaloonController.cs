using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class BaloonController : MonoBehaviour
{
    public Rigidbody2D Rb;
    public float Speed = 3f;

    public float upwardSpeed = 3f; // Speed of vertical (upward) movement
    public float zigzagAmplitude = 1f; // How far to move left and right
    public float zigzagFrequency = 1f; // How often to switch horizontal direction

    //private Rigidbody2D rb; // Rigidbody2D component reference
    private bool movingRight = true; // Control for zigzag direction
    private float nextSwitchTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,6);
          
    }

    // Update is called once per frame  
    void Update()
    {
        //move stright 
        //Rb.velocity = new Vector2(0, Speed);

        //zigzag movement
        // Apply upward force for vertical movement
        Rb.velocity = new Vector2(Rb.velocity.x, upwardSpeed);

        // Switch horizontal direction at intervals
        if (Time.time >= nextSwitchTime)
        {
            movingRight = !movingRight;
            nextSwitchTime = Time.time + zigzagFrequency;
        }

        // Apply horizontal force for zig-zag movement
        float horizontalMovement = movingRight ? zigzagAmplitude : -zigzagAmplitude;
        Rb.velocity = new Vector2(horizontalMovement, Rb.velocity.y);

    }
    
}

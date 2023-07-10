using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicManagerScript logic;
    public bool birdIsAlive = true;
    public AudioSource birdFlap;
    // Start is called before the first frame updatelo
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && birdIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
            birdFlap.Play();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (birdIsAlive)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }
}

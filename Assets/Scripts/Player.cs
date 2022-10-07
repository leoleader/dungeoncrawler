using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    
    private RaycastHit2D hit;

    // means in between rendering frame and next one what is the difference 
    // in position
    private Vector3 moveDelta;

    // where one would put functions to run at start of the game
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset moveDelta
        moveDelta = new Vector3(x,y,0);

        //swap sprite direction whther left or right
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1,1,1);

        // make sure we can move in this direction by casting a box there first
        // if box returns null we are free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0,moveDelta.y), 
        Mathf.Abs(moveDelta.y*Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null) {
        // make this thing move
        // delta time makes equal no matter how fast device is
        transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        // same as above but for x
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), 
        Mathf.Abs(moveDelta.x*Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null) {
        // make this thing move
        // delta time makes equal no matter how fast device is
        transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
        

    }

}

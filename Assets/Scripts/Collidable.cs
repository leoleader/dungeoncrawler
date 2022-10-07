using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collidable : MonoBehaviour
{
    // filter to know what should be collided with
    public ContactFilter2D filter;
    // the collider on a specific object
    private BoxCollider2D boxCollider;
    // what was hit during this frame
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update() 
    {
        // Collision work
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if(hits[i] == null)
                continue;

            OnCollide(hits[i]);
            //cleaning up hits array
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D coll) 
    {
        Debug.Log(coll.name);
    }
}

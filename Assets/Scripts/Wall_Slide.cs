using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Slide : MonoBehaviour
{
    /*
    private bool iswallSliding;
    [SerializeField]
    private float slideSpeed;
    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private LayerMask wallLayer;
    [SerializeField]
    private Rigidbody2D rb;
    
    // Update is called once per frame
    void Update()
    {
        wallSlide();
    }

    private bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void wallSlide()
    {
        if (isWalled())
        {
            iswallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -slideSpeed, float.MaxValue));
        }
        else
        {
            iswallSliding = false;
        }
    }*/

    public Rigidbody2D rb;
    public float walljump = 0.2f;
    public float wallslideSpeed = 0.3f;
    public float wallDistance = 0.5f;
    bool iswallSliding = false;
    RaycastHit2D wallcheckHit;
    public LayerMask ground;
    float jumptime;

    private void FixedUpdate()
    {
        wallcheckHit = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0), wallDistance, ground);

        if (wallcheckHit)
        {
            iswallSliding = true;
        }
        else if (jumptime < Time.time)
        {
            iswallSliding = false;
        }
        
        if (iswallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, wallslideSpeed, float.MaxValue));
        }
    }
}

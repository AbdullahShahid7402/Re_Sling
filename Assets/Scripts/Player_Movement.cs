using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float positionRadius;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Transform pos;
    [SerializeField]
    private LayerMask ground;
    private Vector2 jumpHeight; 
    private bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int j = i; j < colliders.Length; j++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[j]);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                anim.Play("Walk");
                rb.AddForce(Vector2.right *  speed * Time.deltaTime);
            }
            else
            {
                anim.Play("Backwards");
                rb.AddForce(Vector2.left * speed * Time.deltaTime);
            }
        }
        else
        {
            anim.Play("Idle");
        }

        onGround = Physics2D.OverlapCircle(pos.position, positionRadius, ground);
        if (onGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime);
        }
    }
}

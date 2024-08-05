using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachableWall : MonoBehaviour
{
    private bool Attached;
    private Vector2 Player_Coordinates;
    private float Wall_Coordinates_x;
    private bool move;
    // Start is called before the first frame update
    void Start()
    {
        Attached = false;
        Player_Coordinates = new Vector2(0f,0f);
        Wall_Coordinates_x = this.transform.position.x;
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Sling_Movement.JumpBuffer>0)
        {
            Attached = false;
            Sling_Movement.GoTo = new Vector2(0f,0f);
        }
        // Debug.Log(GameStart.Player.transform.position.x.ToString());
        if (Attached)
        {
            // Debug.Log("Attached");
            Sling_Movement.GoTo = Player_Coordinates;
        }
        float collisionMargin = 2f + 0.3f;
        if (!Attached && Math.Abs(GameStart.Player.transform.position.x-this.transform.position.x)<collisionMargin)
        {
            if(GameStart.Player.transform.position.y < this.transform.position.y+1f && GameStart.Player.transform.position.y > this.transform.position.y-1f)
            {
                // Debug.Log("Attaching");
                Attached = true;
                Player_Coordinates = GameStart.Player.transform.position;
                // Debug.Log(Player_Coordinates.ToString());
            }
        }
        // else if(Attached && Math.Abs(GameStart.Player.transform.position.x-this.transform.position.x)>=collisionMargin)
        // {
        //     Attached = false;
        //     Sling_Movement.GoTo = new Vector2(0f,0f);
        // }
        if(move)
        {
            this.transform.position = new Vector2(Wall_Coordinates_x,this.transform.position.y - 4f * Time.deltaTime);
        }
        this.transform.rotation = Quaternion.Euler(1f,1f,0f);
        this.transform.position = new Vector2(Wall_Coordinates_x,this.transform.position.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            move = false;
            // Debug.Log("Collision detected with Ground or Wall. Stopping movement.");
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            move = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            move = true;
        }
    }

}

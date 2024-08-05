using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalWall : MonoBehaviour
{
    private float Wall_Coordinates_x;
    private bool move;
    // Start is called before the first frame update
    void Start()
    {
        Wall_Coordinates_x = this.transform.position.x;
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
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

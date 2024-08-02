using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachableWall : MonoBehaviour
{
    private bool Attached;
    private Vector2 Player_Coordinates;
    // Start is called before the first frame update
    void Start()
    {
        Attached = false;
        Player_Coordinates = new Vector2(0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(GameStart.Player.transform.position.x.ToString());
        if (Attached)
        {
            Sling_Movement.GoTo = Player_Coordinates;
        }
        float collisionMargin = 2f + 1f;
        if (!Attached && Math.Abs(GameStart.Player.transform.position.x-this.transform.position.x)<collisionMargin)
        {
            Debug.Log("Attaching");
            Attached = true;
            Player_Coordinates = GameStart.Player.transform.position;
        }
        else if(Math.Abs(GameStart.Player.transform.position.x-this.transform.position.x)>=collisionMargin)
        {
            Attached = false;
            Sling_Movement.GoTo = new Vector2(0f,0f);
        }
    }
}

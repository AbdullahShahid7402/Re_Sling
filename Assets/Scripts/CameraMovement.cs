using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameStart.Player.transform.position.y > 0f)
        {
            Vector3 position = this.transform.position;
            position.y = GameStart.Player.transform.position.y;
            this.transform.position = position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoordinateManager : MonoBehaviour
{
    public GameObject chest;
    public GameObject playerpos;
    public GameObject head;
    public GameObject leftleg;
    public GameObject rightleg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameStart.Player!=this.gameObject)
        {
            GameStart.Player = this.gameObject;
        }
        // chest.transform.position = new Vector2(this.transform.position.x-0.014f,this.transform.position.y+0.41f);
        // head.transform.position = new Vector2(this.transform.position.x+0.006f,this.transform.position.y+1.26f);
        // leftleg.transform.position = new Vector2(this.transform.position.x-0.176f,this.transform.position.y-0.402f);
        // rightleg.transform.position = new Vector2(this.transform.position.x+0.184f,this.transform.position.y+-.402f);
        // playerpos.transform.position = this.transform.position;
    }
}

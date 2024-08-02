using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject AttachableWallPrefab;
    public GameObject ControllerPrefab;
    public static GameObject Player;
    // private GameObject Controller;
    private GameObject Wall1;
    private GameObject Wall2;
    // Start is called before the first frame update
    void Start()
    {
        Player = Instantiate(PlayerPrefab);
        Instantiate(ControllerPrefab);
        Wall1 = Instantiate(AttachableWallPrefab);
        Wall2 = Instantiate(AttachableWallPrefab);

        Player.transform.position = new Vector2(0f,1f);
        Wall1.transform.position = new Vector2(4.5f,10f);
        Wall1.transform.localScale = new Vector2(1f,7.5f);
        Wall2.transform.position = new Vector2(-4.5f,10f);
        Wall2.transform.localScale = new Vector2(1f,7.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

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
    private GameObject[] Walls;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        Player = Instantiate(PlayerPrefab);
        Instantiate(ControllerPrefab);
        Walls = new GameObject[2];
        for (int i = 0; i < Walls.Length; i++)
        {
            Walls[i] = Instantiate(AttachableWallPrefab);
        }

        Player.transform.position = new Vector2(0f,1f);
        Walls[0].transform.position = new Vector2(4.5f,10f);
        Walls[0].transform.localScale = new Vector2(1f,7.5f);
        Walls[1].transform.position = new Vector2(-4.5f,10f);
        Walls[1].transform.localScale = new Vector2(1f,7.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject[] AttachableWallPrefab;
    public GameObject ControllerPrefab;
    public static GameObject Player;
    public static int framerate;
    private GameObject Controller;
    private GameObject[] Walls;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        Player = Instantiate(PlayerPrefab);
        Controller = Instantiate(ControllerPrefab);
        Controller.transform.SetParent(CameraMovement.Camera.transform);
        Walls = new GameObject[40];
        for (int i =0; i < 40; i++)
        {
            Walls[i] = null;
        }
        StartCoroutine(WallsMaker());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator WallsMaker()
    {
        int side = Random.Range(0,2);
        float spawnheight = 0f;
        int spawnerIndex = 0; 
        while(true)
        {
            if(Walls[spawnerIndex % Walls.Length] != null)
            {
                Debug.Log("Stopping Coroutine");
                yield break;
            }
            Walls[spawnerIndex % Walls.Length] = Instantiate(AttachableWallPrefab[0]);
            if(side == 0)
            {
                Walls[spawnerIndex % Walls.Length].transform.position = new Vector2(-4.5f,0f + spawnheight);
            }
            else
            {
                Walls[spawnerIndex % Walls.Length].transform.position = new Vector2(4.5f,0f + spawnheight);
            }
            spawnerIndex++;
            spawnheight+=1f;
            side++;
            side%=2;
            yield return new WaitForSeconds(Random.Range(0f,0.5f));
        }
    } 
}

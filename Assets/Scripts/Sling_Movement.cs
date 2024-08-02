using System;
using Unity.Mathematics;
using UnityEngine;

public class Sling_Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float power;
    [SerializeField]
    private Vector2 minPower;
    [SerializeField]
    private Vector2 maxPower;
    private Camera cam;
    private Vector2 force;
    private Vector3 startPos;
    private Vector3 endPos;

    public static Vector2 GoTo;
    public static int JumpBuffer;

    private void Start()
    {
        JumpBuffer = 0;
        cam = Camera.main;
        GoTo = new Vector2(0f,0f);
    }

    private void Update()
    {
        Vector2 ControllerOutput = SlingController.Get_Displacement();
        ControllerOutput *= -1;
        if(Math.Abs(ControllerOutput.x) > 0.001f && Math.Abs(ControllerOutput.y) > 0.001f)
        {
            // Debug.Log(ControllerOutput.x.ToString()+","+ControllerOutput.y.ToString());
            force = new Vector2(Mathf.Clamp(ControllerOutput.x, minPower.x, maxPower.x), Mathf.Clamp(ControllerOutput.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            JumpBuffer = Application.targetFrameRate / 10;
        }
        if (Vector2.Distance(new Vector2(0f,0f),GoTo) > 0.01f)
        {
            float scaleDownFactor = 10;
            float factorx = 3f;
            if (GoTo.x<0)
                factorx *= -1;
            force = new Vector2(Mathf.Clamp(factorx, minPower.x, maxPower.x), Mathf.Clamp(0.1f, minPower.y, maxPower.y));
            rb.AddForce(force * power / scaleDownFactor, ForceMode2D.Impulse);
            // Debug.Log((-GoTo.x+GameStart.Player.transform.position.x).ToString());
        }
        if(JumpBuffer>0)
            JumpBuffer--;
    }
}

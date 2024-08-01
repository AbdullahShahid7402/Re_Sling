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

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector2 ControllerOutput = SlingController.Get_Displacement();
        ControllerOutput *= -1;
        if(Math.Abs(ControllerOutput.x) > 0.001f && Math.Abs(ControllerOutput.y) > 0.001f)
        {
            Debug.Log(ControllerOutput.x.ToString()+","+ControllerOutput.y.ToString());
            force = new Vector2(Mathf.Clamp(ControllerOutput.x, minPower.x, maxPower.x), Mathf.Clamp(ControllerOutput.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

}

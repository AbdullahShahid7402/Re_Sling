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
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Up");
            startPos = cam.ScreenToWorldPoint(Input.mousePosition);
            startPos.z = 15;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Down");
            endPos = cam.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 15;

            force = new Vector2(Mathf.Clamp(startPos.x - endPos.x, minPower.x, maxPower.x), Mathf.Clamp(startPos.y - endPos.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
        }

    }

}

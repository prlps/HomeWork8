using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class FreeCamera : MonoBehaviour
{
    public float speed = 1.5f;
    public float acceleration = 10f;
    public float sensitivity = 5f; // чувствительность мыши
    public Camera mainCamera;


    private Rigidbody body;
    private float rotY;
    private Vector3 direction;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
        body.useGravity = false;
        body.mass = 0.1f;
        body.linearDamping = 10f;

        if (mainCamera == null)
            mainCamera = Camera.main;
    }


    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (mainCamera == null) return; // защита

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float rotX = mainCamera.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        rotY += Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, -90, 90);

        if (Input.GetKey(KeyCode.Mouse1))
        {
            mainCamera.transform.localEulerAngles = new Vector3(-rotY, rotX, 0);
        }

        direction = new Vector3(h, 0, v);
        direction = mainCamera.transform.TransformDirection(direction);
    }

    void FixedUpdate()
    {
        body.AddForce(direction.normalized * speed * acceleration);

        Vector3 vel = body.linearVelocity;
        if (Mathf.Abs(vel.x) > speed) vel.x = Mathf.Sign(vel.x) * speed;
        if (Mathf.Abs(vel.z) > speed) vel.z = Mathf.Sign(vel.z) * speed;
        if (Mathf.Abs(vel.y) > speed) vel.y = Mathf.Sign(vel.y) * speed;
        body.linearVelocity = vel;
    }
}

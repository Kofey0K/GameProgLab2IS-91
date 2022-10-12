using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 1f;
    public float sensitivity = 1f;
    public Transform cameraTransform;
    public Rigidbody rb;
    public Transform groundcheck;
    public LayerMask groundLayer;
    private bool _isOnFloor = true;
    private float _rotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isOnFloor)
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
        Look();
        _isOnFloor = Physics.CheckSphere(groundcheck.position, 0.2f, groundLayer);
    }

    private void Move()
    {
        Vector3 MouseVector = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * speed);
        rb.velocity = new Vector3(MouseVector.x, rb.velocity.y, MouseVector.z);
    }

    private void Look()
    {
        
        Vector2 playerLook = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        _rotation -= playerLook.y * sensitivity;
        transform.Rotate(0f, playerLook.x * sensitivity, 0f);
        if(_rotation < -90)
        {
            _rotation = -90;
        }
        if (_rotation > 90)
        {
            _rotation = 90;
        }
        cameraTransform.transform.localRotation = Quaternion.Euler(_rotation, 0f, 0f);
    }


    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


}

using Cinemachine;
using MLAPI;
using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : NetworkBehaviour
{
    private Rigidbody ball;
    private Joystick joystick;
    public float maxAngularVelocity;
    public float moveForce;
    public float jumpForce;

    bool isReachedTheGround;

    // Start is called before the first frame update
    void Start()
    {
        if (IsLocalPlayer)
        {
            CinemachineVirtualCamera cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();
            cinemachineCamera.Follow = this.transform;
            cinemachineCamera.LookAt = this.transform;
        }

        ball = this.gameObject.GetComponent<Rigidbody>();
        ball.maxAngularVelocity = maxAngularVelocity;
        isReachedTheGround = true;
        joystick = FindObjectOfType<Joystick>();
    }

    public void Jump()
    {
        if (isReachedTheGround)
        {
            ball.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Transform cameraTransform = CameraController.instance.gameObject.transform;

        ball.AddTorque(moveForce * (cameraTransform.forward * -1 * (horizontalInput + joystick.xAxis.value) + cameraTransform.right * (verticalInput + joystick.yAxis.value)), ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isReachedTheGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isReachedTheGround = false;
        }
    }

}

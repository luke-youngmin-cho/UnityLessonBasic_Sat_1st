using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float dashSpeed = 5f;
    [SerializeField] private float gravity = 9.81f;
    private Rigidbody rb;
    private Vector3 _move;
    private PlayerAnimator playerAnimator;
    private GroundSensor groundSensor;

    //=============================================================
    //--------------------- Public Methods ------------------------
    //=============================================================

    public void SetMove(float x, float z, float speed)
    {
        _move.x = x * speed;
        _move.z = z * speed;
    }


    //=============================================================
    //--------------------- Private Methods -----------------------
    //=============================================================

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<PlayerAnimator>();
        groundSensor = GetComponentInChildren<GroundSensor>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        playerAnimator.SetFloat("h", h);
        playerAnimator.SetFloat("v", v);

        if ((h == 0) && (v == 1) &&
            Input.GetKey(KeyCode.LeftShift))
        {
            SetMove(h, v, dashSpeed);
            playerAnimator.SetFloat("RunForwardBlend", 1.0f);
        }   
        else
        {
            SetMove(h, v, moveSpeed);
        }   
    }

    private void FixedUpdate()
    {
        if (groundSensor.isOn == false)
        {
            //rb.position += Vector3.down * gravity * Time.fixedDeltaTime;
            rb.AddForce(Vector3.down * gravity, ForceMode.VelocityChange);
        }   

        rb.position += _move * Time.fixedDeltaTime;
    }
}

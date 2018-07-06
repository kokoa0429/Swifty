using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerBase : MonoBehaviour {

    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private float rotationLimit = 89f;

    private Vector3 move = Vector3.zero;
    private Vector3 playerRotate = Vector3.zero;
    private float cameraRotate = 0f;
    private float bCameraRotate;

    public float jump = 0;

    public float pow = 1.0f;
    public float radius = 3.0f;

    private Rigidbody rb;

    private void Awake()
    {

        //中央にロック
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    private void Update()
    {
    }

    void FixedUpdate()
    {
        DoMove();
        DoRotate();
    }

    public void PlayerMove(Vector3 _move)
    {
        move = _move;
    }

    public void PlayerRotation(Vector3 _playerRotate)
    {
        playerRotate = _playerRotate;
    }

    public void CameraRotation(float _cameraRotate)
    {
        cameraRotate = _cameraRotate;
    }

    public void PlayerJump(float _jump)
    {
        jump = _jump;
    }


    void DoMove()
    {
        
        if(isGound())
        {
          //  Debug.Log("0");
            //rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
            Vector3 _vec = rb.velocity;
            if (move == Vector3.zero) _vec = Vector3.zero;
            else  _vec = new Vector3(move.x, rb.velocity.y, move.z);

            rb.velocity = _vec;
        }
        else if( !isGound())
        {
            Vector3 _vec = rb.velocity;//前のフレームの速度
            _vec.x *= 0.98f; //0.98倍する
            _vec.z *= 0.98f; 
            rb.AddForce(move * 2); //入力されてるキーの二倍の数値を加速度に足す
            rb.velocity = _vec;
        }
        if(jump != 0f && isGound())
        {
            //Debug.Log("jump");
            rb.velocity += new Vector3(0f, jump*3.5f, 0f);

        }
    }

    private bool isGound()
    {
        RaycastHit hit;
        bool isHit = Physics.SphereCast(transform.position, 0f , -transform.up * 10, out hit);
        //return hit.distance -1f >= 0f ? true : false;
       if (!isHit) return false;
        //Debug.Log(hit.distance);
        if (hit.distance > 0.77f) return false;
        else  return true;
    }

    void DoRotate()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(playerRotate));

        if(playerCamera != null)
        {
            //Debug.Log(playerCamera.transform.rotation.x );

            bCameraRotate += cameraRotate;
            bCameraRotate = Mathf.Clamp(bCameraRotate, -rotationLimit, rotationLimit);

            playerCamera.transform.localEulerAngles = new Vector3(bCameraRotate , 0f , 0f);

        }

    }
    
}

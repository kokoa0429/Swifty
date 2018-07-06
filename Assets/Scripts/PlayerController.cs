using UnityEngine;

[RequireComponent(typeof(PlayerBase))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float walkSpeed = 1f;
    [SerializeField]
    private float dashSpeed = 10f;
    [SerializeField]
    private float mouseSpeed = 1f;
    [SerializeField]
    private float jumpSpeed = 10f;

    private PlayerBase playerBase;

    void Start()
    {
        playerBase = GetComponent<PlayerBase>();
    }

    void Update()
    {
        float _keyX = Input.GetAxisRaw("Horizontal");
        float _keyY = Input.GetAxisRaw("Vertical");

        bool _keyDash = Input.GetKey(KeyCode.LeftShift);

        Vector3 _moveHorizonal = transform.right * _keyX;
        Vector3 _moveVertical = transform.forward * _keyY;

        float _speed;
        if (_keyDash) _speed = dashSpeed;
        else _speed = walkSpeed;

        Vector3 _move = (_moveHorizonal + _moveVertical).normalized * _speed;

        playerBase.PlayerMove(_move);

        float _mouseX = Input.GetAxisRaw("Mouse X");
        float _mouseY = Input.GetAxisRaw("Mouse Y");

        Vector3 _rotationPlayer = new Vector3(0f, _mouseX, 0f) * mouseSpeed;
        Vector3 _rotationCamera = new Vector3(-_mouseY, 0f , 0f) * mouseSpeed;

        playerBase.PlayerRotation(_rotationPlayer);
        playerBase.CameraRotation(_rotationCamera.x);

        float _keyJump = Input.GetAxisRaw("Jump");
       // Debug.Log(_keyJump);
        playerBase.PlayerJump(_keyJump * jumpSpeed);
        
    }



}

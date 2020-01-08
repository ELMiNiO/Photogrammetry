using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] private float _mouseSensivity = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMovement();
        MouseXMovement();
        MouseYMovment();
        CursorEnableCheck();
    }

    private void CharacterMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        velocity = transform.TransformDirection(velocity);
        _characterController.Move(velocity * Time.deltaTime);
        //runing test
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = 5;
        }
        else
        {
            _speed = 3.5f;
        }
    }

    private void MouseXMovement()
    {
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += mouseX * _mouseSensivity;
        transform.localEulerAngles = newRotation;
    }

    private void MouseYMovment()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 newRotation = Camera.main.transform.localEulerAngles;
        newRotation.x -= mouseY * _mouseSensivity;
        Camera.main.transform.localEulerAngles = newRotation;
    }

    private void CursorEnableCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

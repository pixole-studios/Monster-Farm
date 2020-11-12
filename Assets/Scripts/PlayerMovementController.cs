using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] private Camera _freeLookCam;
    private CharacterController _characterController;
    private float _horizontalMovement, _verticalMovement;
    private Vector3 _movement;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        if (_characterController == null)
            throw new UnityException("No Character Controller attached to capsule.");
    }

    void Update()
    {
        // If grounded, allow movement
        if (_characterController.isGrounded == true)
        {
            _horizontalMovement = Input.GetAxisRaw("Horizontal");
            _verticalMovement = Input.GetAxisRaw("Vertical");
            _movement = new Vector3(_horizontalMovement, 0, _verticalMovement);
            _movement = transform.TransformDirection(_movement);

            if (Input.GetKey(KeyCode.Space) == true)
                _movement.y = _jumpHeight;
        }

        _movement.y -= 20.0f * Time.deltaTime;

        _characterController.Move(_movement * _moveSpeed * Time.deltaTime);
        // Rotate character to face direction of camera (camera rotation currently disabled)
        transform.forward = new Vector3(_freeLookCam.transform.forward.x, 0, _freeLookCam.transform.forward.z);
    }
}
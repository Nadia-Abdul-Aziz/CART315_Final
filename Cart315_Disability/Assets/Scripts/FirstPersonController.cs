using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{

    [Header("Movement Speeds")]
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float sprintMultiplier = 2.0f;

    [Header("Jump Parameters")]
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float gravityMultiplier = 1.0f;

    [Header("Look Parameters")]
    [SerializeField] private float mouseSensitivity = 0.1f;
    [SerializeField] private float upDownLookRange = 80f;

    [Header ("References")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private PlayerInputHandler playerInputHandler;

    [Header("Head Bob")]
    [SerializeField] private float bobFrequency = 8f;
    [SerializeField] private float bobAmplitude = 0.09f;
    [SerializeField] private float bobSmoothSpeed = 10f;
    [SerializeField] private float sprintBobMultiplier = 1.5f;

private float bobTimer;
private Vector3 cameraInitialLocalPosition;
    private Vector3 currentMovement;
    private float verticalRotation;
    private float CurrentSpeed => walkSpeed * (playerInputHandler.SprintTriggered ? sprintMultiplier : 1);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cameraInitialLocalPosition = mainCamera.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleHeadBob();
    }

    private Vector3 CalculateWorldDDirection()
    {
        Vector3 inputDirection = new Vector3(playerInputHandler.MovementInput.x, 0, playerInputHandler.MovementInput.y);
        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        return worldDirection.normalized;
    }

//New stuff for bobbing
private void HandleHeadBob()
{
    bool isMoving = playerInputHandler.MovementInput.sqrMagnitude > 0.01f;
    bool isGrounded = characterController.isGrounded;

    Vector3 targetPosition = cameraInitialLocalPosition;

    if (isMoving && isGrounded)
    {
        float frequency = bobFrequency;
        float amplitude = bobAmplitude;

        if (playerInputHandler.SprintTriggered)
        {
            frequency *= sprintBobMultiplier;
            amplitude *= sprintBobMultiplier;
        }

        bobTimer += Time.deltaTime * frequency;

        float bobOffsetY = Mathf.Sin(bobTimer) * amplitude;
        targetPosition.y += bobOffsetY;
    }
    else
    {
        bobTimer = 0f;
    }

    mainCamera.transform.localPosition = Vector3.Lerp(
        mainCamera.transform.localPosition,
        targetPosition,
        Time.deltaTime * bobSmoothSpeed
    );
}

    private void HandleJumping()
    {
        if (characterController.isGrounded)
        {
            currentMovement.y = -0.5f; // Small downward force to keep grounded

            if(playerInputHandler.JumpTriggered)
            {
                currentMovement.y = jumpForce;
            }
        }
        else
        {
            currentMovement.y += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }
    }

    private void HandleMovement()
    {
        Vector3 worldDirection = CalculateWorldDDirection();
        currentMovement.x = worldDirection.x * CurrentSpeed;
        currentMovement.z = worldDirection.z * CurrentSpeed;

        HandleJumping();
        characterController.Move(currentMovement * Time.deltaTime);
    }

    private void ApplyHorizontalRotation (float rotationAmount)
    {
        transform.Rotate(0, rotationAmount, 0);
    }

    private void ApplyVerticalRotation(float rotationAmount)
    {
        verticalRotation = Mathf.Clamp(verticalRotation - rotationAmount, -upDownLookRange, upDownLookRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    private void HandleRotation()
    {
        float mouseXRotation = playerInputHandler.RotationInput.x * mouseSensitivity;
        float mouseYRotation = playerInputHandler.RotationInput.y * mouseSensitivity;

        ApplyHorizontalRotation(mouseXRotation);
        ApplyVerticalRotation(mouseYRotation);
    }
}

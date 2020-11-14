using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, IMoveInput
{
    public Command movementInput;

    private PlayerInputActions _inputActions;

    public Vector3 MoveDirection { get; private set; }
    
    public float speed = 1.0f;
    
    void Awake()
    {
        _inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();

        if (movementInput)
            _inputActions.ShipControls.Move.performed += OnMoveInput;
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        MoveDirection = new Vector3(value.x, value.y, 0.5f) * speed;
        if (movementInput != null)
            movementInput.Execute();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }
}

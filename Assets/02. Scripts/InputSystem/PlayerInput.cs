using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInput : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float movementSpeed = 3f;
    public InputController playerController;
    public GameObject uiPanel;

    Vector2 moveDirection = Vector2.zero;
    private InputAction movement;
    private InputAction openInventory;
    private InputAction attack;


    private void Awake()
    {
        playerController = new InputController();
    }

    private void OnEnable()
    {
        movement = playerController.Player.Movement;
        movement.Enable();

        attack = playerController.Player.Attack;
        attack.Enable();
        attack.performed += Attack;

        openInventory = playerController.Player.OpenInventory;
        openInventory.Enable();
        openInventory.performed += ToggleInventoryWindow;
    }

    private void OnDisable()
    {
        movement.Disable();
        attack.Disable();
        openInventory.Disable();
    }

    private void Update()
    {
        moveDirection = movement.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }

    private void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack!");   //TODO - Make Animation Setting
    }

    private void ToggleInventoryWindow(InputAction.CallbackContext context)
    {
        if(uiPanel.activeSelf)
        {
            uiPanel.SetActive(false);
        }
        else
        {
            uiPanel.SetActive(true);
        }
    }

}

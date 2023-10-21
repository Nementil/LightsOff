using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;//later

public class PlayerMovement : MonoBehaviour
{
    public GameObject inputManager;
    public Rigidbody2D rb ;

    [SerializeField] public PlayerActions playerActions;//see inputactions
    [SerializeField] private PlayerInput playerInput;//component
    [SerializeField] private InputAction moveAction;//action in map

    void Awake()
    {
        playerActions = new PlayerActions();
        playerInput = inputManager.GetComponent<PlayerInput>();
        playerActions.Keyboard.Enable();
        moveAction = playerInput.actions["Move"];
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.AddForce(new Vector2(6,0), ForceMode2D.Impulse);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if (rb != null) 
            {
                rb.AddForce(moveAction.ReadValue<Vector2>(),ForceMode2D.Impulse);
            }
        }
    }
}

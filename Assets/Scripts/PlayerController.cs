using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 200f;

    private Rigidbody rb;
    private PlayerInput playerInput;
    private InputAction action;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerInput.onActionTriggered += this.PlayerInput_onActionTriggered;
        action = playerInput.currentActionMap.FindAction("Jump");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        playerInput.onActionTriggered -= this.PlayerInput_onActionTriggered;
    }

    private void PlayerInput_onActionTriggered(InputAction.CallbackContext obj)
    {
        if (obj.action.Equals(action) && obj.ReadValueAsButton())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
        }
    }
}

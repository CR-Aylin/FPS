using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Mov_Player : MonoBehaviour
{
    PlayerController player;
    private CharacterController controller;
    Camera Camera = Camera.main;

    [Header("Valores del Movimiento")]
    private float Speed = 1f;
    private float speedrun = 2f;
    private float jumpHeight = 1.5f;
    private float GravityValue = -9.81f;

    [HideInInspector] private Vector3 velocity;
    [HideInInspector] private Vector2 input;
    [HideInInspector] private Vector3 current_mouse;
    [HideInInspector] private Vector3 moveDirection;
    [HideInInspector] private bool disparando = false;
    [HideInInspector] private bool saltando = false;
    [HideInInspector] private bool Agachado = false;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            Vector3 move = new Vector3(input.x, 0f, input.y);
            moveDirection = Vector3.ClampMagnitude(move, Speed);

        }
        moveDirection.y += GravityValue * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {

    }

    public void OnLook(InputAction.CallbackContext context)
    {
        //Mouse.current.position.ReadValue()
        current_mouse = Mouse.current.position.ReadValue();
        Camera.transform.position  = current_mouse;

    }

    public void Oninteraccion(InputAction.CallbackContext context)
    {

        
       //cambiar de armas
     }

    // direccion de la camara siguiendo mouse
}

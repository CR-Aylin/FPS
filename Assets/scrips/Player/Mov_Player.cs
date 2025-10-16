using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.UIElements.UxmlAttributeDescription;
[RequireComponent(typeof(CharacterController))]
public class Mov_Player : MonoBehaviour
{
    private CharacterController controller;
    PlayerController player;
    [Header("Referencias")]
    public Camera playercam;
    [Header("General")]
    [SerializeField] private float GravityValue = -9.81f;


    [Header("Valores del Movimiento")]
    [Header("Movimiento")]
    [SerializeField] private float Speed = 1f;
    [SerializeField] private float speedrun = 2f;
    [Header("Salto")]
    [SerializeField] private float jumpHeight = 1.5f;
    [Header("Rotacion")]
    [SerializeField] private float rotationsen = 1.5f;
    [HideInInspector] private Vector3 velocity;
    [HideInInspector] private Vector2 input;
    [HideInInspector] private Vector3 rotationinput;
    [HideInInspector] private Vector3 moveDirection;
    [HideInInspector] private float anguloCam;
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
        rotationinput = Mouse.current.position.ReadValue() * rotationsen * Time.deltaTime;

        anguloCam += rotationinput.y * Time.deltaTime;
        anguloCam = Mathf.Clamp(anguloCam,-60,60);

        transform.Rotate(Vector3.up * rotationinput.x* Time.deltaTime);
        playercam.transform.localRotation = Quaternion.Euler(-anguloCam,0f,0f);
    }

    public void Oninteraccion(InputAction.CallbackContext context)
    {

        
       //cambiar de armas
    }

    // direccion de la camara siguiendo mouse
}

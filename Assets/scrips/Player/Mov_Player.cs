using UnityEngine;
using UnityEngine.InputSystem;

public class Mov_Player : MonoBehaviour
{
    [Header("Valores del Movimiento")]
    private float Speed = 1f;
    private float jumpHeight = 1.5f;
    private float GravityValue = -9.81f;
    private bool suelo_player;

    [HideInInspector] private Vector3 velocity;
    [HideInInspector] private Vector2 input;
    [HideInInspector] private Vector3 moveDirection;

    [HideInInspector] private CharacterController controller;


    private void Awake()
    {
       controller = GetComponent<CharacterController>();
    }
    void Start()
    {
       
    }

    void Update()
    {
        // suelo_player = controller.isGrounded;
        Vector3 move = new Vector3(input.x, 0, input.y);
        controller.Move(move*Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

}

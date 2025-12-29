using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    private CharacterController characterController;
    private Animator animator;
    [SerializeField] private Transform foot;
    [SerializeField] private LayerMask colisionLayer;

    [Header("Variables")]
    public float velocity = 10f;
    private bool isGround;
    private float yForce;
    private GameManager gameManager;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        Move();
        Jump();

    }

    public void Move() {
        //Debug.Log("Executando movimento do player");
        float horizontal = 0f;
        float vertical = 0f;

        //Código para movimentar e animar player de um lado para o outro
        if (Keyboard.current.aKey.isPressed) {
            horizontal -= 1;
            animator.SetBool("MovingLeft", true);
            animator.SetBool("MovingRight", false);
            animator.SetBool("MovingFoward", false);
        } 
        if (Keyboard.current.dKey.isPressed) {
            horizontal += 1;
            animator.SetBool("MovingRight", true);
            animator.SetBool("MovingLeft", false);
            animator.SetBool("MovingFoward", false);
        } 
        if ((!Keyboard.current.aKey.isPressed && !Keyboard.current.dKey.isPressed) || Keyboard.current.aKey.isPressed && Keyboard.current.dKey.isPressed) {
            animator.SetBool("MovingRight", false);
            animator.SetBool("MovingLeft", false);
            animator.SetBool("MovingFoward", true);
        }

        //Movimenta o player pra frente
        if (gameManager.isStarted) {
            vertical += 1;
        }
        
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = Vector3.ClampMagnitude(movement, 1f);

        movement.y = 0;

        characterController.Move(movement * Time.deltaTime * velocity);

        //Verifica se player está no chão
        isGround = Physics.CheckSphere(foot.position, 0.3f, colisionLayer);
        animator.SetBool("IsGround", isGround);
    }

    public void Jump() {
        //Debug.Log("Estou no chao? " + isGround);

        // Código para calcular gravidade e fazer pulo do player
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGround) {
            yForce = 10f;
            animator.SetTrigger("Jump");
        }
        if (yForce > -9.81f) {
            yForce += -9.81f * Time.deltaTime;
        }

        characterController.Move(new Vector3(0, yForce, 0) * Time.deltaTime);
    }
}

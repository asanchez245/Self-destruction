using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_Clase : MonoBehaviour
{
    #region VARIABLES
    [HideInInspector] public Vector3 playerPos;
    [HideInInspector] public Vector2 movement;
    [HideInInspector] public Rigidbody2D rb;

    public bool playerInput;

    [SerializeField] float _speed;

    #endregion
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerInput = true;
    }


    void Update()
    {

        //Movimiento del Player
        playerPos = transform.position;

        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(movementX, movementY).normalized;
    }
    private void FixedUpdate()
    {
        //Calculo de fisicas del moviemiento del Player
        if (playerInput)
        {
            rb.linearVelocity = new Vector2(movement.x * _speed, movement.y * _speed);
        }
    }
}


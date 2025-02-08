using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using System;

public class PlayerController_Clase : MonoBehaviour
{
    #region VARIABLES
    [HideInInspector] public Vector3 playerPos;
    [HideInInspector] public Vector2 movement;
    [HideInInspector] public Rigidbody2D rb;

    public bool playerInput;

    [SerializeField] float _speed;
    [SerializeField] GameObject _deathCamera;
    [SerializeField] GameObject _gameController;
    GameControler_Clase gameControler_Clase;


    #endregion
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerInput = true;
        gameControler_Clase = _gameController.GetComponent<GameControler_Clase>();
    }


    void Update()
    {
        rb.sleepMode = RigidbodySleepMode2D.NeverSleep; //Hace que el rigidbody este siempre activo 

        //Movimiento del Player
        playerPos = transform.position;

        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(movementX, movementY).normalized;


        InventoryCheck();
    }

    private void FixedUpdate()
    {
        //Calculo de fisicas del moviemiento del Player
        if (playerInput)
        {
            rb.linearVelocity = new Vector2(movement.x * _speed, movement.y * _speed);
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    public void PlayerDeath()
    {
        playerInput = false;
        rb.linearVelocity = Vector3.zero;

        Debug.Log("Muelto");
        _deathCamera.GetComponent<CinemachineVirtualCamera>().Priority = 1;
    }
    private void InventoryCheck()
    {
        if(transform.childCount > 1)
        {
            gameControler_Clase.multiplicadorCerebro = 1 + (transform.childCount/2);
        }
        if (transform.childCount == 1)
        {
            gameControler_Clase.multiplicadorCerebro = 1f;

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Espejo") && Input.GetKey(KeyCode.E))
        {
            Debug.Log("termina el juego");
            playerInput = false;
            _deathCamera.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        }
    }
}


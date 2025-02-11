using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using System;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using JetBrains.Annotations;


public class PlayerController_Clase : MonoBehaviour
{
    #region VARIABLES
    [HideInInspector] public Vector3 playerPos;
    [HideInInspector] public Vector2 movement;
    [HideInInspector] public Rigidbody2D rb;

    public bool playerInput;
    [SerializeField] GameObject[] _letraE;
    [SerializeField] GameObject _espejo;
    [SerializeField] GameObject _mainMenuController;
    [SerializeField] GameObject _gameController;
    [SerializeField] GameObject _deathCamera;

    [SerializeField] GameObject _panelWin;
    [SerializeField] GameObject _panelDeath;
    [SerializeField] GameObject _panelFade;

    [SerializeField] float _cronoTutoText;

    [SerializeField] float _speed;
    [SerializeField] Text[] tutoTexts;
    GameControler_Clase gameControler_Clase;
    MainMenuController_Clase MainMenuController_Clase;

    [SerializeField] Animator panelAnimatorWin;
    [SerializeField] Animator panelAnimatorDeath;


    #endregion
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerInput = true;
        gameControler_Clase = _gameController.GetComponent<GameControler_Clase>();
        MainMenuController_Clase = _mainMenuController.GetComponent<MainMenuController_Clase>();
        _letraE[0].SetActive(false);
        _letraE[1].SetActive(false);
    }


    void Update()
    {
        _cronoTutoText -= Time.deltaTime;
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
        gameControler_Clase.playerDies = true;
        playerInput = false;
        rb.linearVelocity = Vector3.zero;
        _deathCamera.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        _panelFade.SetActive(true);
        MainMenuController_Clase.fadeAnimator.Play("FadeOut");
        StartCoroutine(PlayerDeathPanel());
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
        if (collision.transform.CompareTag("Espejo"))
        {
            _letraE[0].SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                gameControler_Clase.espejoEnabled = true;
                _espejo.GetComponent<Collider2D>().enabled = false;
                _letraE[0].SetActive(false);

                Debug.Log("termina el juego");
                playerInput = false;
                _deathCamera.GetComponent<CinemachineVirtualCamera>().Priority = 1;
                _panelFade.SetActive(true);
                MainMenuController_Clase.fadeAnimator.Play("FadeOut");
                StartCoroutine(PlayerWinPanel());
            }

        }
        if (collision.transform.CompareTag("Pc"))
        {
            _letraE[1].SetActive(true);
            if (Input.GetKey(KeyCode.E) && _cronoTutoText <= 0)
            {
                for(int i = 0; i < tutoTexts.Length; i++)
                {
                    if(tutoTexts[i].enabled == true)
                    {
                        tutoTexts[i].enabled = false;
                    }
                    else
                    {
                        tutoTexts[i].enabled = true;
                    }
                    _cronoTutoText = .2f;
                }
                
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Espejo"))
        {
            _letraE[0].SetActive(false);
        }
        if (collision.transform.CompareTag("Pc"))
        {
            _letraE[1].SetActive(false);
        }

        
    }
    public IEnumerator PlayerWinPanel()
    {
        yield return new WaitForSeconds(2.5f);
        _panelWin.SetActive(true);
        panelAnimatorWin.Play("Panel_In");
        yield return new WaitForSeconds(2.5f);
        panelAnimatorWin.Play("Panel_Out");
        yield return new WaitForSeconds(2f);
        _panelWin.SetActive(false);
        MainMenuController_Clase.LoadScene(0);
    }
    public IEnumerator PlayerDeathPanel()
    {
        yield return new WaitForSeconds(2.5f);
        _panelDeath.SetActive(true);
        panelAnimatorDeath.Play("Panel_In2");
        yield return new WaitForSeconds(2.5f);
        Debug.Log("panelOut");
        panelAnimatorDeath.Play("Panel_Out2");
        yield return new WaitForSeconds(2f);
        _panelDeath.SetActive(false);
        MainMenuController_Clase.LoadScene(0);
    }
}


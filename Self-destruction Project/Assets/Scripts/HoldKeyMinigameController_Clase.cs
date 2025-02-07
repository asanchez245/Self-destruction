using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using System.Collections;
using UnityEngine.UI;

public class MinigamesController_Clase : MonoBehaviour
{
    #region VARIABLES
    PlayerController_Clase playerController;
    GameControler_Clase gameController;

    [SerializeField] GameObject _player;
    [SerializeField] GameObject _gameController;
    [SerializeField] GameObject _sliderCamaObject;
    [SerializeField] Slider _sliderCama;
    [SerializeField] bool _startCama;
    [SerializeField] GameObject _camaSinHacer;
    [SerializeField] GameObject _camaHecha;
    [SerializeField] GameObject[] letras;

    Vector3 letrasScale = new Vector3(.75f, .75f, .75f);
    #endregion
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        playerController = _player.GetComponent<PlayerController_Clase>();
        gameController = _gameController.GetComponent<GameControler_Clase>();
        _sliderCamaObject.SetActive(false);
        _camaHecha.SetActive(false);
    }

    void Update()
    {
        CamaMinigame();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerController.playerInput)
        {
            if (collision.transform.tag == "Player")
            {
                switch (transform.tag)
                {
                    case ("HacerCama"):
                        _sliderCamaObject.SetActive(true);
                        _startCama = true;

                        break;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            switch (transform.tag)
            {
                case ("HacerCama"):
                    _sliderCamaObject.SetActive(false);
                    _startCama = false;
                    letras[0].gameObject.SetActive(false);
                    letras[1].gameObject.SetActive(false);
                    letras[2].gameObject.SetActive(false);
                    letras[3].gameObject.SetActive(false);
                    letras[4].gameObject.SetActive(false);

                    break;

            }

        }
    }

    public void CamaMinigame()
    {
        if (_startCama && playerController.playerInput)
        {
            if (_sliderCama.value <= 15)
            {
                letras[0].gameObject.SetActive(true);
                letras[1].gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.Z))
                {
                    _sliderCama.value += Time.deltaTime;
                    gameController.multiplicadorHigado = 2;
                }
                else
                {
                    gameController.multiplicadorHigado = 1;
                }
                #region Visual input key pressed
                if (Input.GetKeyDown(KeyCode.P))
                {
                    letras[0].transform.localScale = Vector3.one;
                }
                if (Input.GetKeyUp(KeyCode.P))
                {
                    letras[0].transform.localScale = letrasScale;
                }
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    letras[1].transform.localScale = Vector3.one;
                }
                if (Input.GetKeyUp(KeyCode.Z))
                {
                    letras[1].transform.localScale = letrasScale;
                }
                #endregion
            }
            else
            {
                letras[0].gameObject.SetActive(false);
                letras[1].gameObject.SetActive(false);

                letras[2].gameObject.SetActive(true);
                letras[3].gameObject.SetActive(true);
                letras[4].gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.L))
                {
                    _sliderCama.value += Time.deltaTime;
                    gameController.multiplicadorHigado = 2;
                }
                else
                {
                    gameController.multiplicadorHigado = 1;
                }
                #region Visual input key pressed
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    letras[2].transform.localScale = Vector3.one;
                }
                if (Input.GetKeyUp(KeyCode.Q))
                {
                    letras[2].transform.localScale = letrasScale;
                }

                if (Input.GetKeyDown(KeyCode.C))
                {
                    letras[3].transform.localScale = Vector3.one;
                }
                if (Input.GetKeyUp(KeyCode.C))
                {
                    letras[3].transform.localScale = letrasScale;
                }

                if (Input.GetKeyDown(KeyCode.L))
                {
                    letras[4].transform.localScale = Vector3.one;
                }
                if (Input.GetKeyUp(KeyCode.L))
                {
                    letras[4].transform.localScale = letrasScale;
                }
                #endregion
            }
            if (_sliderCama.value >= 30)
            {
                letras[2].gameObject.SetActive(false);
                letras[3].gameObject.SetActive(false);
                letras[4].gameObject.SetActive(false);

                _camaSinHacer.gameObject.SetActive(false);
                _sliderCamaObject.SetActive(false);
                _camaHecha.gameObject.SetActive(true);

            }
        }
    }
}
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CorrectKeyMinigame_Clase : MonoBehaviour
{

    #region VARIABLES
    PlayerController_Clase playerController;
    GameControler_Clase gameController;

    [SerializeField] GameObject _player;
    [SerializeField] GameObject _gameController;
    [SerializeField] GameObject _sliderPlatosObject;
    [SerializeField] Slider _sliderPlatos;
    [SerializeField] bool _startPlatos;
    [SerializeField] GameObject _platosSinHacer;
    [SerializeField] GameObject _platosHechos;

    [SerializeField] GameObject[] letras;
    int _currentKey;

    Vector3 letrasScale = new Vector3(.75f, .75f, .75f);

    #endregion

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        playerController = _player.GetComponent<PlayerController_Clase>();
        gameController = _gameController.GetComponent<GameControler_Clase>();
        _sliderPlatosObject.SetActive(false);
        _platosHechos.SetActive(false);

        _currentKey = 0;
    }


    void Update()
    {
        PlatosMinigame();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerController.playerInput)
        {
            if (collision.transform.tag == "Player" && Input.GetKey(KeyCode.E))
            {
                switch (transform.tag)
                {
                    case ("Platos"):
                        _sliderPlatosObject.SetActive(true);
                        _startPlatos = true;
                        playerController.playerInput = false;

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
                case ("Platos"):
                    _sliderPlatosObject.SetActive(false);
                    _startPlatos = false;
                    letras[0].gameObject.SetActive(false);
                    letras[1].gameObject.SetActive(false);
                    letras[2].gameObject.SetActive(false);
                    letras[3].gameObject.SetActive(false);
                    letras[4].gameObject.SetActive(false);

                    break;

            }

        }
    }

    public void PlatosMinigame()
    {
        if (_startPlatos)
        { 
            switch (_currentKey)
            {
                case 0:
                    letras[0].gameObject.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.G))
                    {
                        //feedback sonoro
                        _sliderPlatos.value += 5;
                        letras[0].gameObject.SetActive(false);
                        _currentKey++;
                    }
                    if(Input.anyKeyDown)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            return;
                        }
                        gameController.cerebroSlider.value -= 3;
                    }
                    break;
                case 1:
                    letras[1].gameObject.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.N))
                    {
                        _sliderPlatos.value += 5;
                        letras[1].gameObject.SetActive(false);
                        _currentKey++;
                    }
                    if (Input.anyKeyDown)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            return;
                        }
                        gameController.cerebroSlider.value -= 3;
                    }
                    break;
                case 2:
                    letras[2].gameObject.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        _sliderPlatos.value += 5;
                        letras[2].gameObject.SetActive(false);
                        _currentKey++;
                    }
                    if (Input.anyKeyDown)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            return;
                        }
                        gameController.cerebroSlider.value -= 3;
                    }
                    break;
                case 3:
                    letras[3].gameObject.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        _sliderPlatos.value += 5;
                        letras[3].gameObject.SetActive(false);
                        _currentKey++;
                    }
                    if (Input.anyKeyDown)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            return;
                        }
                        gameController.cerebroSlider.value -= 3;
                    }
                    break;
                case 4:
                    letras[4].gameObject.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        _sliderPlatos.value += 5;
                        letras[4].gameObject.SetActive(false);
                        playerController.playerInput = true;
                        gameController.doneMinigames[2] = true;
                        GetComponent<Collider2D>().enabled = false;
                    }
                    if (Input.anyKeyDown)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            return;
                        }
                        gameController.cerebroSlider.value -= 3;
                    }
                    break;
            }
        }
    }
}

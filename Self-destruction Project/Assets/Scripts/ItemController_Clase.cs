using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController_Clase : MonoBehaviour
{
    #region VARIABLES
    PlayerController_Clase playerController;
    GameControler_Clase gameControler_Clase;

    [SerializeField] GameObject _gameController;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _deposito;

    [SerializeField] int _maxInventory;


    [SerializeField] float _crono;
    [SerializeField] bool _depositado;
    bool _isDepositado = false;


    [SerializeField] AudioSource _itemAudio;


    #endregion
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _gameController = GameObject.Find("GameController");

        gameControler_Clase = _gameController.GetComponent<GameControler_Clase>();
        playerController = _player.GetComponent<PlayerController_Clase>();
        _depositado = true;


        _itemAudio = playerController.GetComponent<AudioSource>();
    }
    private void Update()
    {
        _crono -= Time.deltaTime;
        if (_deposito.transform.childCount == _maxInventory)
        {
            gameControler_Clase.doneMinigames[0] = true;

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerController.playerInput)
        {
            //Cuando el player esta en el trigger del objeto, este puede ser agarrado
            if (collision.transform.tag == "Player")
            {
                    if (_crono <= 0)
                    {
                        Debug.Log("Puedes agarrar el objeto");
                        if (Input.GetKey(KeyCode.E) && !_isDepositado)
                        {
                            _crono = .2f;
                            transform.parent = collision.transform;
                            transform.position = collision.transform.position + new Vector3(1, -.5f, 0);

                            _itemAudio.Play();
                    
                        }
                    }
            }
        
            //Cuando el item aggarrado por el player esta en el trigger de la zona de deposito, este puede ser soltado
            if (collision.transform.tag == "Deposito")
            {

                if(_crono <= 0)
                {
                    Debug.Log("Puedes dejar el objeto");
                    if (Input.GetKey(KeyCode.E))
                    {
                        _crono = .2f;
                        transform.parent = collision.transform;
                        transform.position = collision.transform.position;
                        _isDepositado = true;

                        _itemAudio.Play();

                    }
                }
                          
            }
        }
    }       
}


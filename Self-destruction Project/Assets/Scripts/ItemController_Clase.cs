using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController_Clase : MonoBehaviour
{
    #region VARIABLES
    PlayerController_Clase playerController;
    GameControler_Clase gameController;

    [SerializeField] GameObject _player;
    [SerializeField] GameObject _gameController;
    [SerializeField] float _crono;
    [SerializeField] bool _depositado;
    [SerializeField] int _maxInventory;
    [SerializeField] bool inventoryFull;
    public bool _cogerItem;
    public bool _dejarItem;

    //public GameObject _sfxController;

    #endregion
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _gameController = GameObject.Find("GameController");

        playerController = _player.GetComponent<PlayerController_Clase>();
        gameController = _gameController.GetComponent<GameControler_Clase>();
        _depositado = true;

        //_sfxController = GameObject.FindGameObjectWithTag("AudioController");
    }
    private void Update()
    {
        _crono -= Time.deltaTime;
                
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerController.playerInput)
        {
            //Cuando el player esta en el trigger del objeto, este puede ser agarrado
            if (collision.transform.tag == "Player")
            {
                if (_depositado/* && !playerController.inventoryFull*/)
                {

                    if (_crono <= 0)
                    {
                        Debug.Log("Puedes agarrar el objeto");
                        if (Input.GetKey(KeyCode.E))
                        {
                            _crono = .2f;
                            transform.parent = collision.transform;
                            transform.position = collision.transform.position + new Vector3(1, -.5f, 0);
                            _cogerItem = true;
                            _dejarItem = false;
                            //_sfxController.GetComponent<AudioController_Clase>().SonidoItems();
                            _depositado = false;
                            //playerController.inventoryFull = true;
                    
                        }
                    }
                }
            }
            //Cuando el item aggarrado por el player esta en el trigger de la zona de deposito, este puede ser soltado
            if (collision.transform.tag == "Deposito")
            {
                if (collision.transform.childCount == _maxInventory)
                {
                    inventoryFull = false;
                }
                if (!_depositado && !inventoryFull)
                {
                    if(_crono <= 0)
                    {
                        Debug.Log("Puedes dejar el objeto");
                        if (Input.GetKey(KeyCode.E))
                        {
                            _crono = .2f;
                            transform.parent = collision.transform;
                            transform.position = collision.transform.position;
                            _cogerItem = false;
                            _dejarItem = true;
                            //_sfxController.GetComponent<AudioController_Clase>().SonidoItems();
                            //_depositado = true;
                            //playerController.inventoryFull = false;
                            if(collision.transform.childCount == _maxInventory)
                            {
                                if(_maxInventory == 3)
                                {
                                    gameController.doneMinigames[0] = true;

                                }
                                if(_maxInventory == 5)
                                {
                                    gameController.doneMinigames[3] = true;

                                }
                            }
                    
                        }
                    }
                }           
            }
        }       
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using System.Collections;
using UnityEngine.UI;

public class MinigamesController_Clase : MonoBehaviour
{
    PlayerController_Clase playerController;
    [SerializeField] GameObject _player;

    [SerializeField] GameObject _sliderCamaObject;
    [SerializeField] Slider _sliderCama;
    [SerializeField] bool _startCama;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        playerController = _player.GetComponent<PlayerController_Clase>();
        _sliderCamaObject.SetActive(false);
    }

    void Update()
    {
        if (_startCama && playerController.playerInput)
        {
            if (_sliderCama.value <= 20)
            {
                //show keys p,Z
                if (Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.Z))
                {
                    _sliderCama.value += Time.deltaTime;
                }
            }
            else
            {
                //show keys Q,C,L
                if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.L))
                {
                    _sliderCama.value += Time.deltaTime;
                }
            }
            if (_sliderCama.value >= 40)
            {
                Debug.Log("cama hecha");
            }
        }
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

                    break;

            }

        }
    }
}
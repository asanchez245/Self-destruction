using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;
using Unity.Cinemachine;




public class GameControler_Clase : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] GameObject playerController;

    [SerializeField] GameObject mantaEspejo;
    [SerializeField] GameObject espejo;

    [SerializeField] GameObject _espejoCamera;

    [SerializeField] GameObject _panelPausa;

    public Slider cerebroSlider;
    public Slider pulmonesSlider;
    public Slider higadoSlider;
    public float multiplicadorCerebro;
    public float multiplicadorHigado;

    public bool respirando;
    public bool espejoEnabled;

    public bool[] doneMinigames;

    public bool playerDies;



    #endregion
    private void Start()
    {
        multiplicadorCerebro = 1;
        multiplicadorHigado = 1; 
        espejoEnabled = false;
        _panelPausa.SetActive(false);
    }

    void Update()
    {
        //Pause/Unpause game
        if (Input.GetKeyDown(KeyCode.Tab))
        {            
            PauseGame();          
        }
        cerebroSlider.value -= Time.deltaTime * multiplicadorCerebro;
        higadoSlider.value -= Time.deltaTime * 5 * multiplicadorHigado;

        switch(respirando)
        {
            case true:
                pulmonesSlider.value += Time.deltaTime;
                break;
            case false:
                pulmonesSlider.value -= Time.deltaTime;
                break;
        }

        //Player Lose
        if(cerebroSlider.value <=0 || pulmonesSlider.value <= 0 ||  higadoSlider.value <= 0)
        {
            if (!playerDies)
            {
                playerController.GetComponent<PlayerController_Clase>().PlayerDeath();
            }
        }

        CheckDoneMinigames();
    }

    private void CheckDoneMinigames()
    {
        if (doneMinigames[0] && doneMinigames[1] && doneMinigames[2])
        {
            StartCoroutine(UnlockEnding());
            if (!espejoEnabled)
            {
                espejo.GetComponent<Collider2D>().enabled = true;
            }
        }
    }

    public IEnumerator UnlockEnding()
    {
        _espejoCamera.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        yield return new WaitForSeconds(1.5f);
        mantaEspejo.SetActive(false);
        yield return new WaitForSeconds(1f);
        _espejoCamera.GetComponent<CinemachineVirtualCamera>().Priority = -1;


    }

   
    public void CerebroBoost()
    {
        cerebroSlider.value++;
    }

    public void HigadoBoost()
    {
        higadoSlider.value++;

    }

    
    public void RespiracionBoolController()
    {
        switch (respirando)
        {
            case true:
                respirando = false;
                break;
            case false:
                respirando = true;
                break;
        }
    }

    public void PauseGame()
    {
        if(Time.timeScale >= 1)
        {
            Time.timeScale = 0;
            _panelPausa.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            _panelPausa.SetActive(false);
        }
    }
    
}

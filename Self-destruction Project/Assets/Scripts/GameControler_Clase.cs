using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;



public class GameControler_Clase : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] Slider cerebroSlider;
    [SerializeField] Slider pulmonesSlider;
    [SerializeField] Slider higadoSlider;

    [SerializeField] GameObject playerController;

    [SerializeField] GameObject trashCan;

    public float multiplicadorCerebro;
    public float multiplicadorHigado;

    public bool respirando;

    #endregion
    private void Start()
    {
        multiplicadorCerebro = 1;
        multiplicadorHigado = 1;      
    }

    void Update()
    {

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
            playerController.GetComponent<PlayerController_Clase>().PlayerDeath();
        }

        //Comprobador papelera llena
        if(trashCan.transform.childCount == 3)
        {
            Debug.Log("papelera llena");
        }
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

    
}

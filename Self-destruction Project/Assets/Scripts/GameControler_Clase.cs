using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;



public class GameControler_Clase : MonoBehaviour
{

    [SerializeField] Slider cerebroSlider;
    [SerializeField] Slider pulmonesSlider;
    [SerializeField] Slider higadoSlider;

    [SerializeField] GameObject playerController;


    public bool respirando;

    void Update()
    {

        cerebroSlider.value -= Time.deltaTime;
        higadoSlider.value -= Time.deltaTime * 5;

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

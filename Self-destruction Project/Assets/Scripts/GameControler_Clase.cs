using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;



public class GameControler_Clase : MonoBehaviour
{

    [SerializeField] Slider cerebroSlider;
    [SerializeField] Slider pulmonesSlider;
    [SerializeField] Slider higadoSlider;

    [SerializeField] Slider respiracionSlider;
    bool respirando;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        cerebroSlider.value -= Time.deltaTime;
        pulmonesSlider.value -= Time.deltaTime;
        higadoSlider.value -= Time.deltaTime;

        switch(respirando)
        {
            case true:
                respiracionSlider.value += Time.deltaTime;
                break;
            case false:
                respiracionSlider.value -= Time.deltaTime;
                break;
        }

    }

    public void CerebroBoost()
    {
        cerebroSlider.value++;
    }
    public void PulmonesBoost()
    {

        pulmonesSlider.value++;

    }
    public void HigadoBoost()
    {
        higadoSlider.value++;

    }


    public IEnumerator RespiracionController()
    {
        respirando = true;
        if (Input.GetMouseButtonUp(0))
        {
            respirando = false;
        }
        yield return new WaitForSeconds(2);
        if (Input.GetMouseButtonDown(0))
        {
            respirando = true;
        }
        
    }


}

using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;



public class GameControler_Clase : MonoBehaviour
{

    [SerializeField] Slider cerebroSlider;
    [SerializeField] Slider pulmonesSlider;
    [SerializeField] Slider higadoSlider;

    [SerializeField] Slider respiracionSlider;


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

    public void RespiracionController()
    {
        respiracionSlider.enabled = true;

    }


}

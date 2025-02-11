using System.Collections;
using UnityEngine;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController_Clase : MonoBehaviour
{
    public Animator fadeAnimator;

    public IEnumerator Fade(int scene)
    {
        fadeAnimator.Play("FadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(scene);
    }

    public void LoadScene(int scene)
    {

        StartCoroutine(Fade(scene));
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class EndSliderScene : MonoBehaviour
{
    public Image FadeImg;
    public float fadeSpeed = 1.5f;
    public bool sceneStarting = true;
    public AudioClip terminateClip, transmitClip;
    public AudioSource audioSource;
    public bool transmitStarted, terminateStarted = false;

    void Awake()
    {
        transmitStarted = false;
        terminateStarted = false;
    }

    void Update()
    {
        if (terminateStarted && !audioSource.isPlaying)
            StartCoroutine("TerminateSceneRoutine");
        if (transmitStarted && !audioSource.isPlaying)
            StartCoroutine("TransmitSceneRoutine");

    }

    void FadeToBlack()
    {
        // Lerp the colour of the image between itself and black.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    public IEnumerator TerminateSceneRoutine()
    {

        // Make sure the RawImage is enabled.
        FadeImg.enabled = true;
        do
        {
            // Start fading towards black.
            FadeToBlack();

            // If the screen is almost black...
            if (FadeImg.color.a >= 0.95f)
            {
                // ... reload the level
                SceneManager.LoadScene("TerminateScene");
                yield break;
            }
            else
            {
                yield return null;
            }
        } while (true);
    }

    public IEnumerator TransmitSceneRoutine()
    {


        // Make sure the RawImage is enabled.
        FadeImg.enabled = true;
        do
        {
            // Start fading towards black.
            FadeToBlack();

            // If the screen is almost black...
            if (FadeImg.color.a >= 0.95f)
            {
                // ... reload the level
                SceneManager.LoadScene("TransmitScene");
                yield break;
            }
            else
            {
                yield return null;
            }
        } while (true);
    }

    public void TerminateScene()
    {
        if (!terminateStarted)
        {
            AudioListener.pause = false;
            audioSource.clip = terminateClip;
            audioSource.Play();
            terminateStarted = true;
        }
    }
    public void TransmitScene()
    {
        if (!transmitStarted)
        {
            AudioListener.pause = false;

            audioSource.clip = transmitClip;
            audioSource.Play();
            transmitStarted = true;
        }
    }
}

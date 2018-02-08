using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip playClip;
    public Image FadeImg;
    public float fadeSpeed = 1.5f;

	// Use this for initialization
	void Awake () {
        audioSource.clip = playClip;
        audioSource.Play();


	}

    private void Update()
    {
        if (!audioSource.isPlaying)
            EndScene();
    }

    void FadeToBlack()
    {
        // Lerp the colour of the image between itself and black.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    public IEnumerator EndSceneRoutine()
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
                SceneManager.LoadScene("StartScene");
                yield break;
            }
            else
            {
                yield return null;
            }
        } while (true);
    }

    public void EndScene()
    {
        StartCoroutine("EndSceneRoutine");
    }
}

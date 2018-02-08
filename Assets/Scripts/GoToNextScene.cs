using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GoToNextScene : MonoBehaviour
{
    public Image FadeImg;
    public float fadeSpeed = 1.5f;
    public bool sceneStarting = true;
    public AudioClip startingClip, IntroClip;
    public AudioSource audioSource;
    bool gameStarted = false;



    void Awake()
    {
        FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
        audioSource.clip = startingClip;
        audioSource.Play();
        Cursor.visible = false;

    }

    void Update()
    {
        if (!gameStarted && !audioSource.isPlaying)
            EndScene();
    }


    void FadeToClear()
    {
        // Lerp the colour of the image between itself and transparent.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
    }


    void FadeToBlack()
    {
        // Lerp the colour of the image between itself and black.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
    }


    void StartScene()
    {
        
        // Fade the texture to clear.
        FadeToClear();


        // If the texture is almost clear...
        if (FadeImg.color.a <= 0.05f)
        {
            // ... set the colour to clear and disable the RawImage.
            FadeImg.color = Color.clear;
            FadeImg.enabled = false;

            // The scene is no longer starting.
            sceneStarting = false;
        }
    }


    public IEnumerator EndSceneRoutine()
    {
        gameStarted = true;

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
                SceneManager.LoadScene("SliderScene");
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
        sceneStarting = false;
        StartCoroutine("EndSceneRoutine");
    }
}

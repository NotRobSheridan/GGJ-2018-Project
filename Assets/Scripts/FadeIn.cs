using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public Image FadeImg;
    public Canvas canvas;
    public float fadeSpeed = 10f;
    public bool sceneStarting;

	// Use this for initialization
	void Start () {
        
        FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
        canvas.transform.localScale = new Vector2(Screen.width, Screen.height);
        sceneStarting = true;
		
	}
	
	// Update is called once per frame
	void Update () {
        if(sceneStarting)
        StartScene();

	}

    void FadeToClear()
    {
        // Lerp the colour of the image between itself and transparent.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.clear,  fadeSpeed * Time.deltaTime);
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
            sceneStarting = false;

        }
    }

}

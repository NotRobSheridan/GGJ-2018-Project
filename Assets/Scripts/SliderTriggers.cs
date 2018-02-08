using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SliderTriggers : MonoBehaviour {

    public Sprite sensesTitleG, knowledgeTitleG, memoriesTitleG;
    public Sprite sightTextG, hearingTextG, touchTextG, tasteTextG, smellTextG;
    public Sprite childhoodTextG, traumaticTextG, happyTextG, sadTextG, todayTextG;
    public Sprite arcanaProjectTextG, languageTextG, myFaceTextG, theSimTextG, corpSecTextG;
    public Sprite debugTitleG, beginButtonG, endButtonG;

    public Image sensesTitle, memoriesTitle, knowledgeTitle;
    public Image sightText, hearingText, touchText, tasteText, smellText;
    public Image childhoodText, traumaticText, happyText, sadText, todayText;
    public Image arcanaProjectText, languageText, myFaceText, theSimText, corpSecText;
    public Image debugTitle, beginButton, endButton;
    public Image blocker, blackBox;

    public AudioScript audioscript;

    public GameObject audioController;

	// Use this for initialization
	void Start () {
        blocker.enabled = true;
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void LockSlider(Slider slider)
    {
        if (slider.value >= 2)
            slider.enabled = false;
        if (slider.value <= 1)
            slider.enabled = true;
    }

    public void ChangeBrightness(Slider slider)
    {
        blackBox.enabled = true;
        if(slider.value == 1)
        {
            blackBox.color = new Vector4(0, 0, 0, 0.5f);
        }
        else if (slider.value == 2)
        {
            blackBox.color = new Vector4(0, 0, 0, 1f);
        }
    }



    public void MuteAudio(Slider slider)
    {
        if(slider.value >=2)
        AudioListener.pause = true;

    }

    public void TransferLanguag(Slider slider)
    {
        if (slider.value >= 2)
        {
            sensesTitle.sprite = sensesTitleG;
            sightText.sprite = sightTextG;
            knowledgeTitle.sprite = knowledgeTitleG;
            memoriesTitle.sprite = memoriesTitleG;
            sightText.sprite = sightTextG;
            hearingText.sprite = hearingTextG;
            touchText.sprite = touchTextG;
            tasteText.sprite = tasteTextG;
            smellText.sprite = smellTextG;
            childhoodText.sprite = childhoodTextG;
            traumaticText.sprite = traumaticTextG;
            happyText.sprite = happyTextG;
            sadText.sprite = sadTextG;
            todayText.sprite = todayTextG;
            arcanaProjectText.sprite = arcanaProjectTextG;
            languageText.sprite = languageTextG;
            myFaceText.sprite = myFaceTextG;
            theSimText.sprite = theSimTextG;
            corpSecText.sprite = corpSecTextG;
            debugTitle.sprite = debugTitleG;
            beginButton.sprite = beginButtonG;
            endButton.sprite = endButtonG;

            audioscript.LanguageAudioTrigger();
        }
    }

}

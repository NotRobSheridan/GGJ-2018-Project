using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class AudioScript : MonoBehaviour
{

    public AudioClip silence, interruptAudio, outroAudio, terminateAudio;
    public AudioClip sightFirstAudio, sightFinalAudio, hearingAudio, touchFirstAudio, touchFinalAudio, smellAudio, tasteAudio;
    public AudioClip childhoodAudio, traumaticAudioFirst, traumaticAudioFinal, happyAudio, sadAudio, todayAudio;
    public AudioClip projectAudio, corporateAudio, languageAudio, faceAudio, simAudio;
    public AudioClip garbledVoice, debugAudio, introClip, errorSound;
    public AudioClip garbledVoice2, garbledVoice3, garbledVoice4;
    public AudioSource audioSource;
    public Image blocker;
    public Slider corporateSlider, traumaSlider;
    public Text subtitleText;

    public bool languageChanged, benInterrupted, blinded, deaf, noHands;

    public int sightCounter, touchCounter, traumaCounter = 0;

    // Use this for initialization
    void Start()
    {
        blocker.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
        audioSource = GetComponent<AudioSource>();
        sightCounter = 0;
        touchCounter = 0;
        traumaCounter = 0;
        languageChanged = false;
        blocker.enabled = true;
        benInterrupted = false;
        blinded = false;
        noHands = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        languageChanged = false;
        deaf = false;
        IntroTrigger();
    }

    // Update is called once per frame
    void Update()
    {

        if (noHands){
            Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
        
            if (!audioSource.isPlaying && !deaf)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                blocker.enabled = false;
                subtitleText.text = "";

            }
           else if(!audioSource.isPlaying)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                blocker.enabled = false;
                audioSource.clip.UnloadAudioData();

            }
    }
        //else if (audioSource.isPlaying && !benInterrupted)
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //}else
        //{
        //    Cursor.visible = false;
        //    Cursor.lockState = CursorLockMode.Locked;
        //}
    }
        
    public void IntroTrigger()
    {
        blocker.enabled = true;
        audioSource.clip = introClip;
        audioSource.Play();
        subtitleText.text = "Hello! The ARCANA Project would like to personally thank you for participating in our combat simulation program! Unfortunately, during the simulation...you died. But don’t worry! We’ve uploaded your mind to the cloud and have a shiny new body ready for you that has almost all of the limbs you’d expect a normal human body to have.";
        Invoke("IntroTextTwo", 17);

    }

    public void OutroTrigger()
    {
        blocker.enabled = true;
        audioSource.clip = outroAudio;
        audioSource.Play();
    }

    public void TerminateTrigger()
    {

        //blocker.enabled = true;
        //audioSource.clip = terminateAudio;
        //audioSource.Play();
    }

    public void SightTrigger(Slider slider)
    {
        if (slider.value >= 2 && sightCounter >= 1)
        {
            blinded = true;
            blocker.enabled = true;
            if (languageChanged)
            {
                audioSource.clip = garbledVoice3;
                audioSource.Play();
                subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";

            }
            else
            {
                audioSource.clip = sightFinalAudio;
                audioSource.Play();
                subtitleText.text = "Oh, you’ve transmitted all of your sight. That was silly, wasn’t it? Well, I’m sure you can figure the rest of this out without seeing anything. I have added in some handy auditory feedback for you, though. You’re welcome. ";
            }
        }
        else if (slider.value >= 1 && sightCounter <= 0)
        {
            
            blocker.enabled = true;
            if (languageChanged)
            {
                StartCoroutine(ResetSliderDelay(slider, 3));
                audioSource.clip = garbledVoice2;
                audioSource.Play();
                subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";

            }
            else
            {
                StartCoroutine(ResetSliderDelay(slider, 3));
                audioSource.clip = sightFirstAudio;
                audioSource.Play();
                subtitleText.text = "Ah yes, you’ll want your new body to be able to see - good plan!";
            }

            sightCounter++;
        }



    }

    public void HearingTrigger(Slider slider)
    {
        if (slider.value <= 1)
        {
            StartCoroutine(ResetSliderDelay(slider, 3));

            blocker.enabled = true;
            if (languageChanged)
            {
                
                audioSource.clip = garbledVoice2;
                audioSource.Play();
                subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";

            }
            else
            {
                audioSource.clip = hearingAudio;
                audioSource.Play();
                subtitleText.text = "Beginning transmission of auditory senses. Can you still hear me? Think about nodding if you can hear me. ";
            }
        }
        if (slider.value >= 2)
        {
            slider.enabled = false;
            deaf = true;
            blocker.enabled = true;
            if (languageChanged)
            {
                subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";
            }
            else
            {
                audioSource.clip = silence;
                audioSource.Play();
                blocker.enabled = false;
                subtitleText.text = "Congratulations! You’re now unable to hear… well, anything. Temporarily, at least. This also means I can stop talking and you can just read these nifty subtitles until we're done - great.";
            }
            }
    }

    public void TouchTrigger(Slider slider)
    {
        if (touchCounter >= 1 && slider.value >=2)
        {
            if (languageChanged)
            {
                audioSource.clip = garbledVoice;
                audioSource.Play();
                subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";
                noHands = true;
                Invoke("GoToTransmitScene", 12);
            }
            else
            {
                audioSource.clip = touchFinalAudio;
                audioSource.Play();
                subtitleText.text = "Oh, well, this is inconvenient.You’ve fully transmitted your sense of touch. Now you won’t be able to think about touching anything in the Transfer Tool. Well, I suppose we’ll just end the transmission here, then.";
                noHands = true;
                Invoke("GoToTransmitScene", 12);
            }


        }
        else if (touchCounter <=0 && slider.value <=1)             
        {
            StartCoroutine(ResetSliderDelay(slider, 3));
            if (languageChanged)
            {
                audioSource.clip = garbledVoice2;
                audioSource.Play();
                subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";

            }
            else
            {
                audioSource.clip = touchFirstAudio;
                audioSource.Play();
                subtitleText.text = "Beginning touchy-feely transmission. You might feel a slight tingling in your fingers, or whatever you think your fingers feel like, because you don’t currently have fingers, do you?";
            }
            blocker.enabled = true;
            touchCounter++;
        }
    }

    public void SmellTrigger(Slider slider)
    {
        if (slider.value >= 2)
        {
            blocker.enabled = true;

            if (languageChanged)
            {
                audioSource.clip = garbledVoice3;
                audioSource.Play();
                subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";

            }
            else
            {
                audioSource.clip = smellAudio;
                audioSource.Play();
                subtitleText.text = "Olfactory senses transmitted. Lucky you! For a brief moment, you’ll have the pleasure of not being able to smell yourself. Or whatever you think you smell like.";
            }
        }
    }

    public void TasteTrigger(Slider slider)
    {
        if (slider.value >= 2)
        {
            blocker.enabled = true;
            if (languageChanged)
            {
                audioSource.clip = garbledVoice4;
                audioSource.Play();
                subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";

            }
            else
            {
                audioSource.clip = tasteAudio;
                audioSource.Play();
                subtitleText.text = "Do you remember the taste of your favourite meal? No? Good! That means that everything worked perfectly! However, if you think you can still remember the taste of blood and are tasting it now… just try to ignore it.";
            }
        }
    }

    public void ChildhoodTrigger(Slider slider)
    {
        if (slider.value >= 2)
        {
            blocker.enabled = true;
            if (languageChanged)
            {
                audioSource.clip = garbledVoice;
                audioSource.Play();
                subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";

            }
            else
            {
                audioSource.clip = childhoodAudio;
                audioSource.Play();
                subtitleText.text = "Ah, your formative years. A shame about all that bullying. And the time your crush read your diary aloud to the entire class. And that time you were menaced by a herd of angry geese and your “friends” uploaded the video to YouTube and it went viral. Heh.";
            }
        }
    }

    public void TraumaTrigger(Slider slider)
    {

        if (slider.value >= 2 && traumaCounter >= 1)
        {
            blocker.enabled = true;
            if (languageChanged)
            {
                audioSource.clip = garbledVoice3;
                audioSource.Play();
                subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";

            }
            else
            {
                audioSource.clip = traumaticAudioFinal;
                audioSource.Play();
                subtitleText.text = "You’ve successfully set your traumatic memories to transfer! I definitely have not made a note of them to use them against you later.";
            }
        }
        else if (slider.value >=2 && traumaCounter <=0)
        {
            StartCoroutine(ResetSliderDelay(slider, 3));

            blocker.enabled = true;
            if (languageChanged)
            {
                audioSource.clip = garbledVoice4;
                audioSource.Play();
                subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";
                Invoke("ResetTrauma", 5);
                traumaCounter++;

            }
            else
            {
                slider.enabled = false;
                audioSource.clip = traumaticAudioFirst;
                audioSource.Play();
                subtitleText.text = "Oh good! You decided to transmit your traumatic memories. According to this, you transferred memories of your spouse leaving you and that recurring nightmare about paperclips! Oh wait. By saying that I bet I’ve reset those memories, haven’t I? Let’s try that again… ";
                Invoke("ResetTrauma", 13);
                traumaCounter++;
            }

        }
    }

    public void HappyTrigger(Slider slider)
    {
        if (slider.value >= 2)
        {
            blocker.enabled = true;
            if (languageChanged)
            {
                audioSource.clip = garbledVoice2;
                audioSource.Play();
                subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";

            }
            else
            {
                audioSource.clip = happyAudio;
                audioSource.Play();
                subtitleText.text = "Oh, that’s nice - you’ve decided to transmit your happy memories. It’s good to have happy memories - they’ll stop you from turning into a heartless killing machine when you’re in your new body!";
            }
        }
    }

    public void SadTrigger(Slider slider)
    {
        if (slider.value >= 2)
        {
            blocker.enabled = true;
            if (languageChanged)
            {
                audioSource.clip = garbledVoice;
                audioSource.Play();
                subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";

            }
            else
            {
                audioSource.clip = sadAudio;
                audioSource.Play();
                subtitleText.text = "Sad memories are important, too - they make remembering the good times even better. I wouldn’t know, though - I had all of mine removed months ago and I FEEL GREAT HAHAHAHAHA.";
            }
        }
    }

    public void TodayTrigger(Slider slider)
    {
        if (slider.value >= 2)
        {
            blocker.enabled = true;
            if (languageChanged)
            {
                audioSource.clip = garbledVoice4;
                audioSource.Play();
                subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";

            }
            else
            {
                audioSource.clip = todayAudio;
                audioSource.Play();
                subtitleText.text = "No, I don’t think you want to remember today. Let me fix that for you.";
            }
            Invoke("DestroyToday", 6);
        }
    }

    public void ProjectTrigger(Slider slider)
    {
        slider.enabled = false;
        if (slider.value >= 1)
        {
            blocker.enabled = true;
            if (languageChanged)
            {
                audioSource.clip = garbledVoice2;
                audioSource.Play();
                subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";

            }
            else
            {
                audioSource.clip = projectAudio;
                audioSource.Play();
                subtitleText.text = "You can try to transfer your knowledge of the ARCANA Project, but I assure you that it’s much more trouble than it's worth.";
            }
        }
    }

    public void LanguageAudioTrigger()
    {
        languageChanged = true;
        blocker.enabled = true;
        audioSource.clip = languageAudio;
        audioSource.Play();
        subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";
    }

    public void CorporateTrigger(Slider slider)
    {
        blocker.enabled = true;
        if (languageChanged)
        {
            audioSource.clip = garbledVoice3;
            audioSource.Play();
            subtitleText.text = "Alerghserh, fleprneh gksh mdjemrslm seppgh uehs, smmlfpurhsp, ksejrn, flrnneslmm kerm hfksi urnsh pllaerk uerhsn mnr hhqyrs";

        }
        else
        {
            audioSource.clip = corporateAudio;
            audioSource.Play();
            subtitleText.text = "JENKINS! WHY IS THIS SLIDER IN THE PUBLIC-FACING VERSION?! WHAT?! I DON’T CARE WHOSE JOB IT IS - GET IT REMOVED IMMEDIATELY.";

        }

        Invoke("DestroyCorporate", 7.3f);

    }

    public void FaceTrigger(Slider slider)
    {
        slider.enabled = false;

        if (slider.value >= 1)
        {
            blocker.enabled = true;
            if (languageChanged)
            {
                audioSource.clip = garbledVoice4;
                audioSource.Play();
            }
            else
            {
                audioSource.clip = faceAudio;
                audioSource.Play();
                subtitleText.text = "No, not your face - my face! I can’t have you recognising me in the street - it might cause an adverse reaction. This slider is only here to make sure you remember to forget my face";
            }

        }
    }

    public void SimulationTrigger(Slider slider)
    {
        slider.enabled = false;
        if (slider.value >= 1)
        {
            blocker.enabled = true;
            if (languageChanged)
            {
                audioSource.clip = garbledVoice;
                audioSource.Play();
            }
            else
            {
                audioSource.clip = simAudio;
                audioSource.Play();
                subtitleText.text = "On second thoughts, it’s probably better that you don’t remember the combat simulation - you did some awful, awful things in there… Seriously: you should really get some help.";
            }
        }
    }

    void DestroyCorporate()
    {
        audioSource.clip = errorSound;
        audioSource.Play();
        Destroy(GameObject.Find("CorporateSecretsSlider"));
    }

    void DestroyToday()
    {
        audioSource.clip = errorSound;
        audioSource.Play();
        Destroy(GameObject.Find("TodaySlider"));
    }

    public void InterruptBen()
    {
        if (!benInterrupted)
        {
            subtitleText.text = "Do you mind?! Now I’ve lost my train of thought - I’ll have start again from the beginning… Hello. This is the ARCANA Project, we'd like to personally thank you for participating in our combat simulation program. Unfortunately… you know what? Just get on with it.";
            benInterrupted = true;
            audioSource.Stop();
            audioSource.clip = interruptAudio;
            audioSource.Play();
            Cursor.visible = true;

        }
    }

    void GoToTransmitScene()
    {
        SceneManager.LoadScene("TransmitScene");

    }

    void ResetTrauma()
    {
        audioSource.clip = errorSound;
        audioSource.Play();
        traumaSlider.value = 0;
        traumaSlider.enabled = true;

    }

    void IntroTextTwo()
    {
        if (!benInterrupted)
        {
            subtitleText.text = "We just need your help transmitting your mind into your new body using the ARCANA Simulation Transfer Tool (patent pending). In front of you… well, not in front of you, there isn’t really anything in front of you - you’re just a simulation of a brain inside a compu-";
            Invoke("IntroTextThree", 14);
        }
    }

    void IntroTextThree()
    {
        if (!benInterrupted)
        {
            subtitleText.text = "You should see lots of different sliders in front of you! These sliders are an abstract way of helping you focus your thoughts on the things you want to transmit to your new body! Just think really hard about moving those sliders and we’ll start transferring those parts of your mind! You can transfer as much or as little as you like, just be sensible about it.";
            Invoke("IntroTextFour", 15);
        }
    }
    void IntroTextFour()
    {
        if (!benInterrupted)
        {
            Cursor.visible = true;

            subtitleText.text = "If you can’t think hard enough, just use the Abstract Thought Focusing Cursor (patent also pending) to move the sliders. Once you move a slider all the way to the right, we’ll have that part of your consciousness ready to be transmitted to your new body.";
            Invoke("IntroTextFive", 11);
        }
    }
    void IntroTextFive()
    {
        if (!benInterrupted)
        {
            benInterrupted = true;
            subtitleText.text = "You will lose access to your memories and senses as part of the process, but they’ll be right where you left them when you wake up in your new body! Probably… When you’re finished, click the BEGIN TRANSMISSION button. Good luck!";
        }
    }

    IEnumerator ResetSliderDelay(Slider slider, int delay)
    {
        Debug.Log("EnumStarted");
        slider.enabled = false;
        yield return new WaitForSeconds(delay);
        slider.enabled = true;
    }
}
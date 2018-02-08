using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSnapBack : MonoBehaviour {

    Slider slider;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (slider.value >= 1)
            slider.value = Mathf.Lerp(slider.value, 0, 1.0f);
	}
}

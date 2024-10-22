using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingBar : MonoBehaviour
{
    public Slider LoadingBarSlider;
    public Text LoadingText;

    float LoadingBarSliderMaxValue = 100.0f;
    float LoadingBarSliderAddValue = 0.1f;

    void Start()
    {

    }

    void Update()
    {
        if (LoadingBarSlider.value < LoadingBarSliderMaxValue)
        {
            LoadingBarSlider.value += LoadingBarSliderAddValue;
            LoadingText.text = LoadingBarSlider.value.ToString("F0") + "%";
        }
        else
        {
            LoadingBarSlider.gameObject.SetActive(false);
            LoadingText.gameObject.SetActive(false);
        }
    }
}

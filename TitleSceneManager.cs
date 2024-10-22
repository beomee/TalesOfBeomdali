using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TitleSceneManager : MonoBehaviour
{
    public Button StartBtn;
    public Slider LoadingBarSlider;
    public Image TipImage;

    void Start()
    {
        StartBtn.onClick.AddListener(ClickStart);
    }

    void ClickStart()
    {
        SceneManager.LoadScene("InGameScene");
    }

    void Update()
    {
        if (LoadingBarSlider != null)
        {
            if (LoadingBarSlider.value == 100)
            {
                StartBtn.gameObject.SetActive(true);
                TipImage.gameObject.SetActive(false);
            }
        }
    }

    

}

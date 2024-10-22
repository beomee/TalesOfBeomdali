using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goods : MonoBehaviour
{
    public Text goldText;
    public Text starText;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = Json.instance.data.gold.ToString();
        starText.text = Json.instance.data.star.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider playerHp;
    public Slider playerMp;

    // Start is called before the first frame update
    void Start()
    {
        playerHp.value = Json.instance.data.hp;
        playerMp.value = Json.instance.data.mp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

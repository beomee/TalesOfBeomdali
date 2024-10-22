using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogEnemy : Enemy
{
    float A = 0.1f;
    float b = 0.1f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        enemyHp = 10;
        print(enemyHp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

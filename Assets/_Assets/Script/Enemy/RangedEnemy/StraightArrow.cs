using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightArrow : EnemyAttack
{
    // sau 5s huy neu ko trung 
    private float lifeTime = 5f;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}

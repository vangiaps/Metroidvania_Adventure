using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3Fireball : Collision_Check_When_Attacking
{
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    protected override void DestroyGameobject()
    {
        Destroy(gameObject);
    }
}

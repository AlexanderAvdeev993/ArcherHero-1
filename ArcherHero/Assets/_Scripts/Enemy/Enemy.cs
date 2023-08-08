using System;
using UnityEngine;

public class Enemy : Entity
{
    
    
    protected override void Die()
    {
        base.Die();
        //Destroy(gameObject);
    }
}
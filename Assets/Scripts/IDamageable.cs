using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    int HitPoints {get; set;}
    void Damage(int damage);
}

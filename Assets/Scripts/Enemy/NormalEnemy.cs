using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy, IDamageable
{
    public int HitPoints { get; set; }
    public float Speed { get; set; }
    [SerializeField]
    GameObject _powerUp;

    // Start is called before the first frame update
    void Start()
    {
        HitPoints = base._hitpoints;
        Speed = base._speed;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Movement();
    }

    public void Damage(int damage)
    {
        HitPoints -= damage;

        if (HitPoints <= 0)
        {
            PowerUpBehavior pwrUp = _powerUp.GetComponent<PowerUpBehavior>();
            pwrUp.SpawnPowerUp(transform);
            Destroy(gameObject);
        }
    }

    public override void Movement()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);

    }

    //ADDED TODAY 16/05
    public int GetHitPoints()
    {
        return HitPoints;
    }
}

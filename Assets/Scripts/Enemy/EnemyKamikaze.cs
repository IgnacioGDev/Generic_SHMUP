using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikaze : Enemy, IDamageable
{
    public int HitPoints { get; set; }
    public float Speed { get; set; }
    [SerializeField]
    GameObject _powerUp;

    // Start is called before the first frame update
    void Start()
    {
        Transform playerPos = GameObject.Find("Player").GetComponent<Transform>();

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

    public float num;
    public bool dontChase;
    public override void Movement()
    {
        Transform playerPos = GameObject.Find("Player").GetComponent<Transform>();
        num += Time.deltaTime;

        Debug.Log(Vector2.Distance(transform.position, playerPos.position));


        Vector2 xTarget = new Vector2(playerPos.position.x, transform.position.y);
        if (Vector2.Distance(transform.position, playerPos.position) <= 3)
        {
            dontChase = true;
        }
        transform.position = Vector2.Lerp(transform.position, xTarget, 4 * Time.deltaTime);


        if (!dontChase)
        {
        }
        else
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y * _speed * Time.deltaTime);
        }


        transform.position += Vector3.down * _speed * Time.deltaTime;


    }

    //ADDED TODAY 16/05
    public int GetHitPoints()
    {
        return HitPoints;
    }
}

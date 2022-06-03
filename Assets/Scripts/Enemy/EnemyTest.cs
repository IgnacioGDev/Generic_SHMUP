using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _vSpeed;
    [SerializeField]
    bool hasReachedPoint = false;

    [SerializeField]
    float acceleration;
    [SerializeField]
    float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Movement();
    }


    public float turnSpeed = .01f;
    Quaternion rotGoal;

    private void Movement()
    {
        var playerTransform = GameObject.Find("Player").transform.position;
        playerTransform.z = 0;

        Vector3 lookAt = playerTransform - transform.position;
        transform.right = lookAt;
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(lookAt), turnSpeed);

        if (!hasReachedPoint)
        {
            if (transform.position.x < 0)
            {
                var finalPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.25f, Screen.height * 0.75f));
                transform.position = Vector2.Lerp(transform.position, finalPos, _speed * Time.deltaTime);

                if (transform.position.x >= (finalPos.x - 0.0005f))
                {
                    hasReachedPoint = true;
                }

            }
            else if (transform.position.x > 0)
            {
                var finalPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.75f, Screen.height * 0.75f));
                transform.position = Vector2.Lerp(transform.position, finalPos, _speed * Time.deltaTime);
                
                if (transform.position.x <= (finalPos.x + 0.0005f))
                {
                    hasReachedPoint = true;
                }

            }
            //Enemigo se mueve a punto inicial
            //Una vez llega a 1er punt, empieza a disparar a player y empieza a moverse lentamente hacia abajo    
        }

        else
        {
            //transform.Translate(Vector2.down * _vSpeed * Time.deltaTime);
            //transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, -9f), _vSpeed * Time.deltaTime);
            transform.Translate(new Vector3(0, acceleration * Time.deltaTime, 0), Space.World);

            if (acceleration > maxSpeed)
            {
                acceleration -= 0.05f;
            }
        }
    }
}

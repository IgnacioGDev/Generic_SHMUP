using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : PlayerState
{
    public override void Update()
    {
        base.Update();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            _hitPoints--;
        }
        else if (other.gameObject.CompareTag("PowerUp"))
        {
            //Debug.Log("Collision with POWERUP");
            PowerUpBehavior powerUp = other.gameObject.GetComponent<PowerUpBehavior>();
            _powerUpState = powerUp.PowerUpId;
            Destroy(other.gameObject);
        }
    }
}

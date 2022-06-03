using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    private static PlayerState _instance;

    [SerializeField]
    protected int _hitPoints;
    [SerializeField]
    protected int _lifeCounter;
    [SerializeField]
    protected bool _isAlive;
    [SerializeField]
    protected int _powerUpState;
    [SerializeField]
    protected bool _isShieldActive;
    [SerializeField]
    protected GameObject _shieldPwrUp;
    // Start is called before the first frame update

    public static PlayerState Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Instance can't be null");
            }
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {
        //Debug.Log("PowerUp " + _powerUpState + " picked");

        PlayerDeath();
        PowerUpState();


    }

    public virtual void PlayerDeath()
    {
        if (_hitPoints <= 0)
        {
            gameObject.SetActive(false);
            _isAlive = false;
        }
    }

    public int GetPlayerHitPoints()
    {
        return _hitPoints;
    }

    public int GetPlayerExtraLives()
    {
        return _lifeCounter;
    }

    public bool GetPlayerState()
    {
        return _isAlive;
    }

    public virtual void PowerUpState()
    {
        switch (_powerUpState)
        {
            case 1:
                RestoreHealth();
                break;
            case 2:
                PowerUpShield();
                break;
            case 3:
                break;
            default:
                break;
        }
    }

    public virtual void RestoreHealth()
    {
        if (_hitPoints < 3 && _powerUpState == 1)
        {
            _hitPoints++;
        }
        _powerUpState = 0;

    }

    public virtual void PowerUpShield()
    {
        if (_powerUpState == 2)
        {
            Instantiate(_shieldPwrUp, transform.position, Quaternion.identity);
        }
        _powerUpState = 0;
    }
}

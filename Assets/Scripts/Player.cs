using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] int mHealth = 25;
    [SerializeField] ParticleSystem _DeathParticles;
    [SerializeField] AudioClip _DeathSound;

    int _currentHealth;
    public int score = 0;

    TankController _tankController;

    public int Health
    {
        get => mHealth;
        set => mHealth = value;
    }

    // Start is called before the first frame update
    /**private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
 
    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's Health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
        Debug.Log("Player's Health: " + _currentHealth);
        if(_currentHealth <= 0)
        {
            Kill();
        }
    }
    **/
    public void Death()
    {
        if (_DeathParticles != null)
        {
            _DeathParticles = Instantiate(_DeathParticles, transform.position, Quaternion.identity);


        }

        if (_DeathSound != null)
        {
            AudioHelper.PlayClip2D(_DeathSound, 1f);
        }

        gameObject.SetActive(false);

    }


    void Update()
    {
        
    }

    public void Damage(int _damage)
    {
        Health -= _damage;
        if (Health <= 0)
        {
            Death();
        }
    }
}

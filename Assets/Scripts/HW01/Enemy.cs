using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] int _damageAmount = 1;

    [SerializeField] ParticleSystem _DeathParticles;
    [SerializeField] AudioClip _DeathSound;


    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damag = collision.gameObject.GetComponent<IDamagable>();
        damag.Damage(1000);
    }

    protected virtual void Death()
    {
        if (_DeathParticles != null)
        {
            _DeathParticles = Instantiate(_DeathParticles, transform.position, Quaternion.identity);


        }

        if (_DeathSound != null)
        {
            AudioHelper.PlayClip2D(_DeathSound, 1f);
        }
        Destroy(this.gameObject);
    }
    //protected virtual void PlayerImpact(Player player)
    //{
    //    player.DecreaseHealth(_damageAmount);
    //}

    private void ImpactFeedback()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    


}

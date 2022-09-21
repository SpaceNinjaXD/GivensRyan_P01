using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectibleBase : MonoBehaviour
{

    

    protected abstract void Collect(Player player);

    [SerializeField] float _movementSpeed = 1;
    protected float MovementSpeed => _movementSpeed;

    [SerializeField] ParticleSystem _collectedParticles;
    [SerializeField] AudioClip _collectSound;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement(_rb);
    }

    protected virtual void Movement(Rigidbody rb)
    {
        Quaternion turnOffset = Quaternion.Euler(0, _movementSpeed, 0);
        rb.MoveRotation(_rb.rotation * turnOffset);

    }


    private void OnTriggerEnter(Collider collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {

            Collect(player);
            Feedback();

            gameObject.SetActive(false);
        }
    }

    private void Feedback()
    {
        if(_collectedParticles != null)
        {
            _collectedParticles = Instantiate(_collectedParticles, transform.position, Quaternion.identity);


        }

        if (_collectSound != null)
        {
            AudioHelper.PlayClip2D(_collectSound, 1f);
        }
    }
    }
    


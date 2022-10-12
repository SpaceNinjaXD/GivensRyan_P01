using Inheritance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy, IDamagable
{
    [SerializeField] protected int mHealth;
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private Transform phaseStart;
    [SerializeField] private Transform phaseEnd;
    [SerializeField] private float phaseOneSpeed;
    [SerializeField] private float phaseTwoSpeed;
    [SerializeField] public Transform boss;
    [SerializeField] public BoxCollider hitbox;
    [SerializeField] public GameObject projectile;
    [SerializeField] public Transform barrel1;

    [SerializeField] public Transform spikePlaceMid;
    [SerializeField] public Transform spikePlaceLeft;
    [SerializeField] public Transform spikePlaceRight;
    [SerializeField] public Transform mid;
    [SerializeField] public GameObject wave;
    //private Spikes spikeMid;
    //private Spikes spikeLeft;
    //private Spikes spikeRight;

    public float cooldownSecondsOne;
    public float cooldownSecondsTwo;


    float _cooldownSecondsRemaining;

    private bool phaseTwo = false;
    private bool phaseAnimation = false;
    private Transform target;
    private int halfHealth;

    private int i = 0;

    private void Awake()
    {
        target = pointA.transform;
        halfHealth = Health / 2;
    }

    void Start()
    {

        _cooldownSecondsRemaining = cooldownSecondsOne;
    }

    public int Health
    {
        get => mHealth;
        set => mHealth = value;
    }

    public void Damage(int _damage)
    {
        Health -= _damage;

        if (Health <= halfHealth && phaseTwo == false)
        {
            phaseTwo = true;
        }

        if (Health <= 0)
        {
            Death();
        }
        
    }

    private bool up = false;
    public void Move()
    {
        if (phaseTwo == false)
        {
            var step = phaseOneSpeed * Time.deltaTime;
            if (up == true)
            {

                target = pointA.transform;
            }
            else
            {

                target = pointB.transform;
            }

            transform.position = Vector3.MoveTowards(transform.position, target.position, step);



            if (Vector3.Distance(transform.position, target.position) < 1f)
            {
                if (up == true)
                {
                    up = false;
                }
                else if (up == false)
                {
                    up = true;
                }
            }
        }

        if (phaseTwo == true && phaseAnimation == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, phaseStart.position, .7f);

            if (Vector3.Distance(transform.position, phaseStart.position) < 1f)
            {
                StartCoroutine(phaseTwoAnimation());
                
            }
        }
        if (phaseTwo == true && phaseAnimation == true)
        {
            //SpawnFirstSpikes();
            var step = phaseTwoSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, phaseEnd.position, step);
            
        }

    }

    private bool firstSpike = false;
   // private void SpawnFirstSpikes()
    //{
        //if(firstSpike == false)
        //{
            //spikeMid = Instantiate(spike, spikePlaceMid.position, Quaternion.Euler(0, 0, 0), this.transform).GetComponent<Spikes>();

            //spikeLeft = Instantiate(spike, spikePlaceLeft.position, Quaternion.Euler(0, 0, 0), this.transform).GetComponent<Spikes>();
            //spikeRight = Instantiate(spike, spikePlaceRight.position, Quaternion.Euler(0, 0, 0), this.transform).GetComponent<Spikes>();
            //firstSpike = true;
        //}
    //}
    IEnumerator phaseTwoAnimation()
    {
        float timer = 0;

        while (true) // this could also be a condition indicating "alive or dead"
        {
            // we scale all axis, so they will have the same value, 
            // so we can work with a float instead of comparing vectors
            while (boss.transform.localScale.z < 110)
            {
                timer += Time.deltaTime;
                boss.transform.localScale += new Vector3(0, 0, 1) * Time.deltaTime * 2;
                yield return null;
            }
            // reset the timer
            hitbox.size = new Vector3(5.20560f, 4.859333f, 110f);
            phaseAnimation = true;                                  
            _cooldownSecondsRemaining = cooldownSecondsTwo;



            
            yield return new WaitForSeconds(5);
            /**
                        timer = 0;
                        while (1 < transform.localScale.x)
                        {
                            timer += Time.deltaTime;
                            transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * 3;
                            yield return null;
                        }

                        timer = 0;
                        yield return new WaitForSeconds(5);
                    }**/
        }
    }

    
        void Shoot()
        {
            if (phaseTwo == false)
            {
                Instantiate(projectile, barrel1.position, Quaternion.Euler(0, -70, 0));
                Instantiate(projectile, barrel1.position, Quaternion.Euler(0, -75, 0));
                Instantiate(projectile, barrel1.position, Quaternion.Euler(0, -80, 0));
                Instantiate(projectile, barrel1.position, Quaternion.Euler(0, -85, 0));
                Instantiate(projectile, barrel1.position, Quaternion.Euler(0, -90, 0));
                Instantiate(projectile, barrel1.position, Quaternion.Euler(0, -95, 0));
                Instantiate(projectile, barrel1.position, Quaternion.Euler(0, -105, 0));
                Instantiate(projectile, barrel1.position, Quaternion.Euler(0, -100, 0));
                Instantiate(projectile, barrel1.position, Quaternion.Euler(0, -110, 0));
            }
            if(phaseTwo == true)
            {
                
                int num = Random.RandomRange(1, 5);
                while(num == i)
            {
                num = Random.RandomRange(1, 5);
            }
            i = num;
            
                if(num == 1)
            {
                Instantiate(wave, spikePlaceLeft.position, Quaternion.Euler(0, -90, 0));

            }
            if (num == 2)
            {
                Instantiate(wave, spikePlaceRight.position, Quaternion.Euler(0, -90, 0));

            }
            if (num == 3)
            {
                Instantiate(wave, spikePlaceMid.position, Quaternion.Euler(0, -90, 0));

            }
            if(num == 4)
            {
                Instantiate(wave, mid.position, Quaternion.Euler(0, -90, 0));
            }
        }

        }



        void Update()
        {
            if (_cooldownSecondsRemaining > 0)
            {
                _cooldownSecondsRemaining -= Time.deltaTime;
            }
            else
            {
                
                
                if(phaseTwo == false)
            {
                Debug.Log("test");
                Shoot();
                _cooldownSecondsRemaining = cooldownSecondsOne;
            }
            else
            {
                Debug.Log("test");
                Shoot();
                _cooldownSecondsRemaining = cooldownSecondsTwo;
                Debug.Log(_cooldownSecondsRemaining);
                Debug.Log("test");
            }
                


            }

        }


        void FixedUpdate()
        {
            Move();
            
        }


    }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{

    [SerializeField] float powerupDuration = 8;

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {

            PowerUp(player);
            StartCoroutine(PowerupStarted(powerupDuration));
            PowerDown();
        }
    }



    IEnumerator PowerupStarted(float duration)
    {

        Debug.Log("Power up started");

        yield return new WaitForSeconds(duration);


        Debug.Log("Power up ended");
    }

    protected abstract void PowerUp(Player player);


    protected virtual void PowerDown()
    {
        gameObject.SetActive(false);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Camera _cam;
    public GameObject projectile;
    public Transform Barrel;
    [SerializeField] AudioClip _fire;
    public bool isTrueTurrent = true;
    void Awake()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var mousePosition = Input.mousePosition;

        Vector3 rot = Quaternion.LookRotation(mousePosition).eulerAngles;
        rot.x = rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);

        if (Input.GetKeyDown(KeyCode.Space) && isTrueTurrent != false)
        {

            if (_fire != null)
            {
                AudioHelper.PlayClip2D(_fire, .5f);
            }
            Instantiate(projectile, Barrel.position, Quaternion.Euler(0,90,0));
            
        }
    }
}

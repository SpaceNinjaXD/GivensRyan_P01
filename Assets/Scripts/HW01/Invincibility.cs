using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    

    protected override void PowerUp(Player player)
    {
        var playerRenderer = player.gameObject.GetComponent<Renderer>();

        playerRenderer.material.SetColor("_Color", Color.cyan);
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

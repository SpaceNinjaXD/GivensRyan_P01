using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Treasure : CollectibleBase
{
    [SerializeField] int treasureAmount = 1;
    [SerializeField] private TMP_Text score;


    protected override void Collect(Player player)
    {
        player.score += treasureAmount;
        score.text = "Treasures: " + player.score;
    }

  
    // Update is called once per frame
    void Update()
    {
        
    }
}

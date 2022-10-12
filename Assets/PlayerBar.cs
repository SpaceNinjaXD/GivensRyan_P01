using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerBar : MonoBehaviour
{
    public Slider slider;
    public Player boss;
    // Start is called before the first frame update
    void Awake()
    {
        slider.maxValue = boss.Health;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        slider.value = boss.Health;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Boss _boss;
    [SerializeField] Player _player;
    [SerializeField] private TMP_Text BB_Health;
    [SerializeField] private TMP_Text player_Health;

    private void FixedUpdate()
    {
        player_Health.text = "Player Health: " + _player.Health;

        BB_Health.text = "Boss Health: " + _boss.Health;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("Sandbox");
        }

    }
}

using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvas : MonoBehaviour
{
    GameObject player;
    public Slider HealthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        HealthBar.maxValue = PlayerHealth.instance.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        HealthBar.value = PlayerHealth.instance.Health;
    }
}

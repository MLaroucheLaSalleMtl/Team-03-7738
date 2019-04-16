using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    private Player player;
    private UIManager ui;
    public ParticleSystem[] healingEffect;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        ui = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ui.HealthBar.fillAmount = player.CurrLife / player.MaxLife;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            HealthRegen();
            healingEffect[0].Play();
            healingEffect[1].Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Out");
            healingEffect[0].Stop();
        }
    }
    private void HealthRegen()
    {
        if (player.CurrLife < player.MaxLife)
        {
            player.CurrLife = player.MaxLife;
        }
    }
}

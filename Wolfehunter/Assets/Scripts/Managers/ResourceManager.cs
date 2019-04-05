using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    /* Summary --- 
     * Here we control stamina regeneration, food going down
     * as well as cold going up / down.
     * This script is attached to the player.
     */

    //References
    private Player player;
    private UIManager ui;

    //Variables
    [SerializeField] private float staminaRegen;

    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        StaminaRecharge();
    }

    private void StaminaRecharge()
    {
        //A percentage of stamina is recharged over x seconds
        if (player.CurrStamina < player.MaxStamina)
        {
            ui.StaminaBar.gameObject.SetActive(true);
            player.CurrStamina += staminaRegen * Time.deltaTime;
            ui.StaminaBar.fillAmount = player.CurrStamina / player.MaxStamina;
        }
    
        else {
            ui.StaminaBar.gameObject.SetActive(false);
        }

    }
}

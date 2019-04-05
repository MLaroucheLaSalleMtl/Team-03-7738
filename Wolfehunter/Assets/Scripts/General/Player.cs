using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Resources")]
    [SerializeField] private float currLife;
    [SerializeField] private float maxLife;
    [SerializeField] private float currStamina;
    [SerializeField] private float maxStamina;
    [SerializeField] private float currFood;
    [SerializeField] private float maxFood;
    [SerializeField] private float currCold;
    [SerializeField] private float maxCold;

    private int damageGiven;

    public float CurrLife { get => currLife; set => currLife = value; }
    public float MaxLife { get => maxLife; set => maxLife = value; }
    public float CurrFood { get => currFood; set => currFood = value; }
    public float MaxFood { get => maxFood; set => maxFood = value; }
    public float CurrCold { get => currCold; set => currCold = value; }
    public float MaxCold { get => maxCold; set => maxCold = value; }
    public float CurrStamina { get => currStamina; set => currStamina = value; }
    public float MaxStamina { get => maxStamina; set => maxStamina = value; }
    public int DamageGiven { get => damageGiven; set => damageGiven = value; }

    private CombatManager combat;
    private GameManager game;
    private UIManager ui;

    public void TakeDamage(int damage)
    {
        if (CurrLife > 50)
        {
            CurrLife -= damage;
        }
        else
        {
            Die();
            Time.timeScale = 0f;

        }
    }

    void Die()
    {
        ui.DeathPanel.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        combat = GetComponent<CombatManager>();
        game = FindObjectOfType<GameManager>();
    }


    public void CalculateDamage() //takes weapon
    {
        // if game found sword x then damage =....
         //; + weapon
        if (game.HasWeapon)
        {
            damageGiven = 100;
        }
    }
    // Update is called once per frame

    void Update()
    {
        ui.HealthBar.fillAmount = CurrLife / MaxLife;
    }
}

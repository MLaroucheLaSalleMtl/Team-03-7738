using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    /* Summary : Class that holds the variables 
     * for the UI, to be used in other scripts
     */
    private int ui;

    private Animator infoAnim;
    private Player player;

    //[SerializeField]private Image[] heart;
    [Header("RESOURCE ELEMENTS")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image staminaBar;
    [SerializeField] private Image temperatureBar;
    [SerializeField] private Image foodBar;
    [Header("UI ELEMENTS")]
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private TextMeshProUGUI infoText;
    [Header("DOGQUEST ELEMENTS")]
    [SerializeField] private GameObject questPanel;
    [SerializeField] private TextMeshProUGUI npcName;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [Header("FANG ELEMENTS")]
    [SerializeField] private GameObject fangPanel;
    [SerializeField] private Image[] fang = new Image[5];
    [Header("MENU ELEMENTS")]
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject winPanel;

    public Image StaminaBar { get => staminaBar; set => staminaBar = value; }
    public Image HealthBar { get => healthBar; set => healthBar = value; }

    public TextMeshProUGUI InteractText { get => interactText; set => interactText = value; }
    public GameObject QuestPanel { get => questPanel; set => questPanel = value; }
    public TextMeshProUGUI DialogueText { get => dialogueText; set => dialogueText = value; }
    public TextMeshProUGUI NpcName { get => npcName; set => npcName = value; }
    public GameObject InfoPanel { get => infoPanel; set => infoPanel = value; }
    public TextMeshProUGUI InfoText { get => infoText; set => infoText = value; }
    public GameObject FangPanel { get => fangPanel; set => fangPanel = value; }
    public Image[] Fang { get => fang; set => fang = value; }
    public GameObject DeathPanel { get => deathPanel; set => deathPanel = value; }
    public GameObject WinPanel { get => winPanel; set => winPanel = value; }



    //public static float healthCurr;
    //public static float healthMax;
    //public static float temperatureCurr;
    //public static float temperatureMax;
    //public static float foodCurr;
    //public static float foodMax;

    private void Awake()
    {
        infoAnim = InfoPanel.GetComponent<Animator>();
        StaminaBar.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {

        //player = GetComponent<Player>();
        //healthBar = GetComponent<Image>();
        //temperatureBar = GetComponent<Image>();
        //foodBar = GetComponent<Image>();
        //healthCurr = player.CurrLife;
        //healthMax = player.MaxLife;
        //temperatureCurr = player.CurrCold;
        //temperatureMax = player.MaxCold;
        //foodCurr = player.CurrFood;
        //foodMax = player.MaxFood;
    }


    public void FadePanel()
    {
        InfoPanel.gameObject.SetActive(true);
        Invoke("Wait", 1.25f);
    }

    private void Wait()
    {

            infoAnim.SetBool("Fade", false);
            Invoke("DisableUI", 1.5f);


    }

    private void DisableUI()
    {
        InfoPanel.gameObject.SetActive(false);

    }

    void Update()
    {
    }
}

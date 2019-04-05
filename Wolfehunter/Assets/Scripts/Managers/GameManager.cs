using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool hasBone;
    private bool hasWeapon;

    [SerializeField] private int wolfKill;

    // [SerializeField] GameObject firstRiddle;
    // [SerializeField] GameObject firstRiddleInscription;

    public bool HasWeapon { get => hasWeapon; set => hasWeapon = value; }
    public bool HasBone { get => hasBone; set => hasBone = value; }
    public int WolfKill { get => wolfKill; set => wolfKill = value; }

    // Start is called before the first frame update
    void Start()
    {
       // firstRiddle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}

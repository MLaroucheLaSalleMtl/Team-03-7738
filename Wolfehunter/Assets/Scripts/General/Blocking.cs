using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : MonoBehaviour
{
    [SerializeField] private GameObject[] questDoor = new GameObject[3];

    private bool[] onlyOnce = new bool[3];

    private DialogueManager dog;

    //[0] is dog quest door

    // Start is called before the first frame update
    void Start()
    {
        dog = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dog.ObjectiveReached && !onlyOnce[0])
        {
            questDoor[0].gameObject.SetActive(false);
            onlyOnce[0] = false;
        }
    }
}

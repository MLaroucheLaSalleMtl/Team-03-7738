using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndChapter : MonoBehaviour
{
    private UIManager ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
            //Debug.Log("Gameover");
            //ui.WinPanel.gameObject.SetActive(true);
        }
    }
}

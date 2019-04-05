using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public GameObject playerTrans;
    private Transparent lastTrans;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DetectorPlayer());
        playerTrans = GameObject.Find("Player");
        //playerTrans = playerTrans.GetComponent<Transform>();
    }
    
    IEnumerator DetectorPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Vector3 direction = (playerTrans.transform.position - Camera.main.transform.position).normalized;
            RaycastHit rayCast;
            if(Physics.Raycast(Camera.main.transform.position, direction, out rayCast, Mathf.Infinity))
            {
                Transparent transparent = rayCast.collider.gameObject.GetComponent<Transparent>();
                if (transparent)
                {
                    transparent.SetTransparent();
                    lastTrans = transparent;
                }
                else
                {
                    if (lastTrans)
                    {
                        lastTrans.SetToNormal();
                        lastTrans = null;
                    }
                }
            }
        }
    }
}

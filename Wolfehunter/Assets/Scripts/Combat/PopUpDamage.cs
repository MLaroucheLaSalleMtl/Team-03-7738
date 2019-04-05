using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDamage : MonoBehaviour
{
    public Camera m_Camera;
    public float DestroyTime = 3f;
    public Vector3 OffSet = new Vector3(0, 2, 0);
    public Vector3 RandomPos = new Vector3(1f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = FindObjectOfType<Camera>();
        Destroy(gameObject, DestroyTime);

        transform.localPosition += OffSet;
        transform.localPosition += new Vector3(Random.Range(-RandomPos.x, RandomPos.x), 
                                               Random.Range(-RandomPos.y, RandomPos.y), 
                                               Random.Range(-RandomPos.z, RandomPos.z));
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform.position, -Vector3.up);
    }

}

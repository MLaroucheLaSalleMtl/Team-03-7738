using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Color transparentColor;
    [SerializeField]private Color initialColor;
    void Start()
    {
        initialColor = GetComponent<Renderer>().material.color;
    }

    public void SetTransparent()
    {
        GetComponent<Renderer>().material.color = transparentColor;
    }

    public void SetToNormal()
    {
        GetComponent<Renderer>().material.color = initialColor;
    }
}

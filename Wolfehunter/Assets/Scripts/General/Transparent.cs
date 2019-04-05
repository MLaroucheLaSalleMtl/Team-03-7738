using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    public Color transparentColor;
    public Color m_InitialColor;
    public Renderer renderer;

    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        m_InitialColor = renderer.material.color;
    }

    public void SetTransparent()
    {
        renderer.material.color = transparentColor;
    }

    public void SetToNormal()
    {
        renderer.material.color = m_InitialColor;
    }
}

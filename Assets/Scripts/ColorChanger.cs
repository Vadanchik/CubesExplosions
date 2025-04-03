using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Renderer _renderer;

    public void SetColor(Color color)
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = color;
    }
}
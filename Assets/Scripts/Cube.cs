using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Exploder))]
[RequireComponent(typeof(ColorChanger))]
public class Cube : MonoBehaviour
{

    public event Action<Cube> Activating;

    private float _divisionChance = 1.0f;

    public float DivisionChance => _divisionChance;
    public Exploder Exploder { get; private set; }
    public ColorChanger ColorChanger { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Exploder = GetComponent<Exploder>();
        ColorChanger = GetComponent<ColorChanger>();
    }

    public void Init(Vector3 scale, float chance, Color color)
    {
        transform.localScale = scale;
        _divisionChance = chance;
        ColorChanger.SetColor(color);
    }

    public void Explode(List<Cube> cubes)
    {
        Exploder.Explode(cubes);
    }

    public void Activate()
    {
        float chance = UnityEngine.Random.value;

        if (chance < _divisionChance)
        {
            Activating?.Invoke(this);
        }

        Destroy(gameObject);
    }
}
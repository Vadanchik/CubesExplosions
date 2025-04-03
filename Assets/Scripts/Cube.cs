using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Exploder))]
[RequireComponent(typeof(ColorChanger))]
public class Cube : MonoBehaviour
{
    private float _divisionChance = 1.0f;

    public event Action<Cube> Activating;

    public float DivisionChance => _divisionChance;
    public float ExplosionRadius => Exploder.Radius;
    public Exploder Exploder { get; private set; }
    public ColorChanger ColorChanger { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Exploder = GetComponent<Exploder>();
        ColorChanger = GetComponent<ColorChanger>();
    }

    public void Init(Vector3 scale, float chance, Color color, float radius)
    {
        transform.localScale = scale;
        _divisionChance = chance;
        ColorChanger.SetColor(color);
        Exploder.SetRadius(radius);
    }

    public void Activate()
    {
        float chance = UnityEngine.Random.value;

        if (chance < _divisionChance)
        {
            Activating?.Invoke(this);
        }
        else
        {
            Exploder.ExplodeArea();
        }

        Destroy(gameObject);
    }

    public void ExplodeCubes(List<Cube> cubes)
    {
        Exploder.ExplodeCubes(cubes);
    }
}
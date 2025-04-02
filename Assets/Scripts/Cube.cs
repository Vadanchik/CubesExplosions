using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private CubeCreator _cubeCreator;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private InputService _input;

    private float _explosionForce = 10;
    private float _divisionChance = 1.0f;

    private void OnEnable()
    {
        _input.ObjectClicked += Activate;
    }

    private void OnDisable()
    {
        _input.ObjectClicked -= Activate;
    }

    public void SetScale(Vector3 scale)
    {
        transform.localScale = scale;
    }

    public void SetDivisionChance(float chance)
    {
        _divisionChance = chance;
    }

    public void SetCubeCreator(CubeCreator cubeCreator)
    {
        _cubeCreator = cubeCreator;
    }

    public void SetColor(Color color)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = color;
    }

    private void Activate()
    {
        float chance = Random.value;

        if (chance < _divisionChance)
        {
            Explode(_cubeCreator.CreateCubes(transform.position, transform.localScale, _divisionChance));
        }

        Destroy(gameObject);
    }

    private void Explode(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            Vector3 direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
            cube.GetComponent<Rigidbody>().AddForce(direction * _explosionForce, ForceMode.Impulse);
        }

        Instantiate(_effect, transform.position, Quaternion.identity).transform.localScale = transform.localScale;
    }
}


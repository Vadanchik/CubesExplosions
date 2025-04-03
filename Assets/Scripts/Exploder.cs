using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _maxExplosionForce = 20;
    [SerializeField] private float _explosionRadius = 2;

    public float Radius => _explosionRadius;

    public void SetRadius(float radius)
    {
        _explosionRadius = radius;
    }

    public void ExplodeArea()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider hit in hits)
        {
            if (hit.transform.TryGetComponent<Cube>(out Cube cube))
            {
                Vector3 direction = cube.transform.position - transform.position;
                cube.Rigidbody.AddForce(direction.normalized * _maxExplosionForce * (1 - (direction.magnitude / _explosionRadius)), ForceMode.Impulse);
            }
        }

        Instantiate(_effect, transform.position, Quaternion.identity).transform.localScale = transform.localScale;
    }

    public void ExplodeCubes(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            Vector3 direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
            cube.Rigidbody.AddForce(direction * _maxExplosionForce, ForceMode.Impulse);
        }

        Instantiate(_effect, transform.position, Quaternion.identity).transform.localScale = transform.localScale;
    }
}
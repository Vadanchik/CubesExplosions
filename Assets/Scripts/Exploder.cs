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

    public void Explode()
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
}
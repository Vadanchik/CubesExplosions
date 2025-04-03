using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _explosionForce = 10;


    public void Explode(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            Vector3 direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
            cube.Rigidbody.AddForce(direction * _explosionForce, ForceMode.Impulse);
        }

        Instantiate(_effect, transform.position, Quaternion.identity).transform.localScale = transform.localScale;
    }
}
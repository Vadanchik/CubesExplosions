using System.Collections.Generic;
using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    [SerializeField] private int _minCubesCount = 2;
    [SerializeField] private int _maxCubesCount = 6;

    [SerializeField] private float _reductionMultiplier = 0.5f;
    [SerializeField] private float _chanceReduction = 0.5f;

    public List<Cube> CreateCubes(Vector3 position, Vector3 scale, float chance)
    {
        List<Cube> cubes = new List<Cube>();

        int cubesCount = Random.Range(_minCubesCount, _maxCubesCount);

        for (int i = 0; i < cubesCount; i++)
        {
            Cube cube = Instantiate(_cubePrefab, position, Quaternion.identity);
            cube.SetColor(Random.ColorHSV());
            cube.SetDivisionChance(chance * _chanceReduction);
            cube.SetScale(scale * _reductionMultiplier);
            cube.SetCubeCreator(this);

            cubes.Add(cube);
        }

        return cubes;
    }
}

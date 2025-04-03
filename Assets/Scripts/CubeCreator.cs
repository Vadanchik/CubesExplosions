using System.Collections.Generic;
using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private List<Cube> _startedCubes;

    [SerializeField] private int _minCubesCount = 2;
    [SerializeField] private int _maxCubesCount = 6;

    [SerializeField] private float _reductionMultiplier = 0.5f;
    [SerializeField] private float _chanceReduction = 0.5f;

    private void OnEnable()
    {
        foreach (Cube cube in _startedCubes)
        {
            cube.Activating += CreateCubes;
        }
    }

    private void OnDisable()
    {
        foreach (Cube cube in _startedCubes)
        {
            cube.Activating -= CreateCubes;
        }
    }

    private void CreateCubes(Cube currentCube)
    {
        currentCube.Activating -= CreateCubes;

        List<Cube> cubes = new List<Cube>();

        int cubesCount = Random.Range(_minCubesCount, _maxCubesCount);

        for (int i = 0; i < cubesCount; i++)
        {
            Cube cube = Instantiate(_cubePrefab, currentCube.transform.position, Quaternion.identity);
            cube.Init(currentCube.transform.localScale * _reductionMultiplier, currentCube.DivisionChance * _chanceReduction, Random.ColorHSV());

            cube.Activating += CreateCubes;
            cubes.Add(cube);
        }

        currentCube.Explode(cubes);
    }
}
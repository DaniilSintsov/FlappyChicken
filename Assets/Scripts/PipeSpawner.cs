using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _obstacles;
    [SerializeField] private GameState _gameState;
    [SerializeField] private int _maxAmountOfPipesOnScene = 6;

    private Queue<GameObject> _obstaclesPull = new Queue<GameObject>();

    private void Start()
    {
        StartCoroutine(PipeSpawnerRoutine());
        StartCoroutine(PipeRemoverRoutine());
    }

    private IEnumerator PipeSpawnerRoutine()
    {
        while (true)
        {
            if (_gameState.IsStart && !_gameState.IsStop && !_gameState.IsOver)
            {
                float randomYPos = Random.Range(-1f, 1f);
                GameObject newObstacle = Instantiate(_obstacles, new Vector3(5, randomYPos, 0), Quaternion.identity);
                newObstacle.GetComponent<ObstaclesMove>().SetGameState(_gameState);
                _obstaclesPull.Enqueue(newObstacle);
            }

            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator PipeRemoverRoutine()
    {
        while (true)
        {
            if (_gameState.IsStart && !_gameState.IsStop && !_gameState.IsOver &&
                _obstaclesPull.Count > _maxAmountOfPipesOnScene)
            {
                GameObject toDestroy = _obstaclesPull.Dequeue();
                Destroy(toDestroy);
            }

            yield return new WaitForSeconds(1);
        }
    }
}

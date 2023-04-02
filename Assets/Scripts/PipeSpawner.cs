using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _obstacles;
    [SerializeField] private GameState _gameState;
    [SerializeField] private int _maxAmountOfPipesOnScene = 6;

    private List<GameObject> _obstaclesPool = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(PipeSpawnerRoutine());
        StartCoroutine(PipeRemoverRoutine());
    }

    private IEnumerator PipeSpawnerRoutine()
    {
        while (true)
        {
            if (_gameState.IsGameActive())
            {
                float randomYPos = Random.Range(-1f, 1f);
                float distanceBetweenObstacles = 2f;
                float firstObstaclePosX = 5f;
                float newObstaclePosX = firstObstaclePosX;
                GameObject newObstacle;

                if (_obstaclesPool.Count > 0)
                {
                    float lastObstaclePosX = _obstaclesPool[^1].transform.position.x;
                    newObstaclePosX = lastObstaclePosX + distanceBetweenObstacles;

                    if (lastObstaclePosX <= 4f)
                    {
                        CreateNewObstacle(out newObstacle, newObstaclePosX, randomYPos);
                    }
                }
                else
                {
                    CreateNewObstacle(out newObstacle, newObstaclePosX, randomYPos);
                }
            }

            yield return null;
        }
    }

    private IEnumerator PipeRemoverRoutine()
    {
        while (true)
        {
            if (_gameState.IsGameActive() &&
                _obstaclesPool.Count > _maxAmountOfPipesOnScene)
            {
                Destroy(_obstaclesPool[0]);
                _obstaclesPool.RemoveAt(0);
            }

            yield return null;
        }
    }

    private void CreateNewObstacle(out GameObject newObstacle, float newObstaclePosX, float randomYPos)
    {
        newObstacle = Instantiate(_obstacles,
            new Vector3(newObstaclePosX, randomYPos, 0),
            Quaternion.identity);
        newObstacle.GetComponent<ObstaclesMove>().SetGameState(_gameState);
        _obstaclesPool.Add(newObstacle);
    }
}

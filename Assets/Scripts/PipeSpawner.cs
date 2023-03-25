using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _obstacles;
    [SerializeField] private GameState _gameState;

    private void Start()
    {
        StartCoroutine(PipeSpawnerRoutine());
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
                Destroy(newObstacle, 8);
            }

            yield return new WaitForSeconds(1);
        }
    }
}

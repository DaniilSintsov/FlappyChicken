using UnityEngine;

public class ObstaclesMove : MonoBehaviour
{
    [SerializeField] private float speed;

    private GameState _gameState;

    private void Update()
    {
        if (_gameState && _gameState.IsGameActive())
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
    }

    public void SetGameState(GameState gameState)
    {
        _gameState = gameState;
    }
}

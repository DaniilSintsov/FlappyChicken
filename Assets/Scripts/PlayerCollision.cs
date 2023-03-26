using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameState _gameState;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {

            _gameState.SetOver();
        }

        if (other.gameObject.TryGetComponent(out Score score))
        {
            _gameState.AddScore();
        }
    }
}

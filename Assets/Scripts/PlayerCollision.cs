using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private GameState _gameState;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            _rigidbody.isKinematic = true;
            _gameState.SetOver();
        }

        if (other.gameObject.TryGetComponent(out Score score))
        {
            _gameState.AddScore();
        }
    }
}

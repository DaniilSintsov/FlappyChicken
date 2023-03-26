using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private GameState _gameState;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !_gameState.IsStop &&
            !_gameState.IsOver)
        {
            if (_rigidbody.isKinematic)
            {
                _rigidbody.isKinematic = false;
            }

            _gameState.SetStart();

            _rigidbody.velocity = Vector3.up * force;
        }

        if (Input.GetKeyDown(KeyCode.Escape) &&
            !_gameState.IsOver)
        {
            _gameState.ToggleStop();
        }
    }
}

using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private GameState _gameState;
    [SerializeField] private GameObject _pausePanel;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !_gameState.IsStop &&
            !_gameState.IsOver && !_pausePanel.activeSelf)
        {
            if (_rigidbody.isKinematic)
            {
                _rigidbody.isKinematic = false;
            }

            _gameState.SetStart();

            _rigidbody.velocity = Vector3.up * force;
        }
    }
}

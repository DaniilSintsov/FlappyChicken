using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TMP_Text _gameOverScoreText;
    [SerializeField] private TMP_Text _mainMenuScoreText;

    public bool IsStart { get; private set; }
    public bool IsStop { get; private set; }
    public bool IsOver { get; private set; }
    public int Score { get; private set; }

    private void Awake()
    {
        IsStart = false;
        IsStop = false;
        IsOver = false;

        _mainMenuScoreText.text = $"Ваш рекорд: {PlayerPrefs.GetInt("Score")}";
    }

    public void SetStart()
    {
        IsStart = true;
    }

    public void SetOver()
    {
        IsOver = true;
        IsStop = false;
        _pausePanel.SetActive(IsStop);

        _player.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        Destroy(_player.gameObject);

        if (Score > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", Score);
        }

        _gameOverPanel.SetActive(true);
        _gameOverScoreText.text = $"Ваш счет: {Score}";
    }

    public void ToggleStop()
    {
        IsStop = !IsStop;
        _player.gameObject.GetComponent<Rigidbody>().isKinematic = IsStop;
        _pausePanel.SetActive(IsStop);
    }

    public void AddScore()
    {
        Score++;
        _scoreText.text = $"Счет: {Score}";
    }
}

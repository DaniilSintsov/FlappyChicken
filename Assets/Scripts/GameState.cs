using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool IsStart { get; private set; }
    public bool IsStop { get; private set; }
    public bool IsOver { get; private set; }
    public int Score { get; private set; }

    private void Awake()
    {
        IsStart = false;
        IsStop = false;
        IsOver = false;
    }

    public void SetStart()
    {
        IsStart = true;
    }

    public void SetOver()
    {
        IsOver = true;
    }

    public void ToggleStop()
    {
        IsStop = !IsStop;
    }

    public void AddScore()
    {
        Score++;
    }
}

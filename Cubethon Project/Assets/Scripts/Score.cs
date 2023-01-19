using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public delegate void ScoreStarted();
    public static event ScoreStarted OnScoreStarted;

    public Transform player;
    public Text scoreText;

    void Update()
    {
        OnScoreStarted();
    }

    void PlayStartUI()
    {
        if (player != null)
        {
            scoreText.text = player.position.z.ToString("0");
        }
    }

    void Start()
    {
        OnScoreStarted += PlayStartUI;
    }
}

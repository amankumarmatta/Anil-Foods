using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TextMeshProUGUI scoreText;
    public int score;

    void Awake() => Instance = this;

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}

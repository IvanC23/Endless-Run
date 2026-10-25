using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TMP_Text scoreText;
    
    private int score = 0;

    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void IncreaseScore(int amount)
    {
        if (gameManager.IsGameOver) return;
        
        score += amount;
        scoreText.text = score.ToString();
    }
}

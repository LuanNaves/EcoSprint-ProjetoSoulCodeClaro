using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    private float score;
    private float pointsForCollectable = 50f;
    private float pointsForDiscardedRight = 100f;
    private float pointsForDiscardedWrong = -50f;
    private float streak;
    private float streakMultiplier;

    private Animator scoreTextAnimator;

    public void Start() {
        scoreTextAnimator = scoreText.GetComponent<Animator>();
    }

    public void IncreaseScoreWhenCollected() {
        score += pointsForCollectable * GetStreakMultiplier();
        scoreTextAnimator.SetTrigger("ScoreIncrease");
        UpdateUI();

    }
    public void IncreaseScoreDiscard() {
        score += pointsForDiscardedRight * GetStreakMultiplier();
        scoreTextAnimator.SetTrigger("ScoreIncrease");
        UpdateUI();
    }
    public void DecreaseScore() {
        if (score > 0) {
            score += pointsForDiscardedWrong;
        }
        scoreTextAnimator.SetTrigger("ScoreDecrease");
        UpdateUI();
    }
    public void IncreaseStreak() {
        streak += 1f;
        UpdateUI();
    }
    public void StreakEnded() {
        streak = 1f;
        UpdateUI();
    }
    
    public void UpdateUI() {
        switch (GetStreakMultiplier()) {
            case 1:
                scoreText.color = Color.white;
                break;
            case 2:
                scoreText.color = Color.green;
                break;
            case 3:
                scoreText.color = Color.blue;
                break;
            case 4:
                scoreText.color = Color.purple;
                break;
            default:
                return;
        }
        scoreText.text = "Score: " + score.ToString() + " " + GetStreakMultiplier().ToString() + "X";
    }
    public float GetStreakMultiplier() {
        if (streak >= 5f) { 
            streakMultiplier = 2f;
        } else {
            streakMultiplier = 1f;
        }
        if (streak >= 10f) {
            streakMultiplier = 3f;
        }
        if (streak >= 15f) {
            streakMultiplier = 4f;
        }

        return streakMultiplier;
    }

}

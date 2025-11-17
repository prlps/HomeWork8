using UnityEngine;
using TMPro;

namespace Golf
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        private int score = 0;

        public void AddPoints(int points)
        {
            score += points;
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
            }
        }

        public int GetScore()
        {
            return score;
        }

        public void ResetScore()
        {
            score = 0;
            UpdateUI();
        }
    }
}

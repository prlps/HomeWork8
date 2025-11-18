using UnityEngine;
using UnityEngine.SceneManagement;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private int m_maxHitCount = 5;
        [SerializeField] private int m_missedCount = 3;
        [SerializeField][Min(0)] private float m_spawnRate = 0.5f;
        [SerializeField] private StoneSpawner m_stoneSpawner;
        [SerializeField] private ScoreManager scoreManager;

        private float m_time;
        private int m_currentHitCount = 0;
        private int m_currentMissedCount;
        private bool m_showWinScreen = false;
        private bool m_showLossScreen = false;

        private void Awake()
        {
            m_currentMissedCount = m_missedCount;
            scoreManager?.ResetScore();
        }

        private void Update()
        {
            m_time += Time.deltaTime;

            if (m_time >= m_spawnRate)
            {
                if (m_stoneSpawner != null)
                {
                    Stone stone = m_stoneSpawner.Spawn();
                    if (stone != null)
                    {
                        stone.Hit += OnHitStone;
                        stone.Missed += OnMissed;
                    }
                }

                m_time = 0f;
            }
        }

        private void OnHitStone(Stone stone)
        {
            UnsubscribleStone(stone);

            m_currentHitCount++;
            scoreManager?.AddPoints(1);

            if (m_currentHitCount >= m_maxHitCount)
            {
                m_showWinScreen = true;
                Time.timeScale = 0f;
                Debug.Log("You won!!!");
            }
        }

        private void OnMissed(Stone stone)
        {
            UnsubscribleStone(stone);

            m_currentMissedCount--;
            Debug.Log("Missed left: " + m_currentMissedCount);

            if (m_currentMissedCount <= 0)
            {
                m_showLossScreen = true;
                Time.timeScale = 0f;
                Debug.Log("Game Over");
            }
        }

        private void RestartLevel()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    
        private void UnsubscribleStone(Stone stone)
        {
            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissed;
        }
    }
}

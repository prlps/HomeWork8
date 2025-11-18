using TMPro;
using UnityEngine;

namespace Golf
{
    public class GamePlayState : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private ScoreManager m_scoreManager;
        public void Initialize()
        {
            m_scoreText.gameObject.SetActive(false);
            m_gameStateaMacjine = GameStateMachine;
        }
        public void Enter()
        {
            m_scoreManager.ResetScore();
            m_scoreManager.ScoreChanged += OnScoreChanged;

            OnScoreChanged(m_scoreManager.score);
            m_scoreText.gameObject.SetActive(true);

            m_levelController.enabled = true;
            m_playerController.enabled = false;


        }

        public void Exit() 
        {
            m_levelController.enabled=false;
            m_playerController.Enabled=false;


        }
    }
}

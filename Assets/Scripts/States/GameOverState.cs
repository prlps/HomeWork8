using Old;
using UnityEngine;

namespace Golf
{
    public class GameOverState : MonoBehaviour
    {
        public void Initialize()
        {
            m_gameStateMachine = GameStateMachine;

            m_gameOverPanel.gameObject.SetActive(false);
        }
        public void Enter()
        {
            m_gameOverPanel.gameObject.SetActive(true);
        }

        public void Exit()
        {
            m_gameOverPanel.gameObject.SetActive(false);
        }

        private void OnClicked() => m_gameStateMachine.Enter<MainMenuState>();
    }
}

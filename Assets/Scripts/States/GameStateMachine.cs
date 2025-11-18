using UnityEngine;

namespace Golf
{
    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] private MainMenuState m_mainMenuState;
        [SerializeField] private GamePlayState m_gameplayState;
        [SerializeField] private GameOverState m_gameOverState;
        public void Enter<T>()
        {

            if (typeof(T) == typeof(MainMenuState))
            {
                m_mainMenuState.Enter();
            }
            if (typeof(T) == typeof(MainMenuState))
            {
               m_mainMenuState.Exit();
                m_mainMenuState.Enter();
            }

            else if (typeof(T) == typeof(GamePlayState))
            {
                m_gameplayState.Exit();
                m_gameplayState.Enter();
            }
            else if (typeof(T) == typeof(GameOverState))
            {
                m_gameplayState.Exit();
                m_gameOverState.Enter();
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class MainMenuState : MonoBehaviour
    {
        [SerializeField] private Button m_playButton;
        [SerializeField] private GameStateMachine m_gameStateMachine;
        [SerializeField] private GameObject m_mainMenuRoot;

        public void Initialize(GameStateMachine gameStateMachine)
        {
            m_gameStateMachine = gameStateMachine;
        }
        public void Enter()
        {
            m_mainMenuRoot.SetActive(true);
            m_playButton.onClick.AddListener(OnClicked);
        }

        public void Exit()
        {
            m_mainMenuRoot.SetActive(false);
            m_playButton.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            m_gameStateMachine.Enter(GameplayState);
        }

        public class GameeplayState
        {
            
        }
    }
}

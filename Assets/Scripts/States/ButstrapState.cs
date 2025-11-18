using UnityEngine;

namespace Golf
{
    public class ButstrapState : MonoBehaviour
    {

        public void Initialize(GameStateMachine gameStateMachine)
        {
            m_levelContorller.enabled = false;
            m_playerController.enabled = false;
            m_gameStateMachine = gameStateMachine;
        }
        public void Enter()
        {

        }

        public void Exit()
        {

        }
    }
}

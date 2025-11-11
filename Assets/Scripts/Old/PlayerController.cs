using UnityEngine;

namespace Old
{


    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private FreeCamera m_camera;
        [SerializeField] private GameObject m_uiPanel;
        [SerializeField] private CloudController m_cloudController;
        [SerializeField] private SwapTools m_swapTools;

        void Update()
        {
            if (m_uiPanel != null && m_uiPanel.activeSelf) return;

            m_camera?.Move();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_cloudController?.MoveNext();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                m_swapTools?.Change();
            }
        }
    }
}
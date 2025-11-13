using UnityEngine;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private StonesSpawner m_stoneSpawner;

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                if (m_stoneSpawner != null)
                    m_stoneSpawner.Spawn();
            }
        }
    }
}

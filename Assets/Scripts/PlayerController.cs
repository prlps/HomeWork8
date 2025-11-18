using UnityEngine;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private StoneSpawner m_stoneSpawner;
        [SerializeField] private Stick m_stick;

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                if (m_stoneSpawner != null)
                    m_stoneSpawner.Spawn();
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                m_stick.Execute();
            }
            else
            {
                m_stick.Up();
            }

        }
    }
}

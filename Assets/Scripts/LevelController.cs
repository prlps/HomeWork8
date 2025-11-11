using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float m_spawnRate;
        [SerializeField] private StonesSpawner m_stoneSpawner;

        private float m_time;

        private void Start()
        {
            m_stoneSpawner.Spawn();
        }
        private void Update()
        {
            m_time += Time.deltaTime;
            if (m_time >= m_spawnRate)
            {
                m_stoneSpawner.Spawn();
                m_time = 0;
            }

           
        }


    }
}

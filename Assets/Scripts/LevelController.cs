using System;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private int m_missedCount;
        [SerializeField][Min(0)] private float m_spawnRate;
        [SerializeField] private StonesSpawner m_stoneSpawner;

        private float m_time;
        private int m_currentMissedCount;

        private void Start()
        {
            if (m_stoneSpawner != null)
                m_stoneSpawner.Spawn();
        }

        private void Awake()
        {
            m_currentMissedCount = 0;
        }

        private void Update()
        {
            m_time += Time.deltaTime;
            if (m_time >= m_spawnRate)
            {
                if (m_stoneSpawner != null)
                {
                    StoneCollosionLog stone = m_stoneSpawner.Spawn();

                    stone.Hit += OnHit;
                    stone.Missed += OnMissed;

                    m_time = 0;
                }
            }
        }
            public void OnHit(StoneCollosionLog stone)
            {   
                throw new NotImplementedException();
            }

            public void OnMissed(StoneCollosionLog stone)
            {
                throw new NotImplementedException();

                

                m_currentMissedCount--;
                if (m_currentMissedCount <= 0)
                {
                    Debug.Log("GameOver");
                }
            }
    }
}

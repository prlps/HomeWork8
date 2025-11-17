using UnityEngine;

namespace Golf
{
    public class StoneSpawner : MonoBehaviour
    {
        [SerializeField] private Stone[] m_prefabs;
        [SerializeField] private Transform m_spawnPoint;

        public Stone Spawn()
        {
            if (m_prefabs == null || m_prefabs.Length == 0) return null;
            if (m_spawnPoint == null) return null;

            var prefab = m_prefabs[Random.Range(0, m_prefabs.Length)];
            return Instantiate(prefab, m_spawnPoint.position, m_spawnPoint.rotation);
        }
    }
}

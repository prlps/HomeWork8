using UnityEngine;

namespace Golf
{
    public class StonesSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] m_prefabs;
        [SerializeField] private Transform m_spawnPoint;

        public void Spawn()
        {
            if (m_prefabs == null || m_prefabs.Length == 0) return;
            if (m_spawnPoint == null) return;

            var prefab = m_prefabs[Random.Range(0, m_prefabs.Length)];
            Instantiate(prefab, m_spawnPoint.position, m_spawnPoint.rotation);
        }
    }
}

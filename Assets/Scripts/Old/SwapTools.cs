using UnityEngine;

public class SwapTools : MonoBehaviour
{
    [Header("Префабы инструментов")]
    [SerializeField] private GameObject[] toolPrefabs; 

    [Header("Текущие инструменты на сцене")]
    [SerializeField] private GameObject[] currentTools;

    public void Change()
    {
        if (toolPrefabs == null || toolPrefabs.Length == 0 || currentTools == null) return;

        for (int i = 0; i < currentTools.Length; i++)
        {
            GameObject currentTool = currentTools[i];
            if (currentTool == null) continue;

            Transform parent = currentTool.transform.parent;
            Vector3 localPos = currentTool.transform.localPosition;
            Quaternion localRot = currentTool.transform.localRotation;

            GameObject newPrefab;
            do
            {
                newPrefab = toolPrefabs[Random.Range(0, toolPrefabs.Length)];
            } while (newPrefab.name == currentTool.name && toolPrefabs.Length > 1);

            Destroy(currentTool);

            GameObject newTool = Instantiate(newPrefab, parent);
            newTool.transform.localPosition = localPos;
            newTool.transform.localRotation = localRot;

            currentTools[i] = newTool;
        }
    }
}

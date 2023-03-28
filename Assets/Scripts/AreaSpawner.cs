using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    public float spawnInterval = 1f;
    public Rect spawningArea;
    public GameObject[] prefabs;


    public void Spawn()
    {
        var prefab = prefabs[Random.Range(0, prefabs.Length)];
        var position = new Vector3(Random.Range(spawningArea.xMin, spawningArea.xMax), Random.Range(spawningArea.yMin, spawningArea.yMax), 0);
        Instantiate(prefab, position, Quaternion.identity);
    }

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, spawnInterval);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(spawningArea.center, spawningArea.size);
    }
}
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn Parameters")]
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 2f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        RandomlyPositionPipes(pipes);
    }

    private void RandomlyPositionPipes(GameObject pipes)
    {
        Vector3 position = pipes.transform.position;
        position.y += Random.Range(minHeight, maxHeight);
        pipes.transform.position = position;
    }
}

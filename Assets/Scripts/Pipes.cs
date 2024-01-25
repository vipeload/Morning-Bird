using UnityEngine;

public class Pipes : MonoBehaviour
{
    public Transform top;
    public Transform bottom;

    public float speed = 10f;

    private float leftEdge;

    private void Start()
    {
        CalculateLeftEdge();
    }

    private void Update()
    {
        MovePipes();
        CheckDestroy();
    }

    private void CalculateLeftEdge()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void MovePipes()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void CheckDestroy()
    {
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}

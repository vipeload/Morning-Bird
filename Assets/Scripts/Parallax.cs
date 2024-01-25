using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Header("Parallax Settings")]
    public float animationSpeed = 33f;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        UpdateParallaxOffset();
    }

    private void UpdateParallaxOffset()
    {
        Vector2 offset = meshRenderer.material.mainTextureOffset;
        offset += new Vector2(animationSpeed * Time.deltaTime, 0);
        meshRenderer.material.mainTextureOffset = offset;
    }
}

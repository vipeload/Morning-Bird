using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Parameters")]
    public float strength = 5f;
    public float gravity = -9.81f;
    public float tilt = 5f;

    [Header("Sprites")]
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private int spriteIndex;

    private Vector3 direction;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        ResetPlayerPosition();
    }

    private void Update()
    {
        HandleInput();
        ApplyGravity();
        ApplyTilt();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ClickSoundManager.Instance.PlayClickSound();
            direction = Vector3.up * strength;
        }
    }

    private void ApplyGravity()
    {
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void ApplyTilt()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
    }

    private void AnimateSprite()
    {
        spriteIndex = (spriteIndex + 1) % sprites.Length;
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void ResetPlayerPosition()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.CompareTag("Scoring"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}

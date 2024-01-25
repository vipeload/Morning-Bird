using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;

    private Player player;
    private Spawner spawner;

    private int score { get; set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        Pause();
    }

    public void Play()
    {
        InitializeGame();
        ClickSoundManager.Instance.PlayClickSound();
    }

    public void GameOver()
    {
        ShowGameOverScreen();
        GameOverSoundManager.Instance.PlayGameOverSound();
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    private void InitializeGame()
    {
        score = 0;
        UpdateScoreText();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        DestroyAllPipes();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    private void ShowGameOverScreen()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);
    }

    private void DestroyAllPipes()
    {
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
}

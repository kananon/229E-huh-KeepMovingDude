using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGameOver : MonoBehaviour
{
    public GameObject gameOverUI;

    public AudioSource bgm;
    public AudioSource sfx;
    public AudioSource gameOverSound;

    private bool isGameOver = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ghost") && !isGameOver)
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        isGameOver = true;

        // 1. เปิด UI
        gameOverUI.SetActive(true);

        // 2. หยุดเสียงทั้งหมด
        if (bgm != null) bgm.Stop();
        if (sfx != null) sfx.Stop();

        // 3. เล่นเสียง Game Over
        if (gameOverSound != null) gameOverSound.Play();

        // 4. หยุดการควบคุมผู้เล่น (ถ้ามี script เดิน)
        GetComponent<PlayerMovement>().enabled = false;

        // 5. หยุดเวลา (แต่ UI ยังทำงานได้)
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void CreditButton()
    {
        SceneManager.LoadScene("Credit");
    }
}
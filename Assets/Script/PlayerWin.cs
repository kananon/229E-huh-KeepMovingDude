using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    public GameObject winUI;

    private bool isWin = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ExitDoor") && !isWin)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        isWin = true;

        // เปิด UI ชนะ
        winUI.SetActive(true);

        // หยุดตัวละคร
        GetComponent<PlayerMovement>().enabled = false;

        // หยุดเวลา (ถ้าอยาก freeze เกม)
        Time.timeScale = 0f;

        Debug.Log("You Win!");
    }
}
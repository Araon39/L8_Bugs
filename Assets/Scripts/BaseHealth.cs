using TMPro;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // ���������� ���������� ��� �������� ���������� ������
    public int lives = 3;

    // ���������� ���������� �������� TMP ��� ����������� ���������� ������
    public TextMeshProUGUI livesText;
    // ������ �� ����� Game Over
    public GameObject gameOverCanvas;

    // ������ ����������� ��� ����������� ������ (��������)
    public GameObject[] heartImages;



    // �����, ������� ���������� ��� ������������ � ��������, ������� ��� "Obstacles" ��� "Enemy"
    private void OnCollisionEnter2D(Collision2D other)
    {
        // ��������, ����� �� ������, � ������� ��������� ������������, ��� "Obstacles" ��� "Enemy"
        if (other.gameObject.CompareTag("Enemy"))
        {
            // ���������� ���������� ������ �� 1
            lives--;

            // ���������� ����������� ������
            UpdateLivesUI();

            // ��������, �� ����� �� ���������� ������ ������ 0
            if (lives <= 0)
            {
                // ����� ������ ��� ���������� ����
                GameOver();
            }
        }
    }

    // ����� ��� ���������� ����������� ������
    void UpdateLivesUI()
    {
        // ���������� ������ � ����������� ������
        livesText.text = "Lives: " + lives;

        // ������� ����������� �������� � ����������� �� �������� ���������� ������
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < lives)
            {
                heartImages[i].SetActive(true);
            }
            else
            {
                heartImages[i].SetActive(false);
            }
        }
    }

    // ����� ��� ���������� ����
    void GameOver()
    {
        // ��������� ����� Game Over
        gameOverCanvas.SetActive(true);
        // ������ ��� ���������� ����
        Debug.Log("Game Over!");
        // ����� �������� �������������� ������, ��������, ��������� ������� ��� ���������� ����������
        Time.timeScale = 0; // ������������� �����
    }
}

using UnityEngine;
using UnityEngine.SceneManagement; // ��� ���������� �������

public class LevelManager : MonoBehaviour
{
    // ���������� ��� ����� � �������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // ���������, ����� �� ���
        {
            SceneManager.LoadScene("Lvl 2"); // ��������� ������ �������
        }
    }
}

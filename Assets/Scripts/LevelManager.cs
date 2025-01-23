using UnityEngine;
using UnityEngine.SceneManagement; // Для управления сценами

public class LevelManager : MonoBehaviour
{
    // Вызывается при входе в триггер
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Проверяем, игрок ли это
        {
            SceneManager.LoadScene("Lvl 2"); // Загружаем второй уровень
        }
    }
}

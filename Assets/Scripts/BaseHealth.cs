using TMPro;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // Объявление переменной для хранения количества жизней
    public int lives = 3;

    // Объявление текстового элемента TMP для отображения количества жизней
    public TextMeshProUGUI livesText;
    // Ссылка на канву Game Over
    public GameObject gameOverCanvas;

    // Массив изображений для отображения жизней (сердечек)
    public GameObject[] heartImages;



    // Метод, который вызывается при столкновении с объектом, имеющим тег "Obstacles" или "Enemy"
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Проверка, имеет ли объект, с которым произошло столкновение, тег "Obstacles" или "Enemy"
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Уменьшение количества жизней на 1
            lives--;

            // Обновление отображения жизней
            UpdateLivesUI();

            // Проверка, не стало ли количество жизней равным 0
            if (lives <= 0)
            {
                // Вызов метода для завершения игры
                GameOver();
            }
        }
    }

    // Метод для обновления отображения жизней
    void UpdateLivesUI()
    {
        // Обновление текста с количеством жизней
        livesText.text = "Lives: " + lives;

        // Скрытие изображений сердечек в зависимости от текущего количества жизней
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

    // Метод для завершения игры
    void GameOver()
    {
        // Активация канвы Game Over
        gameOverCanvas.SetActive(true);
        // Логика для завершения игры
        Debug.Log("Game Over!");
        // Можно добавить дополнительную логику, например, остановку времени или отключение управления
        Time.timeScale = 0; // Останавливаем время
    }
}

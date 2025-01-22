using UnityEngine;
using TMPro; // Подключаем пространство имен TextMeshPro

public class CoinCollector : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Ссылка на текстовый объект TMP для отображения количества монет
    private int coinCount = 0; // Переменная для хранения количества собранных монет

    private void Start()
    {
        // Убедитесь, что текстовый объект назначен
        if (coinText == null)
        {
            Debug.LogError("CoinText is not assigned!");
        }
        else
        {
            UpdateCoinText(); // Обновляем текст при старте
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, имеет ли объект, с которым произошло столкновение, тег "Coin"
        if (collision.gameObject.CompareTag("Coin"))
        {
            // Увеличиваем количество монет
            coinCount++;
            // Обновляем текст
            UpdateCoinText();
            // Уничтожаем монету
            Destroy(collision.gameObject);
        }
    }

    private void UpdateCoinText()
    {
        // Обновляем текст на экране
        coinText.text = "Coins: " + coinCount;
    }
}

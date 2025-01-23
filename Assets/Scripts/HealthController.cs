using UnityEngine;
using UnityEngine.UI; // Импортируем пространство имен для работы с UI

public class HealthController : MonoBehaviour
{
    public Slider slider; // Ссылка на UI-компонент Slider
    public GameObject gameOverCanvas; // Ссылка на Canvas для экрана конца игры
    private static float sliderValue = 10; // Начальное значение слайдера
    private float maxHealth = 10;

    void Start()
    {
        slider.value = sliderValue; // Устанавливаем начальное значение слайдера
        gameOverCanvas.SetActive(false); // Убедимся, что экран конца игры отключен
    }

    // Update is called once per frame
    void Update()
    {
        // Проверяем, достигло ли значение слайдера нуля
        if (slider.value <= 0)
        {
            // Активируем экран конца игры
            gameOverCanvas.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, столкнулись ли мы с объектом с тегом "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            slider.value -= 1; // Уменьшаем значение слайдера на 1
            sliderValue = slider.value; // Обновляем значение sliderValue
        }

        if (collision.gameObject.CompareTag("Medicine"))
        {
            // Устанавливаем значение слайдера на максимальное значение здоровья
            slider.value = maxHealth;

            // Обновляем значение слайдера, чтобы отобразить изменения
            sliderValue = slider.value;

            // Уничтожаем объект, с которым произошло столкновение (например, медицинский предмет)
            Destroy(collision.gameObject);
        }

    }
}

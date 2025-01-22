using UnityEngine;
using UnityEngine.UI; // Импортируем пространство имен для работы с UI

public class HealthController : MonoBehaviour
{
    public Slider slider; // Ссылка на UI-компонент Slider
    private static float sliderValue = 10; // Начальное значение слайдера

    void Start()
    {
        slider.value = sliderValue; // Устанавливаем начальное значение слайдера
    }

    // Update is called once per frame
    void Update()
    {
        // Этот метод вызывается каждый кадр, но в данном случае он пустой
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, столкнулись ли мы с объектом с тегом "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            slider.value -= 1; // Уменьшаем значение слайдера на 1
            sliderValue = slider.value; // Обновляем значение sliderValue
        }
    }
}

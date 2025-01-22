using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class Boss : MonoBehaviour
{
    public float speed = 0.1f;
    public Vector3[] positions;
    public Slider slider;

    private int indexPosition;
    private SpriteRenderer sprite; // Объявляем переменную для Sprite

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // Получаем компонент SpriteRenderer при старте
    }

    void Update()
    {
        // Перемещаем объект к следующей позиции
        transform.position = Vector3.MoveTowards(transform.position, positions[indexPosition], speed);

        // Проверяем, достиг ли объект текущей позиции
        if (transform.position == positions[indexPosition])
        {
            // Если это не последняя позиция, переходим к следующей
            if (indexPosition < positions.Length - 1)
            {
                indexPosition++;
                sprite.flipX = false; // Отключаем зеркальное отображение спрайта
            }
            else
            {
                indexPosition = 0; // Возвращаемся к начальной позиции
                sprite.flipX = true; // Включаем зеркальное отображение спрайта
            }

            // Проверяем значение слайдера
            if (slider.value == 0)
            {
                Destroy(gameObject); // Уничтожаем объект, если значение слайдера равно 0
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, столкнулись ли мы с объектом с тегом "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            slider.value -= 1; // Уменьшаем значение слайдера на 1
        }
    }
}

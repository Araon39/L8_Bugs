using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class Boss : MonoBehaviour
{
    public float speed = 0.1f; // Скорость передвижения объекта
    public Vector3[] positions; // Массив позиций для патрулирования
    public Slider slider; // Слайдер, представляющий здоровье объекта
    
    private int indexPosition; // Индекс текущей позиции в массиве positions
    private SpriteRenderer sprite; // Компонент SpriteRenderer для управления спрайтом
    
    public Transform enemyBase; // Целевая позиция (база врага)

    private void Start()
    {
        // Получаем компонент SpriteRenderer при старте
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Если здоровье объекта равно 0, уничтожаем его
        if (slider.value == 0)
        {
            Destroy(gameObject);
        }
        // Если здоровье объекта равно 1, двигаем его к базе врага
        else if (slider.value == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyBase.position, speed);
        }
        // Если здоровье объекта больше 1, двигаем его по заданным позициям
        else if (slider.value > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[indexPosition], speed);

            // Если объект достиг текущей позиции
            if (transform.position == positions[indexPosition])
            {
                // Если это не последняя позиция, переходим к следующей и отключаем зеркальное отображение спрайта
                if (indexPosition < positions.Length - 1)
                {
                    indexPosition++;
                    sprite.flipX = false;
                }
                // Если это последняя позиция, возвращаемся к первой и включаем зеркальное отображение спрайта
                else
                {
                    indexPosition = 0;
                    sprite.flipX = true;
                }
            }
        }
    }

    // Обработка столкновения с другим объектом
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Если столкнулись с объектом с тегом "Player", уменьшаем здоровье объекта
        if (collision.gameObject.CompareTag("Player"))
        {
            slider.value -= 1;
        }
    }

    // Обработка столкновения с другим объектом
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Если столкнулись с объектом с тегом "EnemyBase", устанавливаем здоровье объекта на 3
        if (collision.gameObject.CompareTag("EnemyBase"))
        {
            slider.value = 3;
        }
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    public Vector3[] positions;
    private int indexPosition;
    private SpriteRenderer spriteRenderer; // Объявляем переменную для SpriteRenderer

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Получаем компонент SpriteRenderer
    }

    void Update()
    {
        // Перемещаем объект к позиции, указанной в массиве positions с текущим индексом indexPosition, с заданной скоростью speed
        transform.position = Vector3.MoveTowards(transform.position, positions[indexPosition], speed);

        // Проверяем, достиг ли объект текущей позиции
        if (transform.position == positions[indexPosition])
        {
            // Если текущий индекс меньше длины массива positions минус один, увеличиваем индекс
            if (indexPosition < positions.Length - 1)
            {
                indexPosition++;
            }
            else // Иначе, сбрасываем индекс в 0, чтобы начать с начала
            {
                indexPosition = 0;
            }
        }

        // Проверяем направление движения и отражаем спрайт по горизонтали, если движемся влево
        if (transform.position.x < positions[indexPosition].x)
        {
            spriteRenderer.flipX = false; // Отражаем спрайт по горизонтали
        }
        else
        {
            spriteRenderer.flipX = true; // Возвращаем спрайт в исходное состояние
        }
    }

    // Метод OnCollisionEnter2D вызывается, когда этот коллайдер/триггер вначале касается другого объекта
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, имеет ли объект, с которым произошло столкновение, тег "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Загружаем сцену с индексом текущей активной сцены
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Метод OnTriggerEnter2D вызывается, когда другой коллайдер вначале касается триггера
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, имеет ли объект, с которым произошло столкновение, тег "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Уничтожаем объект, с которым произошло столкновение
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс PlayerController наследуется от MonoBehaviour, что позволяет использовать его в Unity
public class PlayerController : MonoBehaviour
{
    // Переменная для хранения скорости персонажа
    private int speed = 10;

    // Переменная для хранения силы прыжка
    private int force = 5;

    // Переменная для хранения компонента SpriteRenderer, который отвечает за отображение спрайта
    private SpriteRenderer sprite;

    // Переменная для хранения компонента Rigidbody2D, который отвечает за физику объекта
    private Rigidbody2D rb;

    // Метод Start вызывается перед первым обновлением кадра
    void Start()
    {
        // Получаем компонент SpriteRenderer с текущего GameObject и сохраняем его в переменной sprite
        sprite = GetComponent<SpriteRenderer>();

        // Получаем компонент Rigidbody2D с текущего GameObject и сохраняем его в переменной rb
        rb = GetComponent<Rigidbody2D>();
    }

    // Метод Update вызывается один раз за кадр
    void Update()
    {
        // Получаем горизонтальное значение от клавиатуры или джойстика
        float horizontal = Input.GetAxis("Horizontal");

        // Перемещаем персонажа в горизонтальном направлении
        // Vector2.right - вектор, направленный вправо
        // Time.deltaTime - время, прошедшее с последнего кадра, используется для плавного перемещения
        // speed - скорость перемещения
        // horizontal - направление перемещения (-1 для движения влево, 1 для движения вправо)
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontal);

        // Если персонаж движется влево (horizontal < 0), то переворачиваем спрайт по оси X
        sprite.flipX = horizontal < 0;

        // Проверяем, нажата ли клавиша пробела (Space)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Применяем силу к Rigidbody2D вверх, чтобы персонаж прыгнул
            // Vector2.up - вектор, направленный вверх
            // force - сила прыжка
            // ForceMode2D.Impulse - тип применения силы (мгновенный импульс)
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}

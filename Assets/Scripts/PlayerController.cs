using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    public float speed = 10f;       // Скорость персонажа  
    public float jumpForce = 5f;    // Сила прыжка   
    private bool isGrounded = true; // Флаг для проверки, находится ли игрок на земле   
    private Rigidbody2D rb;         // Компонент Rigidbody2D    
    private Animator animator;      // Компонент Animator для управления анимациями

    void Start()
    {
        // Получаем компоненты Rigidbody2D и Animator
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Получаем горизонтальное значение от ввода
        float horizontal = Input.GetAxis("Horizontal");

        // Двигаем персонажа
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontal);

        // Если игрок движется, включаем анимацию бега
        if (horizontal != 0)
        {
            animator.SetBool("Walking", true);
            // Поворачиваем котика в сторону движения
            transform.localScale = new Vector3(Mathf.Sign(horizontal), 1, 1);
        }
        else
        {
            // Останавливаем анимацию бега, если игрок стоит на месте
            animator.SetBool("Walking", false);
        }

        // Если нажата клавиша пробела и персонаж на земле, то прыгаем
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // Устанавливаем флаг, что персонаж в воздухе
            animator.SetTrigger("Jump"); // Запускаем анимацию прыжка
        }
    }

    // Проверяем, коснулся ли персонаж земли
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Персонаж снова на земле
        }
    }
}

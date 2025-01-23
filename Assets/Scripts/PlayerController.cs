using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    public float speed = 10f;       // �������� ���������  
    public float jumpForce = 5f;    // ���� ������   
    private bool isGrounded = true; // ���� ��� ��������, ��������� �� ����� �� �����   
    private Rigidbody2D rb;         // ��������� Rigidbody2D    
    private Animator animator;      // ��������� Animator ��� ���������� ����������

    void Start()
    {
        // �������� ���������� Rigidbody2D � Animator
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // �������� �������������� �������� �� �����
        float horizontal = Input.GetAxis("Horizontal");

        // ������� ���������
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontal);

        // ���� ����� ��������, �������� �������� ����
        if (horizontal != 0)
        {
            animator.SetBool("Walking", true);
            // ������������ ������ � ������� ��������
            transform.localScale = new Vector3(Mathf.Sign(horizontal), 1, 1);
        }
        else
        {
            // ������������� �������� ����, ���� ����� ����� �� �����
            animator.SetBool("Walking", false);
        }

        // ���� ������ ������� ������� � �������� �� �����, �� �������
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // ������������� ����, ��� �������� � �������
            animator.SetTrigger("Jump"); // ��������� �������� ������
        }
    }

    // ���������, �������� �� �������� �����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // �������� ����� �� �����
        }
    }
}

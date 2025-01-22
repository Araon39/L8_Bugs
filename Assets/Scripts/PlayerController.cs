using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� PlayerController ����������� �� MonoBehaviour, ��� ��������� ������������ ��� � Unity
public class PlayerController : MonoBehaviour
{
    // ���������� ��� �������� �������� ���������
    private int speed = 10;

    // ���������� ��� �������� ���� ������
    private int force = 5;

    // ���������� ��� �������� ���������� SpriteRenderer, ������� �������� �� ����������� �������
    private SpriteRenderer sprite;

    // ���������� ��� �������� ���������� Rigidbody2D, ������� �������� �� ������ �������
    private Rigidbody2D rb;

    // ����� Start ���������� ����� ������ ����������� �����
    void Start()
    {
        // �������� ��������� SpriteRenderer � �������� GameObject � ��������� ��� � ���������� sprite
        sprite = GetComponent<SpriteRenderer>();

        // �������� ��������� Rigidbody2D � �������� GameObject � ��������� ��� � ���������� rb
        rb = GetComponent<Rigidbody2D>();
    }

    // ����� Update ���������� ���� ��� �� ����
    void Update()
    {
        // �������� �������������� �������� �� ���������� ��� ���������
        float horizontal = Input.GetAxis("Horizontal");

        // ���������� ��������� � �������������� �����������
        // Vector2.right - ������, ������������ ������
        // Time.deltaTime - �����, ��������� � ���������� �����, ������������ ��� �������� �����������
        // speed - �������� �����������
        // horizontal - ����������� ����������� (-1 ��� �������� �����, 1 ��� �������� ������)
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontal);

        // ���� �������� �������� ����� (horizontal < 0), �� �������������� ������ �� ��� X
        sprite.flipX = horizontal < 0;

        // ���������, ������ �� ������� ������� (Space)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ��������� ���� � Rigidbody2D �����, ����� �������� �������
            // Vector2.up - ������, ������������ �����
            // force - ���� ������
            // ForceMode2D.Impulse - ��� ���������� ���� (���������� �������)
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class Boss : MonoBehaviour
{
    public float speed = 0.1f; // �������� ������������ �������
    public Vector3[] positions; // ������ ������� ��� ��������������
    public Slider slider; // �������, �������������� �������� �������
    
    private int indexPosition; // ������ ������� ������� � ������� positions
    private SpriteRenderer sprite; // ��������� SpriteRenderer ��� ���������� ��������
    
    public Transform enemyBase; // ������� ������� (���� �����)

    private void Start()
    {
        // �������� ��������� SpriteRenderer ��� ������
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // ���� �������� ������� ����� 0, ���������� ���
        if (slider.value == 0)
        {
            Destroy(gameObject);
        }
        // ���� �������� ������� ����� 1, ������� ��� � ���� �����
        else if (slider.value == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyBase.position, speed);
        }
        // ���� �������� ������� ������ 1, ������� ��� �� �������� ��������
        else if (slider.value > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[indexPosition], speed);

            // ���� ������ ������ ������� �������
            if (transform.position == positions[indexPosition])
            {
                // ���� ��� �� ��������� �������, ��������� � ��������� � ��������� ���������� ����������� �������
                if (indexPosition < positions.Length - 1)
                {
                    indexPosition++;
                    sprite.flipX = false;
                }
                // ���� ��� ��������� �������, ������������ � ������ � �������� ���������� ����������� �������
                else
                {
                    indexPosition = 0;
                    sprite.flipX = true;
                }
            }
        }
    }

    // ��������� ������������ � ������ ��������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ����������� � �������� � ����� "Player", ��������� �������� �������
        if (collision.gameObject.CompareTag("Player"))
        {
            slider.value -= 1;
        }
    }

    // ��������� ������������ � ������ ��������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� ����������� � �������� � ����� "EnemyBase", ������������� �������� ������� �� 3
        if (collision.gameObject.CompareTag("EnemyBase"))
        {
            slider.value = 3;
        }
    }

}

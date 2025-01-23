using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    public Vector3[] positions;
    private int indexPosition;
    private SpriteRenderer spriteRenderer; // ��������� ���������� ��� SpriteRenderer

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // �������� ��������� SpriteRenderer
    }

    void Update()
    {
        // ���������� ������ � �������, ��������� � ������� positions � ������� �������� indexPosition, � �������� ��������� speed
        transform.position = Vector3.MoveTowards(transform.position, positions[indexPosition], speed);

        // ���������, ������ �� ������ ������� �������
        if (transform.position == positions[indexPosition])
        {
            // ���� ������� ������ ������ ����� ������� positions ����� ����, ����������� ������
            if (indexPosition < positions.Length - 1)
            {
                indexPosition++;
            }
            else // �����, ���������� ������ � 0, ����� ������ � ������
            {
                indexPosition = 0;
            }
        }

        // ��������� ����������� �������� � �������� ������ �� �����������, ���� �������� �����
        if (transform.position.x < positions[indexPosition].x)
        {
            spriteRenderer.flipX = false; // �������� ������ �� �����������
        }
        else
        {
            spriteRenderer.flipX = true; // ���������� ������ � �������� ���������
        }
    }

    // ����� OnCollisionEnter2D ����������, ����� ���� ���������/������� ������� �������� ������� �������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������, ����� �� ������, � ������� ��������� ������������, ��� "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // ��������� ����� � �������� ������� �������� �����
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // ����� OnTriggerEnter2D ����������, ����� ������ ��������� ������� �������� ��������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������, ����� �� ������, � ������� ��������� ������������, ��� "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // ���������� ������, � ������� ��������� ������������
            Destroy(gameObject);
        }
    }
}

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
    private SpriteRenderer sprite; // ��������� ���������� ��� Sprite

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // �������� ��������� SpriteRenderer ��� ������
    }

    void Update()
    {
        // ���������� ������ � ��������� �������
        transform.position = Vector3.MoveTowards(transform.position, positions[indexPosition], speed);

        // ���������, ������ �� ������ ������� �������
        if (transform.position == positions[indexPosition])
        {
            // ���� ��� �� ��������� �������, ��������� � ���������
            if (indexPosition < positions.Length - 1)
            {
                indexPosition++;
                sprite.flipX = false; // ��������� ���������� ����������� �������
            }
            else
            {
                indexPosition = 0; // ������������ � ��������� �������
                sprite.flipX = true; // �������� ���������� ����������� �������
            }

            // ��������� �������� ��������
            if (slider.value == 0)
            {
                Destroy(gameObject); // ���������� ������, ���� �������� �������� ����� 0
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������, ����������� �� �� � �������� � ����� "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            slider.value -= 1; // ��������� �������� �������� �� 1
        }
    }
}

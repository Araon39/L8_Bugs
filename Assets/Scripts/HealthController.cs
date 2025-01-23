using UnityEngine;
using UnityEngine.UI; // ����������� ������������ ���� ��� ������ � UI

public class HealthController : MonoBehaviour
{
    public Slider slider; // ������ �� UI-��������� Slider
    public GameObject gameOverCanvas; // ������ �� Canvas ��� ������ ����� ����
    private static float sliderValue = 10; // ��������� �������� ��������
    private float maxHealth = 10;

    void Start()
    {
        slider.value = sliderValue; // ������������� ��������� �������� ��������
        gameOverCanvas.SetActive(false); // ��������, ��� ����� ����� ���� ��������
    }

    // Update is called once per frame
    void Update()
    {
        // ���������, �������� �� �������� �������� ����
        if (slider.value <= 0)
        {
            // ���������� ����� ����� ����
            gameOverCanvas.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������, ����������� �� �� � �������� � ����� "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            slider.value -= 1; // ��������� �������� �������� �� 1
            sliderValue = slider.value; // ��������� �������� sliderValue
        }

        if (collision.gameObject.CompareTag("Medicine"))
        {
            // ������������� �������� �������� �� ������������ �������� ��������
            slider.value = maxHealth;

            // ��������� �������� ��������, ����� ���������� ���������
            sliderValue = slider.value;

            // ���������� ������, � ������� ��������� ������������ (��������, ����������� �������)
            Destroy(collision.gameObject);
        }

    }
}

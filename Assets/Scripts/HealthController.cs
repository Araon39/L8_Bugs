using UnityEngine;
using UnityEngine.UI; // ����������� ������������ ���� ��� ������ � UI

public class HealthController : MonoBehaviour
{
    public Slider slider; // ������ �� UI-��������� Slider
    private static float sliderValue = 10; // ��������� �������� ��������

    void Start()
    {
        slider.value = sliderValue; // ������������� ��������� �������� ��������
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ����� ���������� ������ ����, �� � ������ ������ �� ������
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������, ����������� �� �� � �������� � ����� "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            slider.value -= 1; // ��������� �������� �������� �� 1
            sliderValue = slider.value; // ��������� �������� sliderValue
        }
    }
}

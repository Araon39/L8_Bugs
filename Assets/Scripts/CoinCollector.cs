using UnityEngine;
using TMPro; // ���������� ������������ ���� TextMeshPro

public class CoinCollector : MonoBehaviour
{
    public TextMeshProUGUI coinText; // ������ �� ��������� ������ TMP ��� ����������� ���������� �����
    private int coinCount = 0; // ���������� ��� �������� ���������� ��������� �����

    private void Start()
    {
        // ���������, ��� ��������� ������ ��������
        if (coinText == null)
        {
            Debug.LogError("CoinText is not assigned!");
        }
        else
        {
            UpdateCoinText(); // ��������� ����� ��� ������
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������, ����� �� ������, � ������� ��������� ������������, ��� "Coin"
        if (collision.gameObject.CompareTag("Coin"))
        {
            // ����������� ���������� �����
            coinCount++;
            // ��������� �����
            UpdateCoinText();
            // ���������� ������
            Destroy(collision.gameObject);
        }
    }

    private void UpdateCoinText()
    {
        // ��������� ����� �� ������
        coinText.text = "Coins: " + coinCount;
    }
}

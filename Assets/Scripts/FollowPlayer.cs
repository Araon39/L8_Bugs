using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� FollowPlayer ����������� �� MonoBehaviour, ��� ��������� ������������ ��� � Unity
public class FollowPlayer : MonoBehaviour
{
    // ��������� ���������� ��� �������� ������������� ������
    private Transform player;

    // ����� Start ���������� ����� ������ ����������� �����
    void Start()
    {
        // ������� GameObject � ������ "Player" � ��������� ��� ������������� � ���������� player
        player = GameObject.Find("Player").transform;
    }

    // ����� Update ���������� ���� ��� �� ����
    void Update()
    {
        // ��������� ������� �������� �������, ����� ��� ��������� � �������� ������
        // Vector3(player.position.x, transform.position.y, transform.position.z) - ������� ����� ������,
        // ��� ���������� x ������� �� ������� ������, � y � z �������� �� �������� �������
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}

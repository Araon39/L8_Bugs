using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс FollowPlayer наследуется от MonoBehaviour, что позволяет использовать его в Unity
public class FollowPlayer : MonoBehaviour
{
    // Приватная переменная для хранения трансформации игрока
    private Transform player;

    // Метод Start вызывается перед первым обновлением кадра
    void Start()
    {
        // Находим GameObject с именем "Player" и сохраняем его трансформацию в переменной player
        player = GameObject.Find("Player").transform;
    }

    // Метод Update вызывается один раз за кадр
    void Update()
    {
        // Обновляем позицию текущего объекта, чтобы она совпадала с позицией игрока
        // Vector3(player.position.x, transform.position.y, transform.position.z) - создаем новый вектор,
        // где координата x берется от позиции игрока, а y и z остаются от текущего объекта
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}

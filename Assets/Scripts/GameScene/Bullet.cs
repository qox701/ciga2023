using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;  // �ӵ������ٶ�

    private void Update()
    {
        // ���ӵ���ǰ������
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

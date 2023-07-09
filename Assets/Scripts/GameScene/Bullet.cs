using System;
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

    private void OnCollisionEnter(Collision collision)
    {
        Destroyable destroyable = collision.gameObject.GetComponent<Destroyable>();
        if (destroyable != null)
        {
            destroyable.DestroyThis();
            Destroy(this.gameObject);
        }
    }
}

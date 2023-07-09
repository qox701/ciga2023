using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;  // 子弹飞行速度

    private void Update()
    {
        // 让子弹朝前方飞行
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

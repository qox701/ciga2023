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
}

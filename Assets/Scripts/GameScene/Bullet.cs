using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;  // �ӵ������ٶ�
    public GameObject BoomEff;
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
            Instantiate(BoomEff, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else
        {
            Invoke("DestroyThis",3f);
        }
    }

    private void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}

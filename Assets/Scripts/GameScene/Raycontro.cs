using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Raycontro : MonoBehaviour
{
    //射线检测到的物体tag
    public static string hitthing;
    // 子弹预制体
    public GameObject bulletPrefab;  
    //定义射线基本数值
    public float maxDistance = 100f;
    public float speed = 5f;
    
    //射线可视化内容，射线和瞄准点
    private GameObject sphereObject;
    private LineRenderer lineRenderer;
    //获取基地的摄像头，注意命名
    private GameObject baseCamera;

    //初始向量和终点向量
    private Vector3 direction;
    private Vector3 targetDirection;

    //定义结构体
    private enum MoveDir
    {
        up,
        down,
        right,
        left,
    }

    private bool isRotating = false;
    private MoveDir moveDir;


    private void Start()
    {
        //获取基地的摄像头
        baseCamera = GameObject.Find("baseCamera");
        sphereObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphereObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        sphereObject.GetComponent<MeshRenderer>().material.color = Color.red;
        sphereObject.GetComponent<Collider>().enabled = false;
        
        //LineRenderer基础绘制
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        //射线方向
        direction = this.transform.forward;
        targetDirection = direction;

        //射线移动事件
        EventCenter.GetInstance().AddEventListener("RayUp", RayUp);
        EventCenter.GetInstance().AddEventListener("RayDown", RayDown);
        EventCenter.GetInstance().AddEventListener("RayLeft", RayLeft);
        EventCenter.GetInstance().AddEventListener("RayRight", RayRight);
        EventCenter.GetInstance().AddEventListener("RayStop", RayStop);
        //发射导弹事件
        EventCenter.GetInstance().AddEventListener("Fire", Fire);
    }

    private void Update()
    {
        //Debug.Log(hitthing);
        targetDirection = direction;
        if (isRotating)
        {
            switch (moveDir)
            {
                case MoveDir.up:
                    targetDirection = Vector3.up;
                    break;
                case MoveDir.down:
                    targetDirection = Vector3.down;
                    break;
                case MoveDir.left:
                    targetDirection = Vector3.left;
                    break;
                case MoveDir.right:
                    targetDirection = Vector3.right;
                    break;
            }
            //插值到起点向量到终点向量的变化
            float rotatespeed = Time.deltaTime * speed;
            Debug.Log(rotatespeed);
            direction = Vector3.Slerp(direction, targetDirection, rotatespeed);
        }
        else
        {
            direction = targetDirection;
        }

        //以摄像头为起点创建射线
        Ray ray = new Ray(baseCamera.transform.position, direction);

        //射线可视化
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            sphereObject.transform.position = hit.point;
            sphereObject.SetActive(true);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
            lineRenderer.enabled = true;
            //获取碰撞物体的标签
            hitthing = hit.collider.tag;
        }
        else
        {
            sphereObject.SetActive(false);
            lineRenderer.enabled = false;
        }
    }

    private void RayUp()
    {
        isRotating = true;
        moveDir = MoveDir.up;
    }

    private void RayDown()
    {
        isRotating = true;
        moveDir = MoveDir.down;
    }
    private void RayLeft()
    {
        isRotating = true;
        moveDir = MoveDir.left;
    }
    private void RayRight()
    {
        isRotating = true;
        moveDir = MoveDir.right;
    }

    private void RayStop()
    {
        isRotating = false;
    }
    private void Fire()
    {
        Debug.Log("Fire");
        // 生成子弹预制体
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        // 设置子弹方向
        bullet.transform.forward = direction.normalized;
    }
}

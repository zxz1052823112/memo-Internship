using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzleTransform;

    public Camera cam;

    private Vector3 mousePos;
    private Vector2 gunDirection;

    // Update is called once per frame
    void Update()
    {
        // 获取鼠标在世界空间中的位置
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));

        // 计算从枪到鼠标的方向
        gunDirection = (mousePos - transform.position).normalized;

        // 计算角度
        float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;

        // 设置枪的旋转
        transform.eulerAngles = new Vector3(0, 0, angle);

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("鼠标左键以按下");
            Instantiate(bullet, muzzleTransform.position, Quaternion.Euler(transform.eulerAngles));
        }
    }
}

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
        // ��ȡ���������ռ��е�λ��
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));

        // �����ǹ�����ķ���
        gunDirection = (mousePos - transform.position).normalized;

        // ����Ƕ�
        float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;

        // ����ǹ����ת
        transform.eulerAngles = new Vector3(0, 0, angle);

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("�������԰���");
            Instantiate(bullet, muzzleTransform.position, Quaternion.Euler(transform.eulerAngles));
        }
    }
}

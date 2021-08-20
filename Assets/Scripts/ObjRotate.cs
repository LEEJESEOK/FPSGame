using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotate : MonoBehaviour
{
    // 마우스의 회전 누적치 저장할 변수
    float mx, my;

    // 회전 속력
    float rotSpeed = 150;

    // 회전 가능 여부
    public bool canRotateH, canRotateV;

    // Start is called before the first frame update
    void Start()
    {
        mx = transform.localEulerAngles.x;
        my = transform.localEulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스의 움직임을 받아서
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y") * (-1);

        // 마우스의 회전값으로 각도를 누적하고
        if (canRotateH == true)
            mx += v * rotSpeed * Time.deltaTime;
        if (canRotateV == true)
            my += h * rotSpeed * Time.deltaTime;

        // // 만약에 mx의 값이 -60보다 작으면 -60
        // // 만약에 mx의 값이 60보다 크면 60
        // if (mx < -60)
        //     mx = -60;
        // if (mx > 60)
        //     mx = 60;

        mx = Mathf.Clamp(mx, -60, 60);

        // 누적된 회전값으로 게임 오브젝트의 각도를 세팅하자
        transform.localEulerAngles = new Vector3(mx, my, 0);
    }
}

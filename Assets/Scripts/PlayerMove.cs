using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 3f;
    CharacterController characterController;

    // 점프 파워
    public float jumpPower = 1f;
    // y속도
    float velocityY;
    // 중력
    float gravity = -20;

    int jumpCnt = 0;
    public int maxJumpCnt = 2;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = (transform.right * x + transform.forward * z);
        // Move();
        // transform.position += moveVector;

        Jump(out dir.y);


        characterController.Move(dir * moveSpeed * Time.deltaTime);
    }

    void Jump(out float dirY)
    {
        if (characterController.isGrounded == true)
        {
            velocityY = 0;
            jumpCnt = 0;
        }
        if (Input.GetButtonDown("Jump") && jumpCnt < maxJumpCnt)
        {
            velocityY = jumpPower;
            jumpCnt++;
        }
        dirY = velocityY;
        velocityY += gravity * Time.deltaTime;
    }
}

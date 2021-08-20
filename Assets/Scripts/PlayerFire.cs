using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePos;

    private float currTime = 0;
    public float fireTime = 1f;

    // public GameObject fragmentFactory;
    public GameObject fragmentEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;

        if (Input.GetButton("Fire1") && currTime > fireTime)
        {
            CreateBullet();
            currTime = 0;
        }

        // Fire2 입력
        // 카메라위치, 카메라 앞방향으로 발사하는 Ray
        // Ray가 어딘가에 부딪히면
        // 맞은 위치에 파편효과
        else if (Input.GetButton("Fire2"))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            int layerObstacle = 1 << LayerMask.NameToLayer("Obstacle");
            int layerWall = 1 << LayerMask.NameToLayer("Wall");
            int layer = layerObstacle | layerWall;

            if (Physics.Raycast(ray, out hit, 100, layer))
            {
                // // 파편효과 생성
                // GameObject fragment = Instantiate(fragmentFactory);
                // // 효과를 맞은 위치로 이동
                // fragment.transform.position = hit.point;
                // // 효과에서 ParticleSystem 컴포넌트
                // ParticleSystem ps = fragment.GetComponent<ParticleSystem>();
                // // 컴포넌트에서 Play 실행
                // ps.Play();


                fragmentEffect.transform.position = hit.point;
                //효과의 앞방향을 부딪힌 면의 수직 벡터로 한다
                fragmentEffect.transform.forward = hit.normal;
                // 효과에서 ParticleSystem 컴포넌트
                ParticleSystem particleSystem = fragmentEffect.GetComponent<ParticleSystem>();
                // 컴포넌트에서 Play 실행
                particleSystem.Play();
            }
                AudioSource audioSource = fragmentEffect.GetComponent<AudioSource>();
                audioSource.Play();
        }
    }

    void CreateBullet()
    {
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.position = firePos.transform.position;
        bullet.transform.eulerAngles = transform.eulerAngles;
        bullet.transform.eulerAngles += new Vector3(90, 0, 0);
    }
}

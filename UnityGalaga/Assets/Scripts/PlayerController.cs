using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager = default;
    public GameObject bulletPrefab = default;
    public Transform target = default;
    public Rigidbody playerRigidbody = default;
    public Vector3 bulletPosition = default;
    public float speed = 300f;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        gameManager = new GameManager();
    }

    // Update is called once per frame
    void Update()
    {
        float input_X = Input.GetAxis("Horizontal");
        float input_Z = Input.GetAxis("Vertical");

        float speed_X = speed * input_X;
        float speed_Z = speed * input_Z;

        // 스페이스바 입력(총알 발사)
        if (Input.GetKey(KeyCode.Space) == true)
        {
            Shoot();
        }
        Vector3 newVelocity = new Vector3(speed_X, 0f, speed_Z);
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        gameObject.SetActive(false);
        //gameManager.EndGame(); 오류로 포기
    }

    // 총알 발사
    public void Shoot()
    {
        // PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 지정
        //target = FindObjectOfType<Enemy>().transform;

        //waitTime = 0;
        //transform.LookAt(target);
        bulletPosition = new Vector3(transform.position.x, transform.position.y,
    transform.position.z + 10);

        GameObject bullet = Instantiate(bulletPrefab,
            bulletPosition, transform.rotation);
    }

    public void Damaged()
    {
        Vector3 targetPosition = new Vector3(0,11,-700);
        transform.position = targetPosition;
    }
}

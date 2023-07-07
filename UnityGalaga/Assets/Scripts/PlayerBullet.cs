using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
 
    public float speed = default;
    private Rigidbody rigid = default;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        rigid.velocity = transform.forward * speed;

        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대가 '적' 일 경우
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.gameObject.SetActive(false);
                GameManager.score++;
            }
        }

        // 충돌한 상대가 '총알' 일 경우
        else if (other.tag == "EnemyBullet")
        {
            EnemyBullet enemyBullet = other.GetComponent<EnemyBullet>();
            if (enemyBullet != null)
            {
                enemyBullet.gameObject.SetActive(false);
                GameManager.score++;
            }
        }
    }
}

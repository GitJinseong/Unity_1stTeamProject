using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = default;
    private Rigidbody rigid = default;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        rigid.velocity = -transform.forward * speed;

        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대가 '플레이어' 일 경우
        if (other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Die();
                //player.Damaged();
            }
        }
    }
}

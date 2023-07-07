using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 50f;
    public float bulletRateTime = 1f;
    public float timeAfterSpawn = default; 
    public Rigidbody rigid = default;
    public GameObject bulletPrefab = default;
    Quaternion bulletRotation = Quaternion.Euler(0, 0, -90);

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = -transform.forward * speed;
        Destroy(gameObject, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (bulletRateTime < timeAfterSpawn)
        {
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(bulletPrefab, transform.position,
                bulletRotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Die();
            }
                gameObject.SetActive(false);
        }

    }
}

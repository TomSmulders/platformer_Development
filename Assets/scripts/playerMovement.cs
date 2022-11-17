using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 10;
    public float jumpheight = 5;
    public GameObject bullet;

    public float facingDirX = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        

        transform.Translate(transform.right * dirX * speed * Time.deltaTime);
        transform.Translate(transform.up * dirY * jumpheight * Time.deltaTime);

        if (dirX == -1 || dirX ==1)
        {
            facingDirX = dirX;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<bullet>().dirX = facingDirX;
        }
    }
}

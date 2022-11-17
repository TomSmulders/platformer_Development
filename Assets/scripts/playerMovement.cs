using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 10;

    public float buttonTime = 0.3f;
    float jumpTime;
    bool jumping;
    float jumpForce = 15;

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

        if (dirX == -1 || dirX ==1)
        {
            facingDirX = dirX;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<bullet>().dirX = facingDirX;
        }

        //jump https://www.youtube.com/watch?v=c9kxUvCKhwQ

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
            jumpTime = 0;
        }
        if (jumping)
        {
            jumpTime += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space) | jumpTime > buttonTime)
        {
            jumping = false;
        }
        
        Rigidbody2D.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}

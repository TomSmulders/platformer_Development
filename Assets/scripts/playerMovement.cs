using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //walking
    public float speed = 10;
    float dirX;

    public AudioSource audio;
    private Animator anim;
    public Transform schootPoint;
    public SpriteRenderer sprite;

    //jumping
    public Rigidbody2D rb;
    public float buttonTime = 0.5f;
    public float jumpHeight = 5;
    public float cancelRate = 100;
    float jumpTime;
    bool jumping;
    bool jumpCancelled;
    public AudioClip jumpSoundEffect;

    //schooting
    public GameObject bullet;
    public float facingDirX = 1;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
       dirX = Input.GetAxisRaw("Horizontal");

        if (dirX < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (dirX > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        //jump 

        if (jumpCancelled && jumping && rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * cancelRate);

        }

    }
    // Update is called once per frame
    void Update()
    {

        if (dirX == -1 || dirX ==1)
        {
            facingDirX = dirX;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject spawnedBullet = Instantiate(bullet, schootPoint.position, Quaternion.identity);
            spawnedBullet.GetComponent<bullet>().dirX = facingDirX;
            //anim.Play();
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumping = true;
            jumpCancelled = false;
            jumpTime = 0;
            audio.clip = jumpSoundEffect;
            audio.Play();
        }
        if (jumping)
        {
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
            }
            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
        }
        anim.SetFloat("Walking", Mathf.Abs(rb.velocity.x));

        if (rb.velocity.x < 0)
        {
            sprite.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            sprite.flipX = false;
        }

    }


}

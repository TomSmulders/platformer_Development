using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy : MonoBehaviour
{
    public int hp = 2;
    public float speed = 5f;
    public float strarting;

    float dirX = 1f;
    bool isAlive = true;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {


            transform.Translate(transform.right * dirX * speed * Time.deltaTime);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * dirX, 0.6f);

            Debug.DrawRay(transform.position, transform.right * 0.6f * dirX, Color.blue);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("wall"))
                {
                    dirX *= -1f;

                }
            }

        }

    }

    public void takeDamage()
    {
        hp--;
        if (hp <= 0 )
        {
            die();
        }
    }

    void die()
    {
        isAlive = false;
        anim.SetBool("IsAlive", isAlive);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 15f;
    public float liveTimeBullet = 3;
    public float dirX = 1f;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, liveTimeBullet);
        if (dirX < 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * dirX * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            enemy enemy = collision.gameObject.GetComponent<enemy>();
            enemy.takeDamage();
            Destroy(gameObject);
        }

    }
}

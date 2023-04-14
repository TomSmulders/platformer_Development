using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpHeight = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<playerMovement>().Audio.PlayOneShot(collision.gameObject.GetComponent<playerMovement>().jumpSoundEffect);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }
    
}

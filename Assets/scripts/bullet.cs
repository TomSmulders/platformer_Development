using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 15f;
    public float liveTimeBullet = 3;
    public float dirX = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, liveTimeBullet);
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.Translate(transform.right * dirX * speed * Time.deltaTime);
    }
}

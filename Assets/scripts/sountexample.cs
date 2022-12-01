using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sountexample : MonoBehaviour
{
    public GameObject audio;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(audio, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

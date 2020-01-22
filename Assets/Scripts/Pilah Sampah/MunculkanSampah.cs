using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunculkanSampah : MonoBehaviour
{
    public float jeda = 2f;
    float timer;
    public GameObject[] objectSampah;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > jeda)
        {
            int random = Random.Range(0, objectSampah.Length);
            Instantiate(objectSampah[random], transform.position, transform.rotation);
            timer = 0;
        }
    }
}

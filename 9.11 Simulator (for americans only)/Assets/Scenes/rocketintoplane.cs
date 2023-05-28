using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketintoplane : MonoBehaviour
{[SerializeField] private GameObject lagg;
    [SerializeField] private float speed = 18f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, lagg.transform.position, speed * Time.deltaTime);
        transform.up = lagg.transform.position - transform.position;
    }
}

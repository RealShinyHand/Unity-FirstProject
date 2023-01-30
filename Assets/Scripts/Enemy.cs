using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed =5;
    // Start is called before the first frame update
    Vector3 dir;
    void Start()
    {

        int value = UnityEngine.Random.Range(0, 10);
    
        if(value < 3)
        {
            GameObject target = GameObject.Find("Player");
            if(target != null) { 
            dir = target.transform.position - this.transform.position;
            dir.Normalize();
            }
        }
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += dir * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }
}

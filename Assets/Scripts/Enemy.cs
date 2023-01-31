using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed =5;
    // Start is called before the first frame update
    Vector3 dir;
    public GameObject explosionFactory;
    void Start()
    {
        //  explosionFactory = Resources.Load<GameObject>("JMO Assets/Cartoon FX Remaster/CFXR Prefabs/Explosions/CFXR Explosion Smoke 2 Solo (HDR).prefab");

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
        GameObject explosion =  Instantiate(explosionFactory);
        explosion.transform.position = this.transform.position;


        GameObject scoreObject = GameObject.Find("ScoreManager");
        ScoreManager scoreManager = scoreObject.GetComponent<ScoreManager>();

        
        scoreManager.updateSocore();



        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }
}

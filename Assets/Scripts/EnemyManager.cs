using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime;
    public float createTime;
    public GameObject enemyFactory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float randomValue = UnityEngine.Random.Range(1, 10) * 0.1f;
        currentTime += Time.deltaTime * randomValue;
        if(currentTime > createTime)
        {
            GameObject enemy =  Instantiate(enemyFactory);
            enemy.transform.position = this.transform.position;
            currentTime = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    public static PlayerFire Instance = null;
    private void Awake()
    {
        Instance = this;
    }
    private int poolSize = 10;
    private Queue<GameObject> bulletList;
    public GameObject bulletFactory;
    public GameObject firePosition;

    // Start is called before the first frame update
    void Start()
    {
        bulletList = new Queue<GameObject>();
        GameObject bulletTemp = null;
        for(int i = 0; i < poolSize; i++)
        {
            bulletTemp = Instantiate<GameObject>(bulletFactory);
            bulletFactory.SetActive(false);
            bulletList.Enqueue(bulletTemp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = null;
            if(bulletList.Count != 0)
            {
                bullet = bulletList.Dequeue();
                bullet.transform.position = firePosition.transform.position;
                bullet.SetActive(true); 
            }
            else if(bulletList.Count == 0)
            {
                Debug.Log("ÃÑ¾Ë ¾øÀ½");
            }
          
        }
    }
    public void restoreBullet(GameObject bullet)
    {
        Debug.Log("ÃÑ¾Ë È¸¼ö");
        bullet.SetActive(false);
        bulletList.Enqueue(bullet);
    }
}

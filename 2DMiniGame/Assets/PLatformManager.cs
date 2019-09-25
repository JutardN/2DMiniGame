using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLatformManager : MonoBehaviour
{
    public GameObject platform;
    public Vector3 position;
    public int count;
    public int inCount;
    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(platform.transform.position.x, 0, 0);
        Instantiate(platform, position, Quaternion.identity);
        //position = new Vector3(platform.transform.position.x + 2, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        CreatePlatform(Random.Range(0, 2));
    }

    public void CreatePlatform(int solution)
    {
        if (solution == 1)
        {
            inCount++;
            if (inCount == 3)
            {
                CreatePlatform(0);
                inCount = 0;
            }else
            {
                position = position + new Vector3(platform.transform.position.x + 2, 0, 0);
            }
                
            
        }
        else
        {
            position = position + new Vector3(platform.transform.position.x + 2, Random.Range(-1, 2), 0);
            Instantiate(platform, position, Quaternion.identity);
        }
        
    }
}

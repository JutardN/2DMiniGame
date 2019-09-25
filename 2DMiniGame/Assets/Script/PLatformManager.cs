using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLatformManager : MonoBehaviour
{
    public GameObject platform;
    public GameObject platformBonus;
    public GameObject platformMalus;
    public Vector3 position;

    public int countPlatform = 15;
    private int compt=0;
    private int rand;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(platform.transform.position.x, 0, 0);
        Instantiate(platform, position, Quaternion.identity);
        //position = new Vector3(platform.transform.position.x + 2, 0, 0);
        Begin(countPlatform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Begin(int com)
    {
        for (int i = 0; i <= com; i++)
        {
            if (compt == 2)
            {
                rand = 1;
                compt = 0;
            }
            else
            {
                rand = Random.Range(1, 3);
            }

            if (rand == 2)
            {
                compt++;
            }
            else
            {
                compt = 0;
            }

            CreatePlatform(rand);
        }
    }

    public void CreatePlatform(int solution)
    {
        int myRandom = Random.Range(1, 9);
        switch (solution)
        {
            case 1:
                position = position + new Vector3(platform.transform.position.x + 2, Random.Range(-1, 1), 0);
                if (myRandom == 1)
                {
                    Instantiate(platformMalus, position, Quaternion.identity);
                } else if (myRandom == 3) {
                    Instantiate(platformBonus, position, Quaternion.identity);
                }else {
                    Instantiate(platform, position, Quaternion.identity);
                }
                
                break;
            case 2:
                position = position + new Vector3(platform.transform.position.x + 2, 0, 0);
                break;
            default:
                break;
        }
    }
}

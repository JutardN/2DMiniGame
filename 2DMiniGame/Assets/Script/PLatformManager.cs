﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLatformManager : MonoBehaviour
{
    public GameObject platform;
    public GameObject platformBonus;
    public GameObject platformMalus;
    public GameObject gold;
    public Vector3 position;

    public int countPlatform = 15;
    private int compt=0;
    private int rand;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(platform.transform.position.x, 0, 0);
        Instantiate(platform, position, Quaternion.identity);
        Begin(countPlatform);
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
                rand = Rand(1,3);
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
        int myRandom = Rand(1,9);
        switch (solution)
        {
            case 1:
                position = position + new Vector3(platform.transform.position.x + 2, Rand(-1,2), 0);
                GenerateBlock(myRandom);
                
                break;
            case 2:
                position = position + new Vector3(platform.transform.position.x + 2, 0, 0);
                break;

            case 3:
                position = position + new Vector3(platform.transform.position.x + 2, Rand(-1,1), 0);
                GenerateBlock(myRandom);
                break;

            default:
                break;
        }

    }

    public void GenerateBlock(int myRandom)
    {
        if (myRandom == 1)
        {
            Instantiate(platformMalus, position, Quaternion.identity);
        }
        else if (myRandom == 3)
        {
            Instantiate(platformBonus, position, Quaternion.identity);
            Instantiate(gold, position + new Vector3(-0.5f, 0.7f, 0), Quaternion.identity);
            Instantiate(gold, position + new Vector3(0, 1.2f, 0), Quaternion.identity);
            Instantiate(gold, position + new Vector3(0.5f, 0.7f, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(platform, position, Quaternion.identity);
            int isGold = Rand(1,3);
            if (isGold == 1)
            {
                Instantiate(gold, position + new Vector3(0, Random.Range(0.7f, 1.7f), 0), Quaternion.identity);
            }
        }
    }

    public int Rand(int min,int max)
    {
        
        return Random.Range(min,max);
    }
}

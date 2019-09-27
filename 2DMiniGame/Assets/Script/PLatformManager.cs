using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLatformManager : MonoBehaviour
{
    public GameObject platform;
    public List<GameObject> platformListe = new List<GameObject>();
    public GameObject platformBonus;
    public GameObject platformMalus;
    public Vector3 position;

    public int countPlatform = 30;
    private int compt=0;
    private int rand;
        
    public float timeBeforeSpawn = 0.2f;
    private float timeLeft = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(platform.transform.position.x, 0, 0);
        Instantiate(platform, position, Quaternion.identity);
        Begin(countPlatform);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && platformListe.Count !=50)
        {
            Begin(1);
            timeLeft = 0.5f;
            //this.gameObject.SetActive(false);
        }
    }

    public void Begin(int com)
    {
        StartCoroutine(SpawnPlat(com));
    }

    IEnumerator SpawnPlat(int com)
    {
        for (int i = 0; i <= com; i++)
        {
            if (compt == 2)
            {
                rand = 3;
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
            yield return new WaitForSeconds(timeBeforeSpawn);
        }
    }

    public void CreatePlatform(int solution)
    {
        int myRandom = Random.Range(1, 9);
        switch (solution)
        {
            case 1:
                position = position + new Vector3(platform.transform.position.x + 2, Random.Range(-1, 2), 0);
                if (myRandom == 1)
                {
                    Instantiate(platformMalus, position, Quaternion.identity);
                    platformListe.Add(this.gameObject);

                } else if (myRandom == 2) {
                    Instantiate(platformBonus, position, Quaternion.identity);
                    platformListe.Add(this.gameObject);

                }
                else {
                    Instantiate(platform, position, Quaternion.identity);
                    platformListe.Add(this.gameObject);
                }
                
                break;

            case 2:
                position = position + new Vector3(platform.transform.position.x + 2, 0, 0);
                break;

            case 3:
                position = position + new Vector3(platform.transform.position.x + 2, Random.Range(-1, 1), 0);

                if (myRandom == 1)
                {
                    Instantiate(platformMalus, position, Quaternion.identity);
                }
                else if (myRandom == 2)
                {
                    Instantiate(platformBonus, position, Quaternion.identity);
                }
                else
                {
                    Instantiate(platform, position, Quaternion.identity);
                }
                break;

            default:
                break;
        }
    }
}

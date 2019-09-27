using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyManager : MonoBehaviour
{
    [Header("Time before deactivation")]
    private float timeLess = 5f;

    public PLatformManager plat;
    private List<GameObject> listePlat;
    private int count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        listePlat = plat.platformListe;
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(DestroyPlat());
    }

    IEnumerator DestroyPlat()
    {
        timeLess-= Time.deltaTime;
        if (this.timeLess < 0)
        {
            listePlat[0].SetActive(false);
            listePlat.RemoveAt(0);
            timeLess = 5f;
            Debug.Log(listePlat.Count);
        }
        yield return new WaitForSeconds(2f);
    }

}

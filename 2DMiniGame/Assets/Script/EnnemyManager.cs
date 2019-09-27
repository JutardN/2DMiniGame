using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyManager : MonoBehaviour
{

    public GameObject player;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.y - player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.08f, 0, 0);
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(this.transform.position.x, player.transform.position.y, 0);
    }
}

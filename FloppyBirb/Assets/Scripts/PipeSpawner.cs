using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float repeatRate = 1;
    private float timer = 0;
    public float height = 5;
    public float coinHeight = 2;
    public GameObject prefabPipe;
    public GameObject prefabRedPipe;


    private int loteria;
    private int lotto;


    // Update is called once per frame
    void Update()
    {
        if (timer > repeatRate)
        {
            timer = 0;
            loteria = Random.Range(0, 2);
            SpawnPipe();
            lotto = Random.Range(0, 101);
            SpawnCoin();
        }
        timer += Time.deltaTime;
    }



    private void SpawnPipe()
    {
        if (loteria == 0)
        {
            GameObject newPipe = Instantiate(prefabPipe);
            newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newPipe, 10f);
        }
        if(loteria == 1)
        {
            GameObject newPipe = Instantiate(prefabRedPipe);
            newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newPipe, 10f);
        }
    }

    private void SpawnCoin()
    {
        if (90>lotto)
        {
            GameObject newCoin = prefabPipe.gameObject.GetComponent<Pipe>().coin;
            newCoin.transform.position = transform.position + new Vector3(0, Random.Range(-coinHeight, coinHeight), -2);
            newCoin.SetActive(true);
        }
    }
}

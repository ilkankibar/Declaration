using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject enemy;
    public bool isGameStarted = false;
    private void Start()
    {
        StartCoroutine("Spawner");
    }
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(Random.Range(3, 15));
        if (!isGameStarted)
        {            
            Instantiate(enemy, transform.position, enemy.transform.rotation);
        }        
        StartCoroutine("Spawner");
    }
}

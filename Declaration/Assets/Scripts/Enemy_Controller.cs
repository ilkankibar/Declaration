using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float speed;
    public bool isDead = false;
    public GameObject bullet;
    public Transform enemyFirePoint;

    public AudioSource fireSound;
    public AudioSource deadSound;
    private void Start()
    {
        speed = Random.Range(1, 3);
        StartCoroutine(RandomFire());
    }
    private void Update()
    {
        transform.Translate(new Vector2(0, speed*Time.deltaTime));
        if (transform.position.x < -5f)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator RandomFire()
    {
        yield return new WaitForSeconds(Random.Range(1, 9));
        if (!isDead)
        {
            Instantiate(bullet, enemyFirePoint.position, transform.rotation);
            fireSound.Play();
        }        
        StartCoroutine(RandomFire());
    }
}

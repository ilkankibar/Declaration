using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject gm;
    private void Start()
    {
        Destroy(this.gameObject, 5f);
        gm = GameObject.Find("GameManager");
    }
    private void Update()
    {
        transform.Translate(new Vector2(0,speed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm.GetComponent<Game_Manager>().PlayerHealthDown();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy_Controller>().deadSound.Play();
            collision.gameObject.GetComponent<Enemy_Controller>().speed = 0;
            collision.gameObject.GetComponent<Enemy_Controller>().isDead = true;
            Destroy(collision.gameObject,0.5f);
            Destroy(this.gameObject);
            
        }
        
    }
}

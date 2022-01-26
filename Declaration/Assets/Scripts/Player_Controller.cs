using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    //Movement variables
    public float currentSpeed;
    private float normalSpeed = 3f;
    private float maxTopRange = 4f;
    private float yInput;

    //Fire variables
    public GameObject bullet;
    public Transform firePoint;

    //Sounds
    public AudioSource fireSound;

    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Mover();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }
    private void Mover()
    {
        yInput = Input.GetAxis("Vertical") * Time.deltaTime * currentSpeed;
        transform.Translate(new Vector2(-yInput, 0));
        if (transform.position.y > maxTopRange)
        {
            transform.position = new Vector2(transform.position.x, maxTopRange - 0.01f);
            currentSpeed = 0;
        }
        else if (transform.position.y < -maxTopRange)
        {
            transform.position = new Vector2(transform.position.x, -maxTopRange +0.01f);
            currentSpeed = 0;
        }
        else
        {
            currentSpeed = normalSpeed;
        }
        if (yInput > 0 || yInput < 0)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
    }
    private void Fire()
    {
        Instantiate(bullet, firePoint.position, transform.rotation);
        anim.SetTrigger("IsFire");
        fireSound.Play();
    }
}

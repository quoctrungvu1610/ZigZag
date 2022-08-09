using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    new AudioClip audio ;
    AudioSource audioSource;

    [SerializeField]
    private float speed;

    Rigidbody rb;

    bool started;
    bool gameOver;

    public GameObject platformSpawner;
    public GameObject particle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManager.instance.StartGame();
            }
        }

        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            platformSpawner.GetComponent<PlatformSpawner>().gameOver = true;

            GameManager.instance.GameOver();
            
            
        }

        if(Input.GetMouseButtonDown(0) && !gameOver){
            SwitchDirection();
        }
     
    }
    void SwitchDirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Diamond")
        {
            audioSource.Stop();
            audioSource.PlayOneShot(audio);
            GameObject effect = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            Destroy(effect, 1f);
            
        }
    }
}

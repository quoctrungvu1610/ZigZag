using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    Vector3 lastPos;
    float sizeX;
    float sizeZ;
    public GameObject platForm;
    public GameObject diamond;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = platForm.transform.position;
        sizeX = platForm.transform.localScale.x;
        sizeZ = platForm.transform.localScale.z; sizeX = platForm.transform.localScale.x;

        //for (int i =0; i< 20; i++)
       // {
          //  SpawnPlatforms();
        //}
        
    }
    public void StartSpawning()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f);
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpawnPlatforms");
        }

    }
    void SpawnPlatforms()
    {
        
        int rand = Random.Range(0, 6);
        if(rand > 3)
        {
            SpawnX();
        }
        else if(rand < 3)
        {
            SpawnZ();
        }

       
        
    }
    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += sizeX;
        lastPos = pos;
        Instantiate(platForm, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if(rand < 2)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }
    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += sizeZ;
        lastPos = pos;
        Instantiate(platForm, pos, Quaternion.identity);
        int rand = Random.Range(0, 4);
        if (rand < 2)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }

}

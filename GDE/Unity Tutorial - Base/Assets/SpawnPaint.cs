using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPaint : MonoBehaviour {

    public Rigidbody spawnProjectile;
    Rigidbody paint;
    public Transform projectileSpawnPoint;
    public float projectileSpeed = 50;
    private float elapsedTime = 0;

    // Use this for initialization
    void Start () {

        paint = (Rigidbody)Instantiate(spawnProjectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        paint.GetComponent<Rigidbody>().velocity = paint.transform.up * projectileSpeed;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        elapsedTime += Time.deltaTime;

        if (elapsedTime < 5)
        {

            //Destroy(paint, 1f);
        }

        if(elapsedTime > 20)
        {
            elapsedTime = 0;
        }
        Destroy(paint, 5f);
    }
}

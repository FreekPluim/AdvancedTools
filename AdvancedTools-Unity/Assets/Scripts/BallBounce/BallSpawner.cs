using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : Spawner
{
    public float spawnRange = 10;
    public Vector2 VelocityMinMax = new Vector2(0.5f, 2f);

    public override void Spawn()
    {
        for (int i = 0; i < objects; i++)
        {
            GameObject ball = Instantiate(block, (transform.position + (Random.insideUnitSphere * spawnRange)), Quaternion.identity, transform);
            ball.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * Random.Range(VelocityMinMax.x, VelocityMinMax.y);
    }
    }
}

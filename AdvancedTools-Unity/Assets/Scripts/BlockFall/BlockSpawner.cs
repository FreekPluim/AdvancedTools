using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : Spawner
{
    public float spawnRange = 5;

    public override void Spawn()
    {
        for (int i = 0; i < objects; i++)
        {
            Instantiate(block, (transform.position + (Random.insideUnitSphere * spawnRange)), Quaternion.identity, transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, spawnRange);  
    }
}

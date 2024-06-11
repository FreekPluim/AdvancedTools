using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySpawner : Spawner
{
    public List<GameObject> M_objects;
    public float spawnRange = 5;

    public override void Spawn()
    {
        for (int i = 0; i < objects; i++)
        {
            Instantiate(M_objects[Random.Range(0, M_objects.Count)], (transform.position + (Random.insideUnitSphere * spawnRange)), Quaternion.identity, transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }
}

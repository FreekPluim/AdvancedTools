using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject objToSpawn;
    [SerializeField] public int amountOfObjects;

    public void SpawnAndDestroy()
    {
        GameObject obj = Instantiate(objToSpawn, transform);
        Destroy(obj);
    }

    public void Spawn()
    {
        Instantiate(objToSpawn, transform);
    }

    public void Remove()
    {
        for (int i = transform.childCount -1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_Return : MonoBehaviour
{
    private ObjectPool objectPool;

    // Start is called before the first frame update
    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
    }

    private void OnDisable()
    {
        if(objectPool != null)
        {
            objectPool.ReturnGameObject(this.gameObject);
        }
    }
}

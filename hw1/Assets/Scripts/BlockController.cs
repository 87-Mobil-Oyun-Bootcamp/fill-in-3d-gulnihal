using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameObject sp;
    //public BlockSpawner sp;
    private bool isUsed = false; // to avoid painting two colored squares with 1 box

    private void Awake()
    {
        // sp = GameObject.Find("BlockSpawner");
        sp = GameObject.FindGameObjectWithTag("BlockSpawner");
    }

    private void OnTriggerEnter(Collider other)
    {
        //GameObject pikaCubes = other.GetComponent<GameObject>();
        GameObject pikaCubes = other.gameObject; // gameObject: the game object this component attached to

        if (other.gameObject.CompareTag("Uncolored") && !isUsed)
        {
            Color color = sp.GetComponent<BlockSpawner>().dict[pikaCubes.transform];
            pikaCubes.GetComponent<Renderer>().material.color = color;
            Object.Destroy(gameObject);
            pikaCubes.tag = "colored";
            isUsed = true;
        }

    }
}

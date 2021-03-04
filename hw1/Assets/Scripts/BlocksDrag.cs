using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksDrag : MonoBehaviour
{

    Texture2D texture2D;
    Vector3 cubePos;

    [Space]
    [SerializeField]
    private Sprite pikaSprite;

    [Space]
    [SerializeField]
    private float cubeSize = .1f;

    [Space]
    [SerializeField]
    private GameObject cube;

    private void Awake()
    {
        texture2D = pikaSprite.texture;


        for (int i = 0; i < texture2D.width; i++)
        {
            for (int j = 0; j < texture2D.height; j++)
            {

                Color color = texture2D.GetPixel(i, j);
                if (color.a == 0) continue;
                cubePos = new Vector3(cubeSize * (i - (texture2D.width * 0.5f)), 0f, cubeSize * (j - (texture2D.height * .5f)));
                GameObject cubeObj = Instantiate(cube, cubePos, Quaternion.identity , transform);
                cubeObj.transform.localScale = cubeSize * Vector3.one;
                cubeObj.transform.localPosition = cubePos;
                cubeObj.GetComponent<Renderer>().material.color = color;


            }
        }

    }
}

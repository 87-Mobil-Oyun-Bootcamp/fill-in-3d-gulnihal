using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class BlockSpawner : MonoBehaviour
{
    
    [Space]
    [SerializeField]
    private Sprite pikaSprite; // Serializable, for being able to attach the photo from unity

    [Space]
    [SerializeField]
    private GameObject PikaCube; // get original object from unity
                               // and make the clone of it -in line 30 

     [Space]
     [SerializeField]
     private float cubeSize = .1f;

     Vector3 cubePos;
     Texture2D texture2D;

    public Material pikaMaterial;

     void Awake()
     {
         texture2D = pikaSprite.texture;
        

         for(int i=0; i< texture2D.width; i++)
         {
             for(int j=0; j< texture2D.height; j++)
             {

                 Color color = texture2D.GetPixel(i, j);
                 // color.a : alpha component of the color ( 0- transparent, 1- opaque ) 
                 if(color.a == 0)
                 {
                     continue;
                 }

                
                 //cubePos = new Vector3(i*offsetX - texture2D.width*0.5f, 0f, j*offsetY-texture2D.height*.5f); // fazla büyük
                 //cubePos = new Vector3(i * cubeSize - texture2D.width * 0.5f, 0f, j * cubeSize - texture2D.height * .5f);
                 // cubeSize ile çarpınca hesapladığı oranlar değişti, image ı sol altta bi yere bastı
                 cubePos = new Vector3(cubeSize*( i- (texture2D.width * 0.5f)), 0f, cubeSize*(j - (texture2D.height * .5f)));
                 //GameObject cubeObj = Instantiate(PikaCube, cubePos, Quaternion.identity, transform);
                 GameObject cubeObj = Instantiate(PikaCube, transform);
                 cubeObj.transform.localPosition = cubePos;
                 cubeObj.transform.localScale = cubeSize* Vector3.one;
                 cubeObj.GetComponent<Renderer>().material.color = pikaMaterial.color;

    
            }
        }

        
    }

    void Update()
    {
        
    }





}

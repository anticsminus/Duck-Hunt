using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CreateFlooringPrefab : MonoBehaviour
{
    public int width, depth;
    public GameObject floorPlatform, floorParent;

    // Start is called before the first frame update

    void Start()
    {
        if(GameObject.FindGameObjectWithTag("FloorPrototype") != true)
        buildPrototype();
    }

    void buildPrototype()
    {
        for (int x = 0; x < width; x += 64)
            for (int z = 0; z < depth; z += 64)
            {
                Vector3 pos = new Vector3(x, 0, z); // if you wanted to amend height you could change the zero value for height in terrains
                                                    // Replace 0 with:
                                                    /*
                                                     Vector3 pos = new Vector3(x, Mathf.PerlinNoise(x * 0.2f, z * 0.2f) * 3, z);
                                                      Procedural generation with cubes. 
                                                     */
                GameObject go = Instantiate(floorPlatform, pos, Quaternion.identity);
                go.tag = "FloorPrototype";
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

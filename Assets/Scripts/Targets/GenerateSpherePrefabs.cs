using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateSpherePrefabs : MonoBehaviour
{
    public static GenerateSpherePrefabs instance;
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    public GameObject prefabObj;
    public Transform parentTran;
    public Material material;

    int sphereCount = 1;
    int row = 5;
    int col = 10;

    GameObject[,] spheres = new GameObject[5,10];
    int[,] activatedIndexs = new int[2, 3];

    public void initiateSpheres()
    {
        generateSpheres();
        activateRandomSpheres(sphereCount);
    }

    void generateSpheres()
    {
        float xOffset = 3f;
        float yOffset = 3f;

        for(int i = 0; i < col; i++)
        {
            for(int j = 0; j < row; j++)
            {
                GameObject spherePrefab = (GameObject)Resources.Load("Sphere");
                GameObject sphere = Instantiate(spherePrefab, Vector3.zero, Quaternion.identity);
                sphere.tag = "Sphere";
                sphere.transform.SetParent(parentTran);

                float xPos = xOffset * i - 5.0f;
                float yPos = yOffset * j - 5.0f;

                sphere.transform.localPosition = new Vector3(xPos, yPos, 0.0f);
                sphere.GetComponent<Renderer>().material = material;
                sphere.SetActive(false);
                spheres[j, i] = sphere;
            }
        }
    }

    void activateRandomSpheres(int count)
    {
        int[] colNums = generateShuffledNumArray(0, col, count);
        int[] rowNums = generateShuffledNumArray(0, row, count);

        Debug.Log("col: " + string.Join(",", colNums.Select(n => n.ToString())));
        Debug.Log("row: " + string.Join(",", rowNums.Select(n => n.ToString())));

        for (int k = 0; k < count; k++)
        {
            spheres[rowNums[k], colNums[k]].SetActive(true);
            activatedIndexs[k, 0] = rowNums[k];
            activatedIndexs[k, 1] = colNums[k];
        }

    }

    int[] generateShuffledNumArray(int min, int max, int count)
    {
        int[] ary = new int[max-min];
        for(int i = min; i < max; i++)
        {
            ary[i] = i;
        }

        for (int i = 0; i < ary.Length; i++)
        {
            int temp = ary[i];
            int randomIndex = Random.Range(0, ary.Length);
            ary[i] = ary[randomIndex];
            ary[randomIndex] = temp;
        }

        return ary;
    }
}

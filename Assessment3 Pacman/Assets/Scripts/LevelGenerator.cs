using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    protected float tileSize = 1;

    [SerializeField]
    private GameObject outsideCorner;
    [SerializeField]
    private GameObject outsideWall;
    [SerializeField]
    private GameObject insideCorner;
    [SerializeField]
    private GameObject insideWall;
    [SerializeField]
    private GameObject standardPellet;
    [SerializeField]
    private GameObject powerPellet;
    [SerializeField]
    private GameObject tJunction;

    [SerializeField]
    private GameObject pacman;

    public static int[,] levelMap1 =
      {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
      };

      protected int[,] RotationMap = {
          {0,1,1,1,1,1,1,1,1,1,1,1,1,0},
          {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
          {0,0,0,3,3,3,0,0,3,3,3,3,0,0},
          {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
          {0,0,1,1,1,2,0,1,1,1,1,2,0,1},
          {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
          {0,0,0,1,1,3,0,0,3,0,0,1,1,1},
          {0,0,1,1,1,2,0,0,2,0,1,1,1,3},
          {0,0,0,0,0,0,0,0,2,0,0,0,0,0},
          {1,1,1,1,1,3,0,0,1,3,3,3,0,0},
          {0,0,0,0,0,0,0,0,0,1,1,2,0,1},
          {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
          {0,0,0,0,0,0,0,0,0,0,0,1,1,0},
          {1,1,1,1,1,2,0,1,2,0,0,0,0,0},
          {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
          };


    void Start()
    {
      SpriteInstantiate();
      GenerateLevel(levelMap1, 0.0f, 0.0f, 0, 0, 0);
    }

    private void SpriteInstantiate()
    {

        pacman.transform.position = new Vector3(0, 0, 10);
    }

    private void GenerateLevel(int[,] map, float startcol, float startrow, int xquad, int yquad, int quadrant)
    {
        for (int row = 0; row < map.GetLength(0); row++)
        {
            for (int col = 0; col < map.GetLength(1); col++)
            {
                if (levelMap1[row, col].Equals(0))
                {

                }
                if (levelMap1[row, col].Equals(1))
                {
                    GameObject oCorner;
                    float posX = (col + startcol) * tileSize * yquad;
                    float posY = (row + startrow) * -tileSize * xquad;
                    oCorner = Instantiate<GameObject>(outsideCorner, new Vector2(posX,posY), Quaternion.identity);
                    oCorner.transform.position = new Vector3(posX, posY, 10);
                    RotateObject(oCorner, row, col, quadrant, RotationMap);
                }
            }
        }
    }
    private void RotateObject(GameObject obj, int row, int col, int quadrant, int [,] mapAdjustment)
    {
        if (quadrant.Equals(0))
        {
            if (mapAdjustment[row, col].Equals(0))
            {

            }
            else if (mapAdjustment[row, col].Equals(1))
            {
                obj.transform.Rotate(0f, 0f, 90f);
            }
            else if (mapAdjustment[row, col].Equals(2))
            {
                obj.transform.Rotate(0f, 0f, 180f);
            }
            else if (mapAdjustment[row, col].Equals(3))
            {
                obj.transform.Rotate(0f, 0f, 270f);
            }
            if (mapAdjustment[row, col].Equals(0))
            {
                obj.transform.Rotate(0f, 0f, 0f);
            }
        }
        else if (quadrant.Equals(1))
        {
            if (mapAdjustment[row, col].Equals(1))
            {
                obj.transform.Rotate(180f, 0f, 90f);
            }
            if (mapAdjustment[row, col].Equals(2))
            {
                obj.transform.Rotate(180f, 0f, 180f);
            }
            if (mapAdjustment[row, col].Equals(3))
            {
                obj.transform.Rotate(180f, 0f, 270f);
            }
            if (mapAdjustment[row, col].Equals(0))
            {
                obj.transform.Rotate(180f, 0f, 0f);
            }
        }
        else if (quadrant.Equals(2))
        {
            if (mapAdjustment[row, col].Equals(1))
            {
                obj.transform.Rotate(0f, 180f, 90f);
            }
            if (mapAdjustment[row, col].Equals(2))
            {
                obj.transform.Rotate(0f, 180f, 180f);
            }
            if (mapAdjustment[row, col].Equals(3))
            {
                obj.transform.Rotate(0f, 180f, 270f);
            }
            if (mapAdjustment[row, col].Equals(0))
            {
                obj.transform.Rotate(0f, 180f, 0f);
            }
        }
        else if (quadrant.Equals(3))
        {
            if (mapAdjustment[row, col].Equals(1))
            {
                obj.transform.Rotate(180f, 180f, 90f);
            }
            if (mapAdjustment[row, col].Equals(2))
            {
                obj.transform.Rotate(180f, 180f, 180f);
            }
            if (mapAdjustment[row, col].Equals(3))
            {
                obj.transform.Rotate(180f, 180f, 270f);
            }
            if (mapAdjustment[row, col].Equals(0))
            {
                obj.transform.Rotate(180f, 180f, 0f);
            }
        }
    }
}

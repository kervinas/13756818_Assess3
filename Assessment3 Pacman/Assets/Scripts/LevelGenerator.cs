using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{


    protected float tile = 1;

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
    private GameObject cherry;
    [SerializeField]
    private GameObject pacman;

    public static int[,] levelMap =
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
          {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
          {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
          {1,0,0,0,0,3,0,0,0,0,0,3,0,1},
          {1,0,1,0,0,1,0,1,0,0,0,1,0,1},
          {1,0,1,0,0,2,0,1,0,0,0,2,0,1},
          {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
          {1,0,0,0,0,3,2,0,3,0,0,1,1,1},
          {1,0,1,0,0,2,0,1,0,0,1,1,1,3},
          {1,0,0,0,0,0,0,1,0,0,0,0,0,0},
          {1,0,0,0,0,3,0,1,1,0,0,3,0,0},
          {0,0,0,0,0,1,0,1,1,0,1,2,0,1},
          {0,0,0,0,0,1,0,1,1,0,1,0,0,0},
          {1,0,0,0,0,1,0,1,1,0,1,1,1,0},
          {2,0,0,0,0,2,0,1,2,0,1,0,0,0},
          {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
          };



      void Start()
      {
          SpriteInstantiate();
          GenerateLevel(levelMap, -15f, -5f, 1, 1, 0);
          GenerateLevel(levelMap, -15f, -24f, -1, 1, 1);
          GenerateLevel(levelMap, -12f, -5f, 1, -1, 2);
          GenerateLevel(levelMap, -12f, -24f, -1, -1, 3);
      }


    private void SpriteInstantiate()
    {

        pacman.transform.position = new Vector3(0, 0, 0);
    }
    private void GenerateLevel(int[,] map, float startColumn, float startRow, int xquad, int yquad, int quadrant)
    {
        for (int row = 0; row < map.GetLength(0); row++)
        {
            for (int column = 0; column < map.GetLength(1); column++)
            {
                if (levelMap[row, column].Equals(0))
                {

                }
                if (levelMap[row, column].Equals(1))
                {
                    GameObject oCorner;
                    float posX = (column + startColumn) * tile * yquad;
                    float posY = (row + startRow) * -tile * xquad;
                    oCorner = Instantiate<GameObject>(outsideCorner, new Vector2(posX,posY), Quaternion.identity);
                    oCorner.transform.position = new Vector3(posX, posY, 10);
                    RotateObject(oCorner, row, column, quadrant, RotationMap);
                }
                if (levelMap[row, column].Equals(2))
                {
                    GameObject oWall;
                    float posX = (column + startColumn) * tile * yquad;
                    float posY = (row + startRow) * -tile * xquad;
                    oWall = Instantiate<GameObject>(outsideWall, new Vector2(posX, posY), Quaternion.identity);
                    oWall.transform.position = new Vector3(posX, posY, 10f);
                    RotateObject(oWall, row, column, quadrant, RotationMap);
                }
                if (levelMap[row, column].Equals(3))
                {
                    GameObject iCorner;
                    float posX = (column + startColumn) * tile * yquad;
                    float posY = (row + startRow) * -tile * xquad;
                    iCorner = Instantiate<GameObject>(insideCorner, new Vector2(posX, posY), Quaternion.identity);
                    iCorner.transform.position = new Vector3(posX, posY, 10f);
                    RotateObject(iCorner, row, column, quadrant, RotationMap);
                }
                if (levelMap[row, column].Equals(4))
                {
                    GameObject iWall;
                    float posX = (column + startColumn) * tile *yquad;
                    float posY = (row + startRow) * -tile *xquad;
                    iWall = Instantiate<GameObject>(insideWall, new Vector2(posX, posY), Quaternion.identity);
                    RotateObject(iWall, row, column, quadrant, RotationMap);
                }
                if (levelMap[row, column].Equals(5))
                {
                    GameObject sPellet;
                    float posX = (column + startColumn) * tile * yquad;
                    float posY = (row + startRow) * -tile * xquad;
                    sPellet = Instantiate<GameObject>(standardPellet, new Vector2(posX, posY), Quaternion.identity);
                    RotateObject(sPellet, row, column, quadrant, RotationMap);
                }
                if (levelMap[row, column].Equals(6))
                {
                    GameObject pPellet;
                    float posX = (column + startColumn) * tile * yquad;
                    float posY = (row + startRow) * -tile * xquad;
                    pPellet = Instantiate<GameObject>(powerPellet, new Vector2(posX, posY), Quaternion.identity);
                    RotateObject(pPellet, row, column, quadrant, RotationMap);
                }
                if (levelMap[row, column].Equals(7))
                {
                    GameObject tJunctionobj;
                    float posX = (column + startColumn) * tile * yquad;
                    float posY = (row + startRow) * -tile * xquad;
                    tJunctionobj = Instantiate<GameObject>(tJunction, new Vector2(posX, posY), Quaternion.identity);
                    RotateObject(tJunction, row, column, quadrant, RotationMap);
                }
                if (levelMap[row, column].Equals(8))
                {
                    GameObject cherryobj;
                    float posX = (column + startColumn) * tile * yquad;
                    float posY = (row + startRow) * -tile * xquad;
                    cherryobj = Instantiate<GameObject>(cherry, new Vector2(posX, posY), Quaternion.identity);
                    cherryobj.transform.position = new Vector3(posX, posY, 10f);
                }
            }
        }
        float GridHeight = levelMap.GetLength(0) * tile;
        float GridWidth = levelMap.GetLength(1) * tile;
        transform.position = new Vector2(-GridWidth / 2 + tile / 2, GridHeight / 2 - tile / 2);
    }

    private void RotateObject(GameObject obj, int row, int column, int quadrant, int [,] mapAdjustment)
    {
        if (quadrant.Equals(0))
        {
            if (mapAdjustment[row, column].Equals(0))
            {

            }
            else if (mapAdjustment[row, column].Equals(1))
            {
                obj.transform.Rotate(0f, 0f, 90f);
            }
            else if (mapAdjustment[row, column].Equals(2))
            {
                obj.transform.Rotate(0f, 0f, 180f);
            }
            else if (mapAdjustment[row, column].Equals(3))
            {
                obj.transform.Rotate(0f, 0f, 270f);
            }
            if (mapAdjustment[row, column].Equals(0))
            {
                obj.transform.Rotate(0f, 0f, 0f);
            }
        }
        else if (quadrant.Equals(1))
        {
            if (mapAdjustment[row, column].Equals(1))
            {
                obj.transform.Rotate(180f, 0f, 90f);
            }
            if (mapAdjustment[row, column].Equals(2))
            {
                obj.transform.Rotate(180f, 0f, 180f);
            }
            if (mapAdjustment[row, column].Equals(3))
            {
                obj.transform.Rotate(180f, 0f, 270f);
            }
            if (mapAdjustment[row, column].Equals(0))
            {
                obj.transform.Rotate(180f, 0f, 0f);
            }
        }
        else if (quadrant.Equals(2))
        {
            if (mapAdjustment[row, column].Equals(1))
            {
                obj.transform.Rotate(0f, 180f, 90f);
            }
            if (mapAdjustment[row, column].Equals(2))
            {
                obj.transform.Rotate(0f, 180f, 180f);
            }
            if (mapAdjustment[row, column].Equals(3))
            {
                obj.transform.Rotate(0f, 180f, 270f);
            }
            if (mapAdjustment[row, column].Equals(0))
            {
                obj.transform.Rotate(0f, 180f, 0f);
            }
        }
        else if (quadrant.Equals(3))
        {
            if (mapAdjustment[row, column].Equals(1))
            {
                obj.transform.Rotate(180f, 180f, 90f);
            }
            if (mapAdjustment[row, column].Equals(2))
            {
                obj.transform.Rotate(180f, 180f, 180f);
            }
            if (mapAdjustment[row, column].Equals(3))
            {
                obj.transform.Rotate(180f, 180f, 270f);
            }
            if (mapAdjustment[row, column].Equals(0))
            {
                obj.transform.Rotate(180f, 180f, 0f);
            }
        }
    }
}

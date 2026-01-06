using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class MapBuilder : MonoBehaviour
{
    #region Inspector

    [Header("Map Object Floor")]
    [Space]
    [SerializeField] private GameObject floorTile;

    [Header("Map Object Wall")]
    [Space]
    [SerializeField] private GameObject wallLeft;
    [SerializeField] private GameObject wallRight;
    [SerializeField] private GameObject wallTop;
    [SerializeField] private GameObject wallBottom;

    [Header("Map Object Cornor")]
    [Space]
    [SerializeField] private GameObject leftTopCornor;
    [SerializeField] private GameObject rightTopCornor;
    [SerializeField] private GameObject leftBottomCornor;
    [SerializeField] private GameObject rightBottomCornor;

    [Header("MapSize")]
    [Space]
    [SerializeField] [Range(0,100)]
    private int mapWidth = 50;
    [SerializeField] [Range(0, 100)]
    private int mapHeight;

    [SerializeField]
    private float yPos = 1.5f;

    [Header("MapStructParent")]
    [Space]
    [SerializeField]
    private GameObject cornorParent;
    [SerializeField]
    private GameObject leftWallParent;
    [SerializeField]
    private GameObject rightWallParent;
    [SerializeField]
    private GameObject topWallParent;
    [SerializeField]
    private GameObject bottomWallParent;
    [SerializeField]
    private GameObject floorParent;

    #endregion

    private void Awake()
    {
        MapBuild();
    }


    private void MapBuild()
    {
        int random = Random.Range(0, 5);
        random = 0;
        switch (random)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        }

        BuildMapStruct();
    }

    private void BuildMapStruct()
    {
        BuildFloor();
        BuildWall();
    }

    private void BuildFloor()
    {
        Vector3 startPoint = new Vector3(mapWidth / 2, 0, mapHeight / 2);
        for(int i = 0; i < mapHeight; i++)
        {
            for(int j=0; j < mapWidth; j++)
            {
                Instantiate(floorTile, (startPoint - new Vector3(j, 0, i)),floorTile.transform.rotation,floorParent.transform);
            }
        }
    }

    private void BuildWall()
    {
        Vector3 startPoint = new Vector3(Mathf.Floor(mapWidth / 2), yPos, Mathf.Floor(mapHeight / 2));

        //Cornor Vector Setting

        Vector3 rtCornor = startPoint + new Vector3(-(mapWidth - 1), 0, -(mapHeight - 1));
        Vector3 ltCornor = startPoint + new Vector3(0,               0, -(mapHeight - 1));
        Vector3 rbCornor = startPoint + new Vector3(-(mapWidth - 1), 0, 0);
        Vector3 lbCornor = startPoint;

        //Cornor
        Instantiate(rightTopCornor,    rtCornor, rightTopCornor.transform.rotation, cornorParent.transform);
        Instantiate(leftTopCornor,     ltCornor, leftTopCornor.transform.rotation, cornorParent.transform);
        Instantiate(rightBottomCornor, rbCornor, rightBottomCornor.transform.rotation, cornorParent.transform);
        Instantiate(leftBottomCornor,  lbCornor, leftBottomCornor.transform.rotation, cornorParent.transform);

        //Bottom & Top

        for (int i = 0; i < mapWidth; i++)
        {
            Instantiate(wallTop,    ltCornor - new Vector3(i, yPos, 0), wallTop.transform.rotation, topWallParent.transform);
            Instantiate(wallBottom, lbCornor - new Vector3(i, yPos, 0), wallTop.transform.rotation, bottomWallParent.transform);
        }

        //Right & Left

        for(int i=0; i < mapHeight; i++)
        {
            Instantiate(wallLeft,  rbCornor - new Vector3(0, yPos, i), wallLeft.transform.rotation, leftWallParent.transform);
            Instantiate(wallRight, lbCornor - new Vector3(0, yPos, i), wallRight.transform.rotation, rightWallParent.transform);
        }
    }
}

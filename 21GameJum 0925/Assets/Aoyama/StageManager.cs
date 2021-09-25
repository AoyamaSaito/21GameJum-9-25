using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] List<GameObject> maps;

    [System.NonSerialized] public List<GameObject> mapsObj = new List<GameObject>();

    int count = 2;

    [SerializeField] int mapWidth = 20;
 
    // Start is called before the first frame update
    void Start()
    {
        StartCreate();
    }

    // Update is called once per frame

    public void StartCreate()
    {
        mapsObj.Add(Instantiate(maps[0]));
        mapsObj.Add(Instantiate(maps[1], new Vector2(mapWidth, 0), Quaternion.identity));
        mapsObj.Add(Instantiate(maps[2], new Vector2(mapWidth, 0), Quaternion.identity));
    }

    public void CreateStage()
    {
        count++;
        int createIndex = count * mapWidth;
        Vector2 mapsWide = new Vector2(createIndex, 0);

        int num = Random.Range(1, maps.Count - 1);
        mapsObj.Add(Instantiate(maps[num], mapsWide, Quaternion.identity));

        DestroyStage();
    }

    public void DestroyStage()
    {
        Destroy(mapsObj[0]);
        mapsObj.RemoveAt(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MapGenerator")
        {
            CreateStage();
        }
    }
}

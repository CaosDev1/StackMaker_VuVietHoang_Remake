using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private LevelButton levelButton;
    [SerializeField] private Transform levelContent;
    private GameObject loadLevel;

    private void Start()
    {
        for (int i = 1; i <= levelData.itemLevel.Count; i++)
        {
            LevelButton btn = Instantiate(levelButton, levelContent);
            btn.SetData(i);
            btn.SetText($"{Const.Level} {i}");
        }
    }

    public void SpawnLevel(int id)
    {
        GameObject mapPrefab = Resources.Load<GameObject>($"{Const.Level}{id}");
        loadLevel = Instantiate(mapPrefab);
    }

    public void DeleteMap()
    {
        Destroy(loadLevel);
    }

    public void SpawnNextLevel()
    {

    }


}

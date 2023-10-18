using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public List<ItemLevelData> itemLevel;
}

[Serializable]
public class ItemLevelData 
{
    public int id;
}


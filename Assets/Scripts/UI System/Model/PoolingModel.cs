﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string Tag;
    public GameObject Prefab;
    public int Size;
}

[System.Serializable]
public class PoolingModel {
    public List<Pool> Pools;
}

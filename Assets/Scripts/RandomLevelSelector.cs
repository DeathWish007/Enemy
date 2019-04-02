using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class RandomLevelSelector
{
    public static string ReturnLevel()
    {
        int rand = Random.Range(4, 6);
        string level=SceneManager.GetSceneByBuildIndex(rand).name;
        return level;
    }
}

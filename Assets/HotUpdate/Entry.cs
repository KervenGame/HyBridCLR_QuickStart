using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Entry
{
    public static void Start()
    {
        Debug.Log("[Entry::Start] 看到这个日志表示你成功运行了热更新代码");
        
        // 1.代码中调用AddComponent来动态挂载热更新脚本
        GameObject go = new GameObject("Test1");
        go.AddComponent<Print>();
        
        // 2.将脚本挂载到热更新资源
        // 挂载热更新脚本的资源（场景或prefab）必须打包成ab，在实例化资源前先加载热更新dll即可
        Run_InstantiateComponentByAsset();
    }
    
    
    private static void Run_InstantiateComponentByAsset()
    {
        // 通过实例化assetbundle中的资源，还原资源上的热更新脚本
        AssetBundle ab = AssetBundle.LoadFromMemory(CommonTool.ReadBytesFromStreamingAssets("prefabs"));
        GameObject cube = ab.LoadAsset<GameObject>("Cube");
        GameObject.Instantiate(cube);
    }
}
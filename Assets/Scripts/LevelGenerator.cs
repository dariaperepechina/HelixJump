using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public int MinPlatforms;
    public int MaxPlatforms;
    public float DistanceBetweenPlatform;
    public Transform FinishPlatform;
    public Transform CylinderRoot;
    public float ExtraCylinderScale = 1f;

    private void Awake()
    {
        int platformsCount = Random.Range(MinPlatforms, MaxPlatforms + 1);

        for (int i = 0; i < platformsCount; i++)
        {
            int prefabIndex = Random.Range(0, PlatformPrefabs.Length);
           
            GameObject platform = Instantiate(PlatformPrefabs[prefabIndex], transform);
            platform.transform.localPosition = new Vector3(0, -DistanceBetweenPlatform * i, 0);
            platform.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);
        }

        FinishPlatform.position = CalculatePlatformPosition(platformsCount);
        CylinderRoot.localScale = new Vector3(1, platformsCount * DistanceBetweenPlatform + ExtraCylinderScale, 1);
    }

    private Vector3 CalculatePlatformPosition(int platformIndex)
    {
        return new Vector3(0, -DistanceBetweenPlatform * platformIndex, 0);
    }
}

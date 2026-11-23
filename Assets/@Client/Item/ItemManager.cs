using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private GameObject itemPrefab = null;

    // 아이템이 생성될 발판들
    [SerializeField]
    private Collider[] platformArray = null;

    [SerializeField]
    private int maxItemCount = 3;
    [SerializeField]
    private float spawnInterval = 5f;
    // 발판 표면에서 띄울 높이
    [SerializeField]
    private float heightOffset = 0.5f;
    // 벽 근처에 붙지 않도록 발판 가장자리에서 띄울 거리
    [SerializeField]
    private float edgeMargin = 1f;

    private List<Item> itemList = null;

    private void Awake()
    {
        itemList = new List<Item>();
    }

    public void Init()
    {
        StartCoroutine(CoSpawnItems());
    }

    private IEnumerator CoSpawnItems()
    {
        while (true)
        {
            if (itemList.Count < maxItemCount)
            {
                SpawnItem();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnItem()
    {
        if (itemPrefab == null || platformArray == null || platformArray.Length == 0)
        {
            Debug.LogWarning("ItemManager: itemPrefab 또는 platformArray가 비어 있음");
            return;
        }

        if (!TryGetRandomPointOnPlatform(out Vector3 spawnPosition))
        {
            return;
        }

        GameObject go = Instantiate(itemPrefab, spawnPosition, Quaternion.identity, transform);

        Item item = go.GetComponent<Item>();
        if (item != null)
        {
            item.Init(OnItemUsed);
            itemList.Add(item);
        }
    }

    private bool TryGetRandomPointOnPlatform(out Vector3 point)
    {
        Collider platform = platformArray[Random.Range(0, platformArray.Length)];
        Bounds bounds = platform.bounds;

        float marginX = Mathf.Min(edgeMargin, bounds.extents.x);
        float marginZ = Mathf.Min(edgeMargin, bounds.extents.z);
        float x = Random.Range(bounds.min.x + marginX, bounds.max.x - marginX);
        float z = Random.Range(bounds.min.z + marginZ, bounds.max.z - marginZ);

        // 발판 위에서 아래로 레이를 쏴서 실제 표면 위치를 구함
        Ray ray = new Ray(new Vector3(x, bounds.max.y + 1f, z), Vector3.down);
        if (platform.Raycast(ray, out RaycastHit hit, bounds.size.y + 2f))
        {
            point = hit.point + Vector3.up * heightOffset;
            return true;
        }

        point = Vector3.zero;
        return false;
    }

    private void OnItemUsed(Item item)
    {
        itemList.Remove(item);
    }
}

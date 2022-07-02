using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 풀에 요소를 등록하고나서 각 요소들의 size 만큼 객체를 새로 생성하고 비활성화
// 객체가 필요하면 해당 객체를 활성화하고 풀 밖으로 꺼냄
// 기존 소환한 객체를 모두 사용 중일 경우 새로 객체를 Instantiate 해서 풀에 등록하고 소환함. 
public class ObjectPool : MonoBehaviour
{
    private static ObjectPool _instance;
    public static ObjectPool instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate(Resources.Load<ObjectPool>("ObjectPool"));
            return _instance;
        }
    }
    public static bool isReady;
    List<PoolElement> poolElements = new List<PoolElement>();
    List<GameObject> spawnedObjects = new List<GameObject>();
    Dictionary<string, Queue<GameObject>> spawnedQueueDictionary = new Dictionary<string, Queue<GameObject>>();

    // 풀에 등록하는 함수
    public void AddPoolElement(PoolElement poolElement)
    {
        poolElements.Add(poolElement);
    }

    // 풀 요소들을 생성하는 함수
    public void CreatePoolElements()
    {
        foreach (PoolElement poolElement in poolElements)
        {
            spawnedQueueDictionary.Add(poolElement.tag, new Queue<GameObject>());
            for (int i = 0; i < poolElement.size; i++)
            {
                GameObject obj = CreateNewObject(poolElement.tag, poolElement.prefab);
                spawnedQueueDictionary[poolElement.tag].Enqueue(obj);
            }
        }
        isReady = true;
    }

    // 객체 소환 함수
    public static GameObject SpawnFromPool(string tag, Vector3 position)
        => instance.Spawn(tag, position);

    // 풀로 되돌리는 함수
    public static void ReturnToPool(GameObject obj)
    {
        // 해당 오브젝트가 풀에 등록되어있는지 체크
        if (instance.spawnedQueueDictionary.TryGetValue(obj.name, out Queue<GameObject> queue))
        {
            obj.transform.position = instance.transform.position;
            queue.Enqueue(obj);
        }
        else
            throw new System.Exception($"{obj.name} wasn't registered");
    }

    // 소환된 특정 태그의 객체 숫자 반환하는 함수
    public static int GetSpawnedObjectNumber(string tag)
    {
        int count = 0;
        foreach (var go in instance.spawnedObjects)
        {
            if (go.name == tag &&
                go.activeSelf)
                count++;
        }
        return count;
    }

    //======================================================================
    //************************* Private Methods ****************************
    //======================================================================

    private void Awake()
    {
        if (_instance != null)
        {
            for (int i = 0; i < spawnedObjects.Count; i++)
                Destroy(spawnedObjects[i]);
            spawnedObjects.Clear();
            foreach (var sub in spawnedQueueDictionary)
                sub.Value.Clear();
            spawnedQueueDictionary.Clear();
            Destroy(_instance);
            _instance = null;
            System.GC.Collect();
            _instance = instance;
        }
    }

    // 객체 생성함수
    private GameObject CreateNewObject(string tag, GameObject prefab)
    {
        GameObject obj = Instantiate(prefab, transform);
        obj.name = tag;
        obj.SetActive(false);
        ArrangePool(obj);
        return obj;
    }

    // 소환하는 함수
    private GameObject Spawn(string tag, Vector3 position)
    {
        // 소환하고싶은 태그가 사전에 있는지 체크
        if (spawnedQueueDictionary.TryGetValue(tag, out Queue<GameObject> queue))
        {
            // 해당 태그의 객체들이 이미 모두 사용되고 있다면 새로 생성
            if (queue.Count == 0)
            {
                PoolElement poolElement = poolElements.Find(x => x.tag == tag);
                CreateNewObject(poolElement.tag, poolElement.prefab);
            }
        
            GameObject objectToSpawn = queue.Dequeue();
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = Quaternion.identity;
            objectToSpawn.SetActive(true);
        
            return objectToSpawn;
        }
        else
            throw new System.Exception($"Pool doesn't contains {tag}");
    }


    // 풀을 정렬하는 함수
    private void ArrangePool(GameObject obj)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == obj.name)
            {
                obj.transform.SetSiblingIndex(i);
                spawnedObjects.Insert(i, obj);
                break;
            }
        }
    }
}

// 풀에 등록할 요소 타입(클래스)
[System.Serializable]
public class PoolElement
{
    public string tag;
    public GameObject prefab;
    public int size;
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class BridgeManager : MonoBehaviour
{
     public bool canSpawn;
    
    [SerializeField] private float _spawnTime;
    [SerializeField] private BridgeFactory _factory = new BridgeFactory();
    [SerializeField] private BridgeController[] productPrefab;
    [SerializeField] private BridgeController _currentBridge;
    [SerializeField] private bool isCorrutineRuning;
    [SerializeField] private bool spawnFirstBridge;
    [SerializeField] private Vector3 firstBridgeSpawn;
    private ObjectPool<BridgeController> _objectPool;

    private void OnEnable()
    {
        _objectPool = new ObjectPool<BridgeController>(() => CreatePoolObject(),
            bridge => { bridge.gameObject.SetActive(true); }, bridge => { bridge.gameObject.SetActive(false); },
            bridge => { Destroy(bridge.gameObject); }, false, 20, 50);
        isCorrutineRuning = false;
        spawnFirstBridge = true;
        canSpawn = true;
        SpawnFirstBridge();
    }

    private void Update()
    {
        if (canSpawn)
        {
            if (!isCorrutineRuning)
            {
                StopCoroutine(SpawnBridge());
                StartCoroutine(SpawnBridge());
            }
        }
        else
        {
            StopAllCoroutines();
            isCorrutineRuning = false;
        }
    }

    private IEnumerator SpawnBridge()
    {
        BridgeController temp = null;
        isCorrutineRuning = true;
        yield return new WaitForSeconds(_spawnTime);
        _objectPool.Get(out temp);
        Vector3 spawnPos = _currentBridge.transform.position;
        spawnPos.y += 3.65f;

        _factory.ConfigureBridge(spawnPos, temp);
        temp.OnDestroyBridge.AddListener(OnDestroyedBridge);
        //_currentBridge = (BridgeController)BridgeFactory.Instance.GetProduct(spawnPos);
        _currentBridge = temp;
        yield return null;
        isCorrutineRuning = false;
        yield return null;
    }

    private void SpawnFirstBridge()
    {
        BridgeController temp = null;
        _objectPool.Get(out temp);
        _factory.ConfigureBridge(firstBridgeSpawn, temp);
        temp.OnDestroyBridge.AddListener(OnDestroyedBridge);
        _currentBridge = temp;
    }

    public void OnDestroyedBridge(BridgeController bridge)
    {
        bridge.OnDestroyBridge.RemoveListener(OnDestroyedBridge);
        bridge.transform.position = Vector3.zero;
        _objectPool.Release(bridge);
    }

    private BridgeController CreatePoolObject()
    {
        int bridgeToSpawn = 0;
        if (spawnFirstBridge)
        {
            spawnFirstBridge = false;
            return _factory.CreatePool(Vector3.zero, productPrefab[bridgeToSpawn]);
        }

        int maxValue = _currentBridge.GetPossibleNeighbors().Length - 1;
        bridgeToSpawn = Random.Range(0,maxValue);
        
        return _factory.CreatePool(Vector3.zero, _currentBridge.GetPossibleNeighbors()[bridgeToSpawn]);
    }
}
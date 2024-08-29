using System;
using UnityEngine;
using UnityEngine.Pool;

public class BridgeFactory
{
    public BridgeController CreatePool(Vector3 position,BridgeController productPrefab)
    {
        BridgeController newProduct = null;
        // create a Prefab instance and get the product component
        GameObject instance = GameObject.Instantiate(productPrefab.gameObject, position, Quaternion.identity);
        newProduct = instance.GetComponent<BridgeController>();

        // each product contains its own logic
        newProduct.Initialize();

        return newProduct;
    }

    public void ConfigureBridge(Vector3 position,BridgeController productToModify)
    {
        productToModify.gameObject.transform.position = position;
        productToModify.Initialize();
    }
}
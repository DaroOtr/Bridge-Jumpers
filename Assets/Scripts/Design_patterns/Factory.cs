using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public interface IProduct
{
    public string ProductName { get; set; }

    public void Initialize();
}

public abstract class Factory <T> : MonoBehaviour
{
    public abstract IProduct GetProduct(Vector3 position);
}

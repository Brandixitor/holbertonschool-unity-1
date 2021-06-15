using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides coin rotation.
/// </summary>
public class Rotator : MonoBehaviour
{
    public GameObject coin;
    public float speed = 45f;

    // Update is called once per frame
    void Update()
    {
        coin.transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
    }
}

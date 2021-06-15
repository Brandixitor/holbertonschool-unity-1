using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides camera tracking.
/// </summary>
public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    private Vector3 offset; 


    /// <summary>
    /// Computes player-camera offset.
    /// </summary>
    void Start()
    {
        offset = cam.transform.position - player.transform.position;
    }

    /// <summary>
    /// Updates camera to track the player.
    /// </summary>
    void Update()
    {
        cam.transform.position = player.transform.position + offset;
    }
}

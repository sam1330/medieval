﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    [Tooltip("Game units per second")]
    [SerializeField] float scrollRate = 0.7f;

    void Update()
    {
        transform.Translate(Vector2.up * scrollRate * Time.deltaTime);
    }
}

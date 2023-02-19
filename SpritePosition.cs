using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePosition : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private GameObject _player;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GameObject.FindWithTag("Player");
    }

    private void LateUpdate()
    {
        PositionRender();
        
    }

    void PositionRender()
    {
        Vector2 posPlayer = _player.transform.position;
        Vector2 pos = transform.position;
        if (Vector2.Distance(posPlayer, pos) < 5f)
        {
            if (posPlayer.y <= pos.y) _spriteRenderer.sortingOrder = 0;
            else _spriteRenderer.sortingOrder = 1;
        }
    }
}

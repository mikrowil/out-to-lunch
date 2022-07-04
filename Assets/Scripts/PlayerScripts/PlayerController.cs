using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Mover _mover;

    private float _playerInputHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        _mover = GetComponent<Mover>();
        _playerInputHorizontal = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();

    }

    private void FixedUpdate()
    {
        if (_playerInputHorizontal > 0.1f || _playerInputHorizontal < -0.1f)
        {
            Movement();
        }
    }
    
    
    

    private void Movement()
    {
       
        _mover.Move(_playerInputHorizontal);
    }

    private void GetInputs()
    {
        _playerInputHorizontal = Input.GetAxis("Horizontal");


        if (Input.GetKeyDown(KeyCode.Space))
        {
            _mover.Jump();
        }
        
    }
}
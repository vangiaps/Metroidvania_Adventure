using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public Vector3 GetMovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");
        return new Vector3(x, 0, 0).normalized;
    }

    public bool JumpInput()
    {
        return(Input.GetKeyDown(KeyCode.Space));
        //return (Input.GetKeyDown(KeyCode.W));
    }
    public bool DashInput()
    {
        //return (Input.GetKeyDown(KeyCode.Space));
        return (Input.GetKeyDown(KeyCode.LeftShift));
    }
    public bool AttackInput()
    {
        return (Input.GetKey(KeyCode.J));
        //return (Input.GetMouseButton(0));
    }

    // attack up
    public bool AttackInput1()
    {
        return (Input.GetKey(KeyCode.I));
        //return (Input.GetMouseButton(1));
    }    
    // attack down
    public bool AttackInput2()
    {
        return (Input.GetKey(KeyCode.K));
        //return (Input.GetKey(KeyCode.LeftControl));
    }

    //
    public bool one()
    {
        return (Input.GetKeyDown(KeyCode.Alpha1));
    }   
    public bool two()
    {
        return (Input.GetKeyDown(KeyCode.Alpha2));
    }    
    public bool three()
    {
        return (Input.GetKeyDown(KeyCode.Alpha3));
    }

    // ki nang f
    public bool Skill()
    {
        return (Input.GetKeyDown(KeyCode.F));
    }
  }


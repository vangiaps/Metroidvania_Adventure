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
        //return (Input.GetKeyDown(KeyCode.J));
        return (Input.GetMouseButton(0));
    }
    public bool AttackInput1()
    {
        //return (Input.GetKeyDown(KeyCode.J));
        return (Input.GetMouseButton(1));
    }    
    public bool AttackInput2()
    {
        //return (Input.GetKeyDown(KeyCode.J));
        return (Input.GetKey(KeyCode.LeftControl));
    }
}


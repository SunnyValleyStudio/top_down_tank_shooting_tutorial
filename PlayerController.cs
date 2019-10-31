using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _horizontalInput = 0;
    private float _verticalInput = 0;
    private Vector3 _mousePosition;
    PlayerTankActions actionScript;
    bool isShooting;
    public GameObject bullet;

    void Start()
    {
        actionScript = GetComponent<PlayerTankActions>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        actionScript.RotateTankTurret(_mousePosition);
        actionScript.RotateTankBody(_horizontalInput);
        if (isShooting)
        {
            Shoot();
            isShooting = false;
        }
        
    }

    private void FixedUpdate()
    {
        //movementScript.MovePlayer(Mathf.Clamp01(_verticalInput));
        actionScript.MovePlayer(_verticalInput);
    }

    private void GetPlayerInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 mousePosition3d = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        _mousePosition = new Vector3(mousePosition3d.x, mousePosition3d.y, 0);
        isShooting = Input.GetKeyDown(KeyCode.Space);
    }

    private void Shoot()
    {
        actionScript.Shoot(bullet);

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGameArea : MonoBehaviour
{

    private DefenderSpawner defenderSpawner = null;
    // Start is called before the first frame update
    void Start()
    {
        defenderSpawner = GetComponent<DefenderSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }

    private void OnMouseDown()
    {
        var worldSpaceCoordinate = Input.mousePosition;
        defenderSpawner.SpawnDefender(GetFormattedPosition(worldSpaceCoordinate));
    }

    private Vector3 GetFormattedPosition(Vector3 position)
    {
        var localMousePosition = Camera.main.ScreenToWorldPoint(position);
        Debug.Log(localMousePosition);
        var x = Mathf.RoundToInt(localMousePosition.x) ;
        var y = Mathf.RoundToInt(localMousePosition.y) ;
        localMousePosition = new Vector3(x, y, 0);
        Debug.Log(localMousePosition);
        return localMousePosition;
    }
}

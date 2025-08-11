using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BuildingGrid : MonoBehaviour
{

    [SerializeField] private Vector2Int _gridSize = new Vector2Int(10, 10);

    private Building[,] _grid;
    private Building _flyingBuilding;
    private Camera _camera;
    
    private void Awake()
    {
        _camera = Camera.main;
        _grid = new Building[_gridSize.x, _gridSize.y];
    }

    void Update()
    {
        if (_flyingBuilding != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);

                _flyingBuilding.transform.position = worldPosition;
            }
        }
    }

    private void StartPlacingBuilding(Building buildingPrefab)
    {
        if (_flyingBuilding == null)
        {
            Destroy(_flyingBuilding);
        }

        _flyingBuilding = Instantiate(buildingPrefab);

    }
    
}

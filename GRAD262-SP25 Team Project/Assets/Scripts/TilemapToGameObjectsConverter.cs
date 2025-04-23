using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TilemapToGameObjectsConverter : EditorWindow
{
    private Tilemap tilemap;
    private GameObject defaultPrefab;
    private bool removeTilesAfterConversion = true;

    [MenuItem("Tools/Convert Tilemap to GameObjects")]
    public static void ShowWindow()
    {
        GetWindow<TilemapToGameObjectsConverter>("Tilemap Converter");
    }

    private void OnGUI()
    {
        GUILayout.Label("Tilemap to GameObjects Converter", EditorStyles.boldLabel);
        tilemap = (Tilemap)EditorGUILayout.ObjectField("Tilemap", tilemap, typeof(Tilemap), true);
        defaultPrefab = (GameObject)EditorGUILayout.ObjectField("Default Prefab", defaultPrefab, typeof(GameObject), false);
        removeTilesAfterConversion = EditorGUILayout.Toggle("Remove Original Tiles", removeTilesAfterConversion);

        if (GUILayout.Button("Convert"))
        {
            if (tilemap == null || defaultPrefab == null)
            {
                Debug.LogWarning("Tilemap and Prefab must be assigned.");
                return;
            }

            ConvertTilemap();
        }
    }

    private void ConvertTilemap()
    {
        Undo.RegisterFullObjectHierarchyUndo(tilemap.gameObject, "Convert Tilemap to GameObjects");

        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                Vector3Int cellPos = new Vector3Int(x + bounds.xMin, y + bounds.yMin, 0);
                TileBase tile = tilemap.GetTile(cellPos);
                if (tile != null)
                {
                    Vector3 worldPos = tilemap.CellToWorld(cellPos) + tilemap.tileAnchor;

                    GameObject obj = (GameObject)PrefabUtility.InstantiatePrefab(defaultPrefab);
                    obj.transform.position = worldPos;
                    Undo.RegisterCreatedObjectUndo(obj, "Create Tile GameObject");

                    // Match the sprite if possible
                    if (tile is Tile tileData && obj.TryGetComponent(out SpriteRenderer sr))
                        sr.sprite = tileData.sprite;

                    obj.name = $"Tile_{cellPos.x}_{cellPos.y}";

                    if (removeTilesAfterConversion)
                        tilemap.SetTile(cellPos, null);
                }
            }
        }

        Debug.Log("Tilemap conversion complete.");
    }
}

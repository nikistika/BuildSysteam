using UnityEngine;

public class Building : MonoBehaviour
{

   [SerializeField] private Vector2Int _size = Vector2Int.one;

    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < _size.x; x++)
        {
            for (int y = 0; y < _size.y; y++)
            {
                if ((x+y) % 2 == 0) Gizmos.color = new Color(0.87f, 0.09f, 1f, 0.36f);
                else Gizmos.color = new Color(0.38f, 0.23f, 1f, 0.72f);
                
                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .03f, 1));
            }
        }
    }

}

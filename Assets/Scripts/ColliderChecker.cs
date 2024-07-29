using System.Text;
using UnityEngine;

public class ColliderChecker : MonoBehaviour
{
    public Vector3 center;
    public Vector3 halfExtents;

    void Start()
    {
        CheckColliders();
    }

    void CheckColliders()
    {
        Collider[] colliders = Physics.OverlapBox(center, halfExtents);

        StringBuilder stringBuilder = new StringBuilder();
        foreach (Collider collider in colliders)
        {
            stringBuilder.Append(collider.name);
            // Do something with the collider

        }
        Debug.Log(stringBuilder.ToString());
    }


    private void OnDrawGizmos()
    {
        //MeshFilter mesh = .GetComponent<MeshFilter>();
        //Bounds bounds = mesh.mesh.bounds;

        //Gizmos.matrix = objToPlace.transform.localToWorldMatrix;
        //Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
}

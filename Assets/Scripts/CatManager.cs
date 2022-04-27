using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class CatManager : MonoBehaviour
{
    public float view_distance = 10;
    [Range(0f, 180f)]
    public float view_angle = 30;
    public float view_height = 1.0f;
    public Color meshColor = Color.red;
    
    public LayerMask targetLaserPointer;
    public LayerMask obstacles;
    public List<GameObject> Objects = new List<GameObject>();

    public float speed = 4f;
    public GameObject GO_LaserPointer;

    [SerializeField] private float scanFrequency = 0.2f;
    Mesh mesh;
    int count;
    Collider[] colliders = new Collider[50];

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScanDelay(scanFrequency));
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInSight(GO_LaserPointer))
        {
            transform.position = Vector3.MoveTowards(transform.position, GO_LaserPointer.transform.position, speed * Time.deltaTime);
            transform.forward = GO_LaserPointer.transform.position - transform.position;
        }
    }

    private Mesh CreateWedgeMesh()
    {
        Mesh mesh = new Mesh();

        int segments = 10;

        int numTriangles = (segments * 4) + 2 + 2;
        int numVertices = numTriangles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 bottomCenter = Vector3.zero;
        Vector3 bottomLeft = Quaternion.Euler(0, -view_angle, 0) * Vector3.forward * view_distance;
        Vector3 bottomRight = Quaternion.Euler(0, view_angle, 0) * Vector3.forward * view_distance;

        Vector3 topCenter = bottomCenter + Vector3.up * view_height;
        Vector3 topRight = bottomRight + Vector3.up * view_height;
        Vector3 topLeft = bottomLeft + Vector3.up * view_height;

        int vert = 0;
        //left side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomLeft;
        vertices[vert++] = topLeft;

        vertices[vert++] = topLeft;
        vertices[vert++] = topCenter;
        vertices[vert++] = bottomCenter;

        //right side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = topCenter;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = bottomRight;
        vertices[vert++] = bottomCenter;

        float currentAngle = -view_angle;
        float deltaAngle = (view_angle * 2) / segments;
        for (int i = 0; i < segments; i++)
        {
            bottomLeft = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward * view_distance;
            bottomRight = Quaternion.Euler(0, currentAngle + deltaAngle, 0) * Vector3.forward * view_distance;

            topRight = bottomRight + Vector3.up * view_height;
            topLeft = bottomLeft + Vector3.up * view_height;

            //far side
            vertices[vert++] = bottomLeft;
            vertices[vert++] = bottomRight;
            vertices[vert++] = topRight;

            vertices[vert++] = topRight;
            vertices[vert++] = topLeft;
            vertices[vert++] = bottomLeft;

            //top
            vertices[vert++] = topCenter;
            vertices[vert++] = topLeft;
            vertices[vert++] = topRight;

            //bottom
            vertices[vert++] = bottomCenter;
            vertices[vert++] = bottomRight;
            vertices[vert++] = bottomLeft;

            currentAngle += deltaAngle;
        }


        for (int i = 0; i < numVertices; ++i)
        {
            triangles[i] = i;
        }
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }

    private void OnValidate()
    {
        mesh = CreateWedgeMesh();
    }

    private IEnumerator ScanDelay(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);
        while (true)
        {
            yield return wait;
            Scan();
        }
    }

    private void Scan()
    {
        count = Physics.OverlapSphereNonAlloc(transform.position, view_distance, colliders, targetLaserPointer, QueryTriggerInteraction.Collide);

        Objects.Clear();
        for (int i = 0; i < count; ++i)
        {
            GameObject obj = colliders[i].gameObject;
            if (IsInSight(obj))
            {
                Objects.Add(obj);
            }
        }
    }

    public bool IsInSight(GameObject obj)
    {
        Vector3 origin = transform.position;
        Vector3 dest = obj.transform.position;
        Vector3 direction = dest - origin;

        if (direction.y < 0 || direction.y > view_height)
        {
            return false;
        }
        direction.y = 0;
        float deltaAngle = Vector3.Angle(direction, transform.forward);
        if (deltaAngle > view_angle)
        {
            return false;
        }
        origin.y += view_height / 2;
        dest.y = origin.y;
        if (Physics.Linecast(origin, dest, obstacles))
        {
            return false;
        }
        return true;
    }

    private void OnDrawGizmos()
    {
        if (mesh)
        {
            Gizmos.color = meshColor;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
        }

        Gizmos.DrawWireSphere(transform.position, view_distance);
        for (int i = 0; i < count; ++i)
        {
            Gizmos.DrawSphere(colliders[i].transform.position, 0.2f);
        }

        Gizmos.color = Color.green;
        foreach (var obj in Objects)
        {
            Gizmos.DrawSphere(obj.transform.position, 0.2f);
        }
    }
}
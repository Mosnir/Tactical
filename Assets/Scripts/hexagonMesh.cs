using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hexagonMesh : MonoBehaviour
{

    float m_radius = 1;
    Vector3 m_center;

    Vector3[] m_vertices = new Vector3[7];
    int[] m_triangles = new int[18];

    private void Awake()
    {
        Triangulate(GetComponent<MeshFilter>().mesh, transform.position);
    }

    public void Triangulate(Mesh mesh, Vector3 center)
    {

        m_vertices[0] = center;

        for (int i = 1; i < 7; i++)
        {
            m_vertices[i] = Corner(i);
        }

        for (int i = 1; i < 7; i++)
        {
            int index = (i-1) * 3;

            m_triangles[index] = 0;
            m_triangles[index+1] = i;

            int next = (i != 6) ? i + 1 : 1;

            m_triangles[index+2] = next;
        }

        mesh.vertices = m_vertices;
        mesh.triangles = m_triangles;
    }

    Vector3 Corner(int i)
    {

        var angle_deg = -60 * i + 30;
        var angle_rad = Mathf.PI / 180.0f * angle_deg;

        return new Vector3(m_center.x + m_radius * Mathf.Cos(angle_rad), m_center.z, m_center.z + m_radius * Mathf.Sin(angle_rad));

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SplineMesh;

public class SplinePositionSetter : MonoBehaviour
{
    public CSVReader csvReader;
    public Spline spline;
    public SplineMeshTiling splineMeshTiling; // Reference to the SplineMeshTiling script

    void Start()
    {
        // Read CSV data from the CSVReader
        List<Vector3> csvData = csvReader.ReadCSVData();

        // Set the spline nodes based on CSV data
        SetSplineNodes(csvData);

        // Refresh the spline curves
        spline.RefreshCurves();

        // Generate the mesh using SplineMeshTiling
        splineMeshTiling.CreateMeshes();
    }

    void SetSplineNodes(List<Vector3> csvData)
    {
        // Clear existing nodes in the spline
        spline.nodes.Clear();
        
        // Add nodes to the spline based on CSV data
        for (int i = 0; i < csvData.Count; i++)
        {
            Vector3 dataPoint = csvData[i];
            int x = 10;
            // Adjust the direction based on the X value plus 10 for each node
            Vector3 direction = dataPoint;

            SplineNode node = new SplineNode(dataPoint, direction);
            spline.AddNode(node);
        }
    }
}

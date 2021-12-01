using OpenGL;

public static class GeometryData
{
    #region Data Cube        

    //--------------------------
    //  Private - Source Only
    //--------------------------
    private static readonly Vector3[] Src = new Vector3[]
    {
        // Bottom
        new Vector3(-0.5f, -0.5f,  0.5f), //I:0
        new Vector3( 0.5f, -0.5f,  0.5f), //I:1
        new Vector3( 0.5f, -0.5f, -0.5f), //I:2
        new Vector3(-0.5f, -0.5f, -0.5f), //I:3
                                          
        // Top                            
        new Vector3(-0.5f,  0.5f,  0.5f), //I:4
        new Vector3( 0.5f,  0.5f,  0.5f), //I:5
        new Vector3( 0.5f,  0.5f, -0.5f), //I:6
        new Vector3(-0.5f,  0.5f, -0.5f), //I:7
    };

    //--------------------------
    //          Public
    //--------------------------
    public static readonly Vector3[] vertices = new Vector3[]
    {
        Src[0], Src[1], Src[2], Src[3], // Bottom Quad
        
        Src[7], Src[4], Src[0], Src[3], // Left Quad
        Src[4], Src[5], Src[1], Src[0], // Back Quad
        Src[6], Src[7], Src[3], Src[2], // Front Quad
        Src[5], Src[6], Src[2], Src[1], // Right Quad
        
        Src[7], Src[6], Src[5], Src[4]  // Top Quad
    };

    public static readonly Vector3[] colors = new Vector3[]
    {
        new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), // Bottom Quad

        new Vector3(1.0f, 1.0f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), // Left Quad
        new Vector3(1.0f, 1.0f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), // Front Quad
        new Vector3(1.0f, 1.0f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), // Back Quad
        new Vector3(1.0f, 1.0f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), // Right Quad

        new Vector3(1.0f, 1.0f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f)  // Top Quad
    };

    public static readonly Vector3[] normals = new Vector3[]
    {
        Vector3.Down, Vector3.Down, Vector3.Down, Vector3.Down,                 // Bottom Quad

        Vector3.Left, Vector3.Left, Vector3.Left, Vector3.Left,                 // Left Quad
        Vector3.Backward, Vector3.Backward, Vector3.Backward, Vector3.Backward, // Back Quad
        Vector3.Forward, Vector3.Forward, Vector3.Forward, Vector3.Forward,	    // Front Quad       
        Vector3.Right, Vector3.Right, Vector3.Right, Vector3.Right,             // Right Quad
       
        Vector3.Up, Vector3.Up, Vector3.Up, Vector3.Up	                        // Top Quad
    };

    public static readonly Vector2[] uvs = new Vector2[]
    {
       new Vector2(1f, 1f), new Vector2(0f, 1f), new Vector2(0f, 0f), new Vector2(1f, 0f), // Bottom Quad

       new Vector2(1f, 1f), new Vector2(0f, 1f), new Vector2(0f, 0f), new Vector2(1f, 0f), // Left Quad
       new Vector2(1f, 1f), new Vector2(0f, 1f), new Vector2(0f, 0f), new Vector2(1f, 0f), // Back Quad
       new Vector2(1f, 1f), new Vector2(0f, 1f), new Vector2(0f, 0f), new Vector2(1f, 0f), // Front Quad       
       new Vector2(1f, 1f), new Vector2(0f, 1f), new Vector2(0f, 0f), new Vector2(1f, 0f), // Right Quad

       new Vector2(1f, 1f), new Vector2(0f, 1f), new Vector2(0f, 0f), new Vector2(1f, 0f)  // Top Quad
    };

    public static readonly uint[] indices = new uint[]
    {
       3, 1, 0,        3, 2, 1,        // Bottom	

       7, 5, 4,        7, 6, 5,        // Left
       11, 9, 8,       11, 10, 9,      // Back
       15, 13, 12,     15, 14, 13,     // Front
       19, 17, 16,     19, 18, 17,	   // Right

       23, 21, 20,     23, 22, 21,	   // Top
    };

    #endregion

}
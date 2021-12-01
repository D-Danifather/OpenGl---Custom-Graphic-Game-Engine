using OpenGL;

public static class LightData
{
    private readonly static float ambientIntensity = 0.01f;
    private readonly static float diffuseIntensity = 1f;
    private readonly static float specularIntensity = 2f;
    private readonly static float hardness = 64f;

    private readonly static Vector3 lightPosition = new Vector3(0, 2, 2);
    private readonly static Vector3 viewPosition = new Vector3(0, 0, 0);
    private readonly static Vector3 ambientLightColor = new Vector3(0.75f, 0.75f, 1);
    private readonly static Vector3 lightColor = new Vector3(1, 0.75f, 0.5f);

    private static readonly Vector4[] Src = new Vector4[]
    {
            new Vector4(lightPosition, ambientIntensity),       //I:0
            new Vector4(ambientLightColor, diffuseIntensity),   //I:1
            new Vector4(lightColor, specularIntensity),         //I:2
            new Vector4(viewPosition, hardness)                 //I:3
    };

    public static Matrix4 GetLightData()
    {
        Matrix4 lightData = new Matrix4
        (
            Src[0], //lightPosition, ambientIntensity
            Src[1], //ambientLightColor, diffuseIntensity
            Src[2], //lightColor, specularIntensity
            Src[3]  //viewPosition, hardness
        );

        return lightData;
    }
}


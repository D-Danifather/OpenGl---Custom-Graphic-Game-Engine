namespace OpenGL.Mathematics
{
    public class Transform
    {
        #region Properties

        public Vector3 Position
        {
            get;
            set;
        } = Vector3.Zero;

        public Vector3 Scale
        {
            get;
            set;
        } = new Vector3(3, 3, 3);


        public Vector3 Rotation
        {
            get;
            set;
        } = Vector3.Zero;

        #endregion

        #region Properties

        public Matrix4 GetTRS()
        {
            Matrix4 modelTranslation = Matrix4.CreateTranslation(Position);
            Matrix4 modelRotationX = Matrix4.CreateRotation(new Vector3(1.0f, 0.0f, 0.0f), Mathf.ToRad(Rotation.X)); 
            Matrix4 modelRotationY = Matrix4.CreateRotation(new Vector3(0.0f, 1.0f, 0.0f), Mathf.ToRad(Rotation.Y)); 
            Matrix4 modelRotationZ = Matrix4.CreateRotation(new Vector3(0.0f, 0.0f, 1.0f), Mathf.ToRad(Rotation.Z)); 
            Matrix4 modelRotation = modelRotationX * modelRotationY * modelRotationZ; 
            Matrix4 modelScale = Matrix4.CreateScaling(Scale); 
            Matrix4 model = modelTranslation * modelRotation * modelScale; //Compose TRSmatr

            return model;
        }

        #endregion

    }
}

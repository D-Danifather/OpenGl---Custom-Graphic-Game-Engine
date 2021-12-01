namespace OpenGL.Game
{
   public class FPS_Camera
    {
        public static readonly float fov = 60f;

        public static float yaw = 0f;
        public static float NewVelocity = 10f;

        public static Vector3 Position;
        public static Vector3 Rotation;
        public static Vector3 Velocity = new Vector3(0, 2, 0);
    }
}
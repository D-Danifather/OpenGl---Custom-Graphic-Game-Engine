using OpenGL.Platform;

namespace OpenGL.Game
{
    public class Physic
    {
        public static Physic Instance = new Physic();

        public readonly float gravity = -9.8f;

        public bool gravityActive = true;

        private Physic()
        {
            if (Instance == null)
                Instance = this;
        }

        public void Update()
            => UpdatePhysic();

        private void UpdatePhysic()
        {
            if (gravityActive)
            {
                FPS_Camera.Position.Y -= gravity * Time.DeltaTime;

                if (FPS_Camera.Position.Y >= 0.0f)
                {
                    FPS_Camera.Position.Y = 0.0f;

                    Game.Instance.minJump = 0;
                }
            }
        }
    }
}
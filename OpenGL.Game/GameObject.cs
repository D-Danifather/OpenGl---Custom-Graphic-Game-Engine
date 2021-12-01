using OpenGL.Mathematics;
using OpenGL.Platform;

namespace OpenGL.Game
{
    public class GameObject
    {
        //--------------------------
        //          Public
        //--------------------------
        public Transform Transform = new Transform();

        public Vector3 color;
        public float specular;

        //--------------------------
        //        Protected
        //--------------------------
        protected string Name;
        protected MeshRenderer MeshRenderer;

        public GameObject(string name, MeshRenderer meshRenderer)
        {
            Name = name;
            MeshRenderer = meshRenderer;
            MeshRenderer.Parent = this;
        }

        public virtual void Update() { }

        internal void Commit() 
            => SetTransform();

        public void Render()
            => MeshRenderer.Render();
        
        private void SetTransform()
        {
            float r = Mathf.Sin(Time.TimeSinceStart * 10);

            Matrix4 view = Game.Instance.GetViewMatrix();
            Matrix4 projection = Game.Instance.GetProjectionMatrix();
            Matrix4 model = this.Transform.GetTRS();
            Matrix4 tangentToWorld = model.Inverse().Transpose();

            Material material = this.MeshRenderer.Material;

            material["projection"].SetValue(projection);
            material["view"].SetValue(view);
            material["model"].SetValue(model);
            material["color"].SetValue(color);
            material["specular"].SetValue(specular);
            material["tangentToWorld"]?.SetValue(tangentToWorld);
            material["light"].SetValue(LightData.GetLightData());
        }
    }
}

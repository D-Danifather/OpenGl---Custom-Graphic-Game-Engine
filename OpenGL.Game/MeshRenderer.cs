namespace OpenGL.Game
{
    public class MeshRenderer
    {
        public Material Material;

        private VAO Geometry;

        public MeshRenderer(Material material, VAO vAO)
        {
            Material = material;
            Geometry = vAO;
        }

        public GameObject Parent
        {
            get;
            internal set;
        }

        public virtual void Render()
        {
            Geometry.Program.Use();
            Parent.Commit();
            Geometry.Draw();
        }
    }
}

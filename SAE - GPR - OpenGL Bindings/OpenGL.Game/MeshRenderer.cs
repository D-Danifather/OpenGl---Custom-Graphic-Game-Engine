using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL.Game
{
    public class MeshRenderer
    {
        public Material Material;
        public VAO Geometry;

        public MeshRenderer(Material material, VAO vAO)
        {
            Material = material;
            Geometry = vAO;
        }

        public virtual void Render()
        {
            Geometry.Program.Use();
            Geometry.Draw();
        }
    }
}

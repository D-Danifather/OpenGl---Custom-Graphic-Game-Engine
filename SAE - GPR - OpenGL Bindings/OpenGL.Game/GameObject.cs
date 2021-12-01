using System;
using System.Threading.Tasks;
using OpenGL.Mathematics;

namespace OpenGL.Game
{
    public class GameObject
    {
        public string Name { get; set; }
        public Transform Transform = new Transform();
        public MeshRenderer Renderer { get; set; }

        public GameObject(string name, MeshRenderer meshRenderer)
        {
            Name = name;
            Renderer = meshRenderer;
        }

        public void Initialize()
        {

        }

        public void Update()
        {
            //Renderer.Render();
        }
    }
}

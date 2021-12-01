using System;
using System.Collections.Generic;

namespace OpenGL.Game
{
    public class Game
    {
        public Vector2 MouseRotation;

        public List<GameObject> SceneGraph { get; set; } = new List<GameObject>();

        public Game()
        {

        }

        public void Render()
        {
            foreach (GameObject gameObject in SceneGraph)
            {
                // Update gameObject
                //gameObject.Renderer.Render();
            }
        }

        public void Update()
        {
            foreach (GameObject gameObject in SceneGraph)
            {
                // Update gameObject
                gameObject.Update();
            }
        }
    }
}

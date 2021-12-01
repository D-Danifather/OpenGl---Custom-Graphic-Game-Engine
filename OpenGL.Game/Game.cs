using System;
using System.Collections.Generic;
using OpenGL.Mathematics;
using OpenGL.Platform;
using static OpenGL.GenericVAO;

namespace OpenGL.Game
{
    public class Game
    {
        //--------------------------
        //    Public & Singleton
        //--------------------------
        public static Game Instance = new Game();

        public static int screenWidth = 800;
        public static int screenHeight = 600;

        public readonly static List<GameObject> SceneGraph = new List<GameObject>();

        public int minJump = 0;
        public int maxJump = 2;

        public static Vector3 MouseRotation;

        public bool IsInitialized { get; private set; }
        public bool canJump = true;
        public bool pause = true;

        // Add Material
        public static Material material_Color;

        //--------------------------
        //          Private
        //--------------------------
        private Game()
        {
            if (Instance == null)
                Instance = this;
        }

        private readonly static float movementSpeed = 7.5f;
        private readonly static float jumpPower = 15f;        

        private static float newXpos;
        private static float newZpos;

        private static Vector3 direction;

        //--------------------------
        //     Update & Render
        //--------------------------
        public void Update()
        {
            for (int i = 0; i < SceneGraph.Count; i++)
            {
                SceneGraph[i].Update();
            }
        }

        public void Render()
        {
            for (int i = 0; i < SceneGraph.Count; i++)
            {
                SceneGraph[i].Render();
            }
        }

        //--------------------------
        // Create Game Object Methode
        //--------------------------
        #region Create Game Object

        private static GameObject CreateGameObject(string _name, Vector3 _colorRGB, Vector3[] _vertices, uint[] _indices, Vector2[] _uvs, Vector3[] _colorMask, Vector3[] _notmals, int _materialIndex, float _specular)
        {
            if (!Instance.IsInitialized)
                throw new Exception("Game not initialized!");

            List<IGenericVBO> vbos = new List<IGenericVBO>();
            vbos.Add(new GenericVBO<Vector3>(new VBO<Vector3>(_vertices), "in_position"));
            vbos.Add(new GenericVBO<Vector3>(new VBO<Vector3>(_colorMask), "in_color"));
            vbos.Add(new GenericVBO<Vector2>(new VBO<Vector2>(_uvs), "in_texcoords"));
            vbos.Add(new GenericVBO<Vector3>(new VBO<Vector3>(_notmals), "in_normal"));
            vbos.Add(new GenericVBO<uint>(new VBO<uint>(_indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.DynamicRead)));

            GameObject obj;

            if (_materialIndex == 0)
            {
                var vao = new VAO(material_Color, vbos.ToArray());
                obj = new GameObject(_name, new MeshRenderer(material_Color, vao));
                obj.color = _colorRGB;
                obj.specular = _specular;
                
                return obj;
            }
            else
                return null;
        }

        #endregion

        //--------------------------
        //      Transformation
        //--------------------------
        #region Transformation

        public Matrix4 GetProjectionMatrix()
        {
            float aspectRatio = (float)screenWidth / (float)screenHeight;
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(Mathf.ToRad(FPS_Camera.fov), aspectRatio, 0.1f, 1000f);

            return projection;
        }

        public Matrix4 GetViewMatrix()
        {
            Matrix4 viewTranslation = Matrix4.Identity;
            Matrix4 viewRotation = Matrix4.Identity;
            Matrix4 viewScale = Matrix4.Identity;

            viewTranslation = Matrix4.CreateTranslation(new Vector3(FPS_Camera.Position.X, FPS_Camera.Position.Y, FPS_Camera.Position.Z));
            viewRotation = Matrix4.CreateRotation(new Vector3(0,1,0), Rotate());
            viewScale = Matrix4.CreateScaling(new Vector3(1.0f, 1.0f, 1.0f));

            Matrix4 view = viewRotation * viewTranslation * viewScale;// RTS matrix -> scale, rotate then translate -> All applied in LOCAL Coordinates

            return view;
        }

        #endregion

        //--------------------------
        //          Awake
        //--------------------------
        public void Awake()
        {
            material_Color = Material.Create("shaders\\vert.vs", "shaders\\frag.fs");

            IsInitialized = true;
        }

        //--------------------------
        //     Movement & Jump
        //--------------------------
        #region Movement + Jump

        public Vector3 MoveForward()
        {
            newXpos = (float)Math.Sin(FPS_Camera.Rotation.X) * movementSpeed;
            newZpos = (float)Math.Cos(FPS_Camera.Rotation.X) * movementSpeed;
            direction = new Vector3(newXpos, 0.0f, newZpos);

            return direction;
        }

        public Vector3 MoveBackward()
        {
            newXpos = (float)Math.Sin(FPS_Camera.Rotation.X) * movementSpeed;
            newZpos = (float)Math.Cos(FPS_Camera.Rotation.X) * movementSpeed;
            direction = new Vector3(newXpos, 0.0f, newZpos);

            return direction;
        }

        public Vector3 MoveLeft()
        {
            newXpos = (float)Math.Sin(FPS_Camera.Rotation.X + Mathf.ToRad(90f)) * movementSpeed;
            newZpos = (float)Math.Cos(FPS_Camera.Rotation.X + Mathf.ToRad(90f)) * movementSpeed;
            direction = new Vector3(newXpos, 0.0f, newZpos);

            return direction;
        }

        public Vector3 MoveRight()
        {
            newXpos = (float)Math.Sin(FPS_Camera.Rotation.X - Mathf.ToRad(270f)) * movementSpeed;
            newZpos = (float)Math.Cos(FPS_Camera.Rotation.X - Mathf.ToRad(270f)) * movementSpeed;
            direction = new Vector3(newXpos, 0.0f, newZpos);

            return direction;
        }

        public float Rotate()
        {
            if (FPS_Camera.Rotation.X > 2 * (float)Math.PI)
                FPS_Camera.Rotation.X -= 2 * (float)Math.PI;

            if (FPS_Camera.Rotation.X < 0)
                FPS_Camera.Rotation.X += 2 * (float)Math.PI;

            return FPS_Camera.Rotation.X;
        }

        public float Jump()
            => FPS_Camera.Position.Y -= (float)Math.Sqrt(jumpPower * 100 * Time.DeltaTime);

        #endregion
    }
}

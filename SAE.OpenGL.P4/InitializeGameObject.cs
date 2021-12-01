using System;
using System.Collections.Generic;
using OpenGL;
using OpenGL.Game;
using OpenGL.Platform;
using static OpenGL.GenericVAO;

namespace SAE.GPR.Summativ.Daniyal
{
    public class InitializeGameObject : GameObject
    {
        //--------------------------
        //   Public & Inheritance
        //--------------------------
        public InitializeGameObject(string name, MeshRenderer meshRenderer) : base(name, meshRenderer) { }

        //--------------------------
        //         Private
        //--------------------------
        private float startTime = 0;

        private bool move = true;
        private bool oMove = false;

        public override void Update()
        { 
            base.Update();

            if (Name == "blue")
                Transform.Rotation += new Vector3(0, -1, 0) * Time.DeltaTime * 20;

            if (Name == "green")
                Transform.Rotation += new Vector3(0, -1, 0) * Time.DeltaTime * 20;

            if (Name == "yellow")
                Transform.Rotation += new Vector3(0, -1, 0) * Time.DeltaTime * 20;

            if (Name == "red")
                Transform.Rotation += new Vector3(0, -1, 0) * Time.DeltaTime * 20;

            if (Name == "default")
            {
                Transform.Rotation += new Vector3(0, -1, 0) * Time.DeltaTime * 20;
                StartMovementCoroutine(new Vector3(0, 1, 0), 5f, 10f, -10f, Transform.Position.Y, 0);
            }

            if (Name == "fullspec")
                Transform.Rotation += new Vector3(0, -1, 0) * Time.DeltaTime * 20;

            if (Name == "halfspec")
                Transform.Rotation += new Vector3(0, -1, 0) * Time.DeltaTime * 20;

            if (Name == "ground")
                StartMovementCoroutine(new Vector3(1, 0, 0), 20f, 60f, -60f, Transform.Position.X, 3f);

            if (Name == "blueTop")
                Transform.Rotation += new Vector3(0, -1, 0) * Time.DeltaTime * 20;

            if (Name == "greenTop")
                Transform.Rotation += new Vector3(0, -1, 0) * Time.DeltaTime * 20;

            if (Name == "yellowTop")
                Transform.Rotation += new Vector3(0, -1, 0) * Time.DeltaTime * 20;

            if (Name == "redTop")
                Transform.Rotation += new Vector3(0, -1, 0) * Time.DeltaTime * 20;

            if (Name == "defaultTop")
            {
                Transform.Rotation += new Vector3(0, -1, 0) * Time.DeltaTime * 20;
                StartMovementCoroutine(new Vector3(0, 1, 0), 5f, 10f, -10f, Transform.Position.Y, 0);
            }

            if (Name == "fullspecTop")
                Transform.Rotation += new Vector3(0, -1, 0) * Time.DeltaTime * 20;

            if (Name == "halfspecTop")
                Transform.Rotation += new Vector3(0, -1, 0) * Time.DeltaTime * 20;
        }

        //--------------------------
        // Create Game Object + add to Update and Rendering List
        //--------------------------
        #region Create Game Object

        /// <summary>
        /// Add every Game Object to Update list & create it
        /// Make sure the Methode works with all Parameters thats needed
        /// To Create a Game Object use directly the |--> CreateGameObject(...) <--| 
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_colorRGB"></param>
        /// <param name="_vertices"></param>
        /// <param name="_indices"></param>
        /// <param name="_uvs"></param>
        /// <param name="_colorMask"></param>
        /// <param name="_notmals"></param>
        /// <param name="_materialIndex"></param>
        /// <param name="_specular"></param>
        /// <returns></returns>
        private static InitializeGameObject CreateGameObject(string _name, Vector3 _colorRGB, Vector3[] _vertices, uint[] _indices, Vector2[] _uvs, Vector3[] _colorMask, Vector3[] _notmals, int _materialIndex, float _specular)
        {
            if (!Game.Instance.IsInitialized)
                throw new Exception("Game not initialized!");

            List<IGenericVBO> vbos = new List<IGenericVBO>();
            vbos.Add(new GenericVBO<Vector3>(new VBO<Vector3>(_vertices), "in_position"));
            vbos.Add(new GenericVBO<Vector3>(new VBO<Vector3>(_colorMask), "in_color"));
            vbos.Add(new GenericVBO<Vector2>(new VBO<Vector2>(_uvs), "in_texcoords"));
            vbos.Add(new GenericVBO<Vector3>(new VBO<Vector3>(_notmals), "in_normal"));
            vbos.Add(new GenericVBO<uint>(new VBO<uint>(_indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.DynamicRead)));

            InitializeGameObject obj;

            if (_materialIndex == 0)
            {
                var vao = new VAO(Game.material_Color, vbos.ToArray());
                obj = new InitializeGameObject(_name, new MeshRenderer(Game.material_Color, vao));
                obj.color = _colorRGB;
                obj.specular = _specular;
                Game.SceneGraph.Add(obj);
                return obj;
            }
            else
                return null;
        }

        #endregion

        //--------------------------
        // Create and give Info and Datas for each Game Object
        //--------------------------
        #region Create every Game Objects with Data and Infos

        public static void CreateAllGameObjects()
        {
            GameObject rednCube = CreateGameObject("red", new Vector3(1f, 0f, 0f), GeometryData.vertices, GeometryData.indices, GeometryData.uvs, GeometryData.colors, GeometryData.normals, 0, 1f);
            rednCube.Transform.Position = new Vector3(-9f, 0f, -10f);
            rednCube.Transform.Scale = new Vector3(3f, 3f, 3f);

            GameObject greenCube = CreateGameObject("green", new Vector3(0f, 1f, 0f), GeometryData.vertices, GeometryData.indices, GeometryData.uvs, GeometryData.colors, GeometryData.normals, 0, .85f);
            greenCube.Transform.Position = new Vector3(-4f, 0f, -10f);
            greenCube.Transform.Scale = new Vector3(3f, 3f, 3f);

            GameObject blueCube = CreateGameObject("blue", new Vector3(0f, 0f, 1f), GeometryData.vertices, GeometryData.indices, GeometryData.uvs, GeometryData.colors, GeometryData.normals, 0, .75f);
            blueCube.Transform.Position = new Vector3(4f, 0f, -10f);
            blueCube.Transform.Scale = new Vector3(3f, 3f, 3f);

            GameObject yellowCube = CreateGameObject("yellow", new Vector3(1f, 1f, 0f), GeometryData.vertices, GeometryData.indices, GeometryData.uvs, GeometryData.colors, GeometryData.normals, 0, .65f);
            yellowCube.Transform.Position = new Vector3(8f, 0f, -10f);
            yellowCube.Transform.Scale = new Vector3(3f, 3f, 3f);

            GameObject defCube = CreateGameObject("default", new Vector3(1f, 1f, 1f), GeometryData.vertices, GeometryData.indices, GeometryData.uvs, GeometryData.colors, GeometryData.normals, 0, .5f);
            defCube.Transform.Position = new Vector3(0f, 0f, -10f);
            defCube.Transform.Scale = new Vector3(3f, 3f, 3f);

            GameObject ground = CreateGameObject("ground", new Vector3(0f, 1f, 0f), GeometryData.vertices, GeometryData.indices, GeometryData.uvs, GeometryData.colors, GeometryData.normals, 0, .4f);
            ground.Transform.Position = new Vector3(0f, -5f, 0);
            ground.Transform.Scale = new Vector3(30f, 0.1f, 30f);

            GameObject fullSpec = CreateGameObject("fullspec", new Vector3(1f, 1f, 1f), GeometryData.vertices, GeometryData.indices, GeometryData.uvs, GeometryData.colors, GeometryData.normals, 0, .2f);
            fullSpec.Transform.Position = new Vector3(12, 0, -10);
            fullSpec.Transform.Scale = new Vector3(3, 3, 3);

            GameObject halfSpec = CreateGameObject("halfspec", new Vector3(1, 1, 1), GeometryData.vertices, GeometryData.indices, GeometryData.uvs, GeometryData.colors, GeometryData.normals, 0, .000001f);
            halfSpec.Transform.Position = new Vector3(18, 0, -10);
            halfSpec.Transform.Scale = new Vector3(3, 3, 3);

            GameObject rednCubeTop = CreateGameObject("redTop", new Vector3(1f, 0f, 0f), GeometryData.vertices, GeometryData.indices, GeometryData.uvs, GeometryData.colors, GeometryData.normals, 0, 1f);
            rednCubeTop.Transform.Position = new Vector3(-9f, 5, -10f);
            rednCubeTop.Transform.Scale = new Vector3(3f, 3f, 3f);

            GameObject greenCubeTop = CreateGameObject("greenTop", new Vector3(0f, 1f, 0f), GeometryData.vertices, GeometryData.indices, GeometryData.uvs, GeometryData.colors, GeometryData.normals, 0, 1f);
            greenCubeTop.Transform.Position = new Vector3(-4f, 5, -10f);
            greenCubeTop.Transform.Scale = new Vector3(3f, 3f, 3f);

            GameObject blueCubeTop = CreateGameObject("blueTop", new Vector3(0f, 0f, 1f), GeometryData.vertices, GeometryData.indices, GeometryData.uvs, GeometryData.colors, GeometryData.normals, 0, 1f);
            blueCubeTop.Transform.Position = new Vector3(4f, 5, -10f);
            blueCubeTop.Transform.Scale = new Vector3(3f, 3f, 3f);

            GameObject yellowCubeTop = CreateGameObject("yellowTop", new Vector3(1f, 1f, 0f), GeometryData.vertices, GeometryData.indices, GeometryData.uvs, GeometryData.colors, GeometryData.normals, 0, 1f);
            yellowCubeTop.Transform.Position = new Vector3(8f, 5, -10f);
            yellowCubeTop.Transform.Scale = new Vector3(3f, 3f, 3f);

            GameObject defCubeTop = CreateGameObject("defaultTop", new Vector3(1f, 1f, 1f), GeometryData.vertices, GeometryData.indices, GeometryData.uvs, GeometryData.colors, GeometryData.normals, 0, 1f);
            defCubeTop.Transform.Position = new Vector3(0f, 5, -10f);
            defCubeTop.Transform.Scale = new Vector3(3f, 3f, 3f);

            GameObject fullSpecTop = CreateGameObject("fullspecTop", new Vector3(1f, 1f, 1f), GeometryData.vertices, GeometryData.indices, GeometryData.uvs, GeometryData.colors, GeometryData.normals, 0, 1f);
            fullSpecTop.Transform.Position = new Vector3(12, 5, -10);
            fullSpecTop.Transform.Scale = new Vector3(3, 3, 3);

            GameObject halfSpecTop = CreateGameObject("halfspecTop", new Vector3(1, 1, 1), GeometryData.vertices, GeometryData.indices, GeometryData.uvs, GeometryData.colors, GeometryData.normals, 0, 1f);
            halfSpecTop.Transform.Position = new Vector3(18, 5, -10);
            halfSpecTop.Transform.Scale = new Vector3(3, 3, 3);
        }

        #endregion

        //--------------------------
        // StartMovgementCoroutine - Methode
        //--------------------------
        #region StartCoroutine

        /// <summary>
        /// Create a Coroutine Methode for movig platform in each direction
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        /// <param name="to"></param>
        /// <param name="back"></param>
        /// <param name="transformPos"></param>
        /// <param name="waitForSeconds"></param>
        private void StartMovementCoroutine(Vector3 direction, float speed, float to, float back, float transformPos, float waitForSeconds)
        {
            if (move)
                Transform.Position += direction * Time.DeltaTime * speed;
            else if (oMove)
                Transform.Position -= direction * Time.DeltaTime * speed;
            if (transformPos > to)
            {
                startTime += Time.DeltaTime;
                move = false;
                if (startTime >= waitForSeconds)
                {
                    startTime -= waitForSeconds;
                    oMove = true;
                }
            }
            else if (transformPos < back)
            {
                startTime += Time.DeltaTime;
                oMove = false;
                if (startTime >= waitForSeconds)
                {
                    startTime -= waitForSeconds;
                    move = true;
                }
            }
        }

        #endregion
    }
}


using OpenGL;
using OpenGL.Mathematics;
using OpenGL.Platform;
using OpenGL.Game;
using System.Windows.Forms;
using System;
using OpenGL.UI;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace SAE.GPR.P4
{
    static class Program
    {
        private static int screenWidth = 800;
        private static int screenHeight = 600;

        // Instance random class for randomize
        private static readonly Random random = new Random();

        //TODO: Create game instance
        private static Game Game = new Game();

        // Create a camera Transform for FPS
        private static Transform FPS = new Transform();

        // Define different gameobject types
        //private static GameObject rectangleGO, triangleGO, cubeGO, pyramidGO;

        static void Main()
        {


            Time.Initialize();
            Window.CreateWindow("OpenGL SAE Sumative Test | ????? |", 800, 600);

            // add a reshape callback to update the UI
            Window.OnReshapeCallbacks.Add(OnResize);

            // add a close callback to make sure we dispose of everythng properly
            Window.OnCloseCallbacks.Add(OnClose);

            // Enable depth testing to ensure correct z-ordering of our fragments
            Gl.Enable(EnableCap.DepthTest);
            Gl.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            //**********************************************************\\ To Fill or Draw or Point
            Gl.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            Gl.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            //Gl.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Point);

            int randomCubes = random.Next(50, 100);
            for (int i = 0; i < randomCubes; i++)
            {
                GameObject gameObject = Cube();

                // Add to scene
                gameObject.Transform.Position = new Vector3(random.Next(-30, 30), 0, random.Next(-30, -30));
                gameObject.Transform.Rotation = Vector3.Zero;
                gameObject.Transform.Scale = new Vector3(random.Next(2, 4), random.Next(2, 4), random.Next(2, 4));
            }

            int randomPyramids = random.Next(50, 100);
            for (int i = 0; i < randomPyramids; i++)
            {
                GameObject gameObject = Pyramid();

                // Add to scene
                gameObject.Transform.Position = new Vector3(random.Next(-35, 35), 0, random.Next(-35, -35));
                gameObject.Transform.Rotation = Vector3.Zero;
                gameObject.Transform.Scale = new Vector3(random.Next(2, 4), random.Next(1, 4), random.Next(1, 4));
            }

            int starNumbers = random.Next(50, 100);
            for (int i = 0; i < starNumbers; i++)
            {
                GameObject gameObject = Stars();

                // Add to scene
                gameObject.Transform.Position = new Vector3(random.Next(-500, 500), random.Next(100, 400), random.Next(-300, 100));
                gameObject.Transform.Rotation = Vector3.Zero;
                gameObject.Transform.Scale = new Vector3(0.75f, 0.75f, 0.75f);
            }

            // Add Ground
            GameObject gameObjectGround = Ground();
            // Add to scene
            gameObjectGround.Transform.Position = new Vector3(0, -1.5f, 0);
            gameObjectGround.Transform.Rotation = Vector3.Zero;
            gameObjectGround.Transform.Scale = new Vector3(300, 0, 300);



            // Hook to the escape press event using the OpenGL.UI class library
            Input.Subscribe((char)Keys.Escape, Window.OnClose);

            Event evt = new Event(new OpenGL.Platform.Event.KeyEvent(OnKeyStateChanged));

            Input.Subscribe((char)Key.W, evt);
            Input.Subscribe((char)Key.S, evt);
            Input.Subscribe((char)Key.D, evt);
            Input.Subscribe((char)Key.A, evt);
            Input.Subscribe((char)Key.Space, evt);
            Input.Subscribe((char)Key.C, evt);
            Input.Subscribe((char)Key.Up, evt);
            Input.Subscribe((char)Key.Down, evt);
            Input.Subscribe((char)Key.Right, evt);
            Input.Subscribe((char)Key.Left, evt);

            //Input.MouseLeftClick = new Event(new Event.MouseEvent(OnMouseClick));

            // Make sure to set up mouse event handlers for the window
            Window.OnMouseCallbacks.Add(OpenGL.UI.UserInterface.OnMouseClick);

            Window.OnMouseMoveCallbacks.Add(OnMouseMove);

            StringInputs();

            // Game loop
            while (Window.Open)
            {
                Window.HandleInput();

                OnPreRenderFrame();

                FPS.Rotation = new Vector3(0, Game.MouseRotation.X, 0);

                //TODO: Execute SetTransform(...) on game objec               
                if (Game.SceneGraph.Count != 0)
                {
                    for (int i = 0; i <= Game.SceneGraph.Count - 1; i++)
                    {
                        GameObject gameObject = Game.SceneGraph[i];
                        SetTransform(gameObject, FPS);
                        gameObject.Renderer.Render();
                    }
                }

                // Update Game
                Game.Update();

                // Render Game
                Game.Render();

                OnPostRenderFrame();

                Time.Update();
            }
        }

        private static void StringInputs()
        {
            System.Console.WriteLine(" Hi there\n" +
                " Welcome to my litlle FPS-Simulation Game");
            System.Console.WriteLine(" Here are all Game Key Inputs:\n" +
                " --------------------------------------------------------\n" +
                " Translation\n" +
                "   - Forward = W\n" +
                "   - Back = S\n" +
                "   - Right = D\n" +
                "   - Left = A\n" +
                "   - Up = Space\n" +
                "   - Down = C\n" +
                " ---------------------\n" +
                " Rotation\n" +
                "   - Up = Up\n" +
                "   - Down = Down\n" +
                "   - Right = Right\n" +
                "   - Left = Left\n" +
                " --------------------------------------------------------");
            System.Console.WriteLine(" I hope you enjoyed it :)");
        }

        private static void OnKeyStateChanged(char c, bool pressed)
        {
            float speed = 50f;
            float jumpHeight = 25f;
            float rotateSpeed = 250f;
            Vector3 Vector3Forward = new Vector3(0, 0, 1) * speed * Time.DeltaTime;
            Vector3 Vector3Right = new Vector3(-1, 0, 0) * speed * Time.DeltaTime;
            Vector3 vector3Jump = new Vector3(0, -1f, 0) * jumpHeight * Time.DeltaTime;
            Vector3 vector3RotateX = new Vector3(1, 0, 0) * rotateSpeed * Time.DeltaTime;
            Vector3 vector3RotateY = new Vector3(0, 1, 0) * rotateSpeed * Time.DeltaTime;

            Key key = (Key)c;

            if (pressed)
            {
                // On Key pressed
                if (key == Key.W)
                    FPS.Position += Vector3Forward;
                else if (key == Key.S)
                    FPS.Position += -Vector3Forward;
                else if (key == Key.D)
                    FPS.Position += Vector3Right;
                else if (key == Key.A)
                    FPS.Position += -Vector3Right;
                else if (key == Key.Space)
                    FPS.Position += vector3Jump;
                else if (key == Key.C)
                    FPS.Position -= vector3Jump;
                else if (key == Key.Up)
                    FPS.Rotation += vector3RotateX;
                else if (key == Key.Down)
                    FPS.Rotation -= vector3RotateX;
                else if (key == Key.Right)
                    FPS.Rotation -= vector3RotateY;
                else if (key == Key.Left)
                    FPS.Rotation += vector3RotateY;
            }
        }

        private static Vector3[] verticesRectangle =
        {
                new Vector3(-0.5f, 0.5f, 0.0f),
                new Vector3(0.5f, 0.5f, 0.0f),
                new Vector3(0.5f, -0.5f, 0.0f),
                new Vector3(-0.5f, -0.5f, 0.0f)
        };
        private static uint[] indicesRectangle =
        {
                0, 3, 1,
                1, 3, 2
        };
        private static GameObject Ground()
        {
            Material materialGround = Material.Create("shaders\\vert.vs", "shaders\\frag.fs");
            materialGround["color"].SetValue(new Vector3(255, 255, 255) / 255);

            var ground = new VAO(materialGround, new VBO<Vector3>(verticesRectangle), new VBO<uint>(indicesRectangle,
            BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
            GameObject groundGO = new GameObject("Ground", new MeshRenderer(materialGround, ground));
            Game.SceneGraph.Add(groundGO);

            return groundGO;
        }

        private static Vector3[] verticesTriangle =
        {
                new Vector3(0.0f, 0.5f, 0.0f),
                new Vector3(0.5f, -0.5f, 0.0f),
                new Vector3(-0.5f, -0.5f, 0.0f)
        };
        private static uint[] indicesTriangle =
        {
                0, 2, 1
        };

        private static Vector3[] verticesCube =
        {
                // Z-position has to be changed to align with sketch

                //Front face
                new Vector3(-0.5f, -0.5f, 0.5f),   // Index 0 on Sketch
                new Vector3(0.5f, -0.5f, 0.5f),  // Index 1 on Sketch
                new Vector3(0.5f, 0.5f, 0.5f), // Index 2 on Sketch
                new Vector3(-0.5f, 0.5f, 0.5f),  // Index 3 on Sketch

                //Right face
                new Vector3(0.5f, -0.5f, 0.5f), // Index 1 on Sketch
                new Vector3(0.5f, -0.5f, -0.5f),  // Index 5 on Sketch
                new Vector3(0.5f, 0.5f, -0.5f),   // Index 6 on Sketch
                new Vector3(0.5f, 0.5f, 0.5f),   // Index 2 on Sketch

                //Left face
                new Vector3(-0.5f, -0.5f, -0.5f), // Index 4 on Sketch
                new Vector3(-0.5f, -0.5f, 0.5f),  // Index 0 on Sketch
                new Vector3(-0.5f, 0.5f, 0.5f),   // Index 3 on Sketch
                new Vector3(-0.5f, 0.5f, -0.5f),   // Index 7 on Sketch
                
                //Bottom face
                new Vector3(-0.5f, -0.5f, -0.5f), // Index 4 on Sketch
                new Vector3(0.5f, -0.5f, -0.5f),  // Index 5 on Sketch
                new Vector3(0.5f, -0.5f, 0.5f),   // Index 1 on Sketch
                new Vector3(-0.5f, -0.5f, 0.5f),   // Index 0 on Sketch

                //Top face
                new Vector3(-0.5f, 0.5f, 0.5f), // Index 3 on Sketch
                new Vector3(0.5f, 0.5f, 0.5f),  // Index 2 on Sketch
                new Vector3(0.5f, 0.5f, -0.5f),   // Index 6 on Sketch
                new Vector3(-0.5f, 0.5f, -0.5f),   // Index 7 on Sketch
                
                //Back face
                new Vector3(0.5f, -0.5f, -0.5f), // Index 5 on Sketch
                new Vector3(-0.5f, -0.5f, -0.5f),  // Index 4 on Sketch
                new Vector3(-0.5f, 0.5f, -0.5f),   // Index 7 on Sketch
                new Vector3(0.5f, 0.5f, -0.5f)   // Index 6 on Sketch
        };
        private static uint[] indicesCube =
        {
                0, 1, 2,
                2, 3, 0,

                4, 5, 6,
                6, 7, 4,

                8, 9, 10,
                10, 11, 8,

                12, 13, 14,
                14, 15, 12,

                16, 17, 18,
                18, 19, 16,

                20, 21, 22,
                22, 23, 20
        };
        private static GameObject Cube()
        {
            Material materialCube = Material.Create("shaders\\vert.vs", "shaders\\frag.fs");
            materialCube["color"].SetValue(new Vector3(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)) / 255);

            var cube = new VAO(materialCube, new VBO<Vector3>(verticesCube), new VBO<uint>(indicesCube,
            BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
            GameObject cubes = new GameObject("Cube", new MeshRenderer(materialCube, cube));
            Game.SceneGraph.Add(cubes);

            return cubes;
        }

        private static Vector3[] verticesPyramid =
        {
                new Vector3(-0.5f, -0.5f, -0.5f),
                new Vector3(0.5f, -0.5f, -0.5f),
                new Vector3(0.5f, -0.5f, 0.5f),
                new Vector3(-0.5f, -0.5f, 0.5f),
                new Vector3(0.0f, 0.5f, 0.0f)
        };
        private static uint[] indicesPyramid =
        {
                0, 3, 2,
                0, 2, 1,
                0, 1, 4,
                1, 2, 4,
                2, 3, 4,
                3, 0, 4
        };
        private static GameObject Pyramid()
        {
            Material materialPyramid = Material.Create("shaders\\vert.vs", "shaders\\frag.fs");
            materialPyramid["color"].SetValue(new Vector3(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)) / 255);

            var pyramid = new VAO(materialPyramid, new VBO<Vector3>(verticesPyramid), new VBO<uint>(indicesPyramid,
            BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
            GameObject pyramids = new GameObject("Pyramid", new MeshRenderer(materialPyramid, pyramid));
            Game.SceneGraph.Add(pyramids);

            return pyramids;
        }
        private static GameObject Stars()
        {
            Material materialCube = Material.Create("shaders\\vert.vs", "shaders\\frag.fs");
            materialCube["color"].SetValue(new Vector3(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)) / 255);

            var star = new VAO(materialCube, new VBO<Vector3>(verticesPyramid), new VBO<uint>(indicesPyramid,
            BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
            GameObject stars = new GameObject("Star", new MeshRenderer(materialCube, star));
            Game.SceneGraph.Add(stars);

            return stars;
        }

        #region Transformation

        // TODO: Add GameObject obj parameter
        private static void SetTransform(GameObject obj, Transform cameraFPS)
        {
            // TODO: Uncomment code below

            float r = Mathf.Sin(Time.TimeSinceStart * 10);

            Matrix4 view = GetViewMatrix(cameraFPS);
            Matrix4 projection = GetProjectionMatrix();

            //--------------------------
            // Data passing to shader
            //--------------------------
            Material material = obj.Renderer.Material;

            material["projection"].SetValue(projection);
            material["view"].SetValue(view);
            material["model"].SetValue(obj.Transform.GetTRS());
        }

        private static Matrix4 GetProjectionMatrix()
        {
            float fov = 60;

            float aspectRatio = (float)screenWidth / (float)screenHeight;
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(Mathf.ToRad(fov), aspectRatio, 0.1f, 1000f);
            //Matrix4 projection = Matrix4.CreateOrthographic(aspectRatio, 0.1f, 1000.0f);

            return projection;
        }

        private static Matrix4 GetViewMatrix(Transform cameraFPS)
        {
            Matrix4 viewTranslation = Matrix4.Identity;
            Matrix4 viewRotation = Matrix4.Identity;
            Matrix4 viewScale = Matrix4.Identity;

            viewTranslation = Matrix4.CreateTranslation(new Vector3(cameraFPS.Position.X, cameraFPS.Position.Y, cameraFPS.Position.Z));
            viewRotation = Matrix4.CreateRotation(new Vector3(0, cameraFPS.Rotation.Y, 0), Mathf.ToRad(0.1f));
            // For Perspective
            viewScale = Matrix4.CreateScaling(new Vector3(1.0f, 1.0f, 1.0f));
            // For Orthogonal
            //viewScale = Matrix4.CreateScaling(new Vector3(50.0f, 50.0f, 50.0f));

            //Matrix4 view = viewTranslation * viewRotation * viewScale;// TRS matrix -> scale, rotate then translate -> All applied in WORLD Coordinates
            Matrix4 view = viewRotation * viewTranslation * viewScale;// RTS matrix -> scale, rotate then translate -> All applied in LOCAL Coordinates
            //Matrix4 view = viewScale * viewRotation * viewTranslation;
            //Matrix4 view = viewTranslation * viewScale  * viewRotation;// TRS matrix -> scale, rotate then translate -> All applied in WORLD Coordinates


            return view;
        }

        #endregion

        #region Callbacks

        private static void OnResize()
        {
            screenWidth = Window.Width;
            screenHeight = Window.Height;

            OpenGL.UI.UserInterface.OnResize(screenWidth, screenHeight);
        }

        private static void OnClose()
        {
            // make sure to dispose of everything
            OpenGL.UI.UserInterface.Dispose();
            OpenGL.UI.BMFont.Dispose();
        }

        private static void OnPreRenderFrame()
        {
            // set up the OpenGL viewport and clear both the color and depth bits
            Gl.Viewport(0, 0, Window.Width, Window.Height);
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        private static void OnPostRenderFrame()
        {
            // Draw the user interface after everything else
            OpenGL.UI.UserInterface.Draw();

            // Swap the back buffer to the front so that the screen displays
            Window.SwapBuffers();
        }

        private static void OnMouseClick(int button, int state, int x, int y)
        {
            // take care of mapping the Glut buttons to the UI enums
            if (!OpenGL.UI.UserInterface.OnMouseClick(button + 1, (state == 0 ? 1 : 0), x, y))
            {
                // do other picking code here if necessary
            }
        }

        private static bool OnMouseMove(int x, int y)
        {
            float cameraSpeed = 50;

            if (!OpenGL.UI.UserInterface.OnMouseMove(x, y))
            {
                Game.MouseRotation.X = x;
                Game.MouseRotation.Y = y;

                //// do other picking code here if necessary
                System.Console.WriteLine("Camera Pos: " + x + ", " + y);

            }

            return false;
        }

        #endregion
    }
}

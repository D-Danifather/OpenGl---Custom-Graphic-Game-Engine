using OpenGL;
using OpenGL.Platform;
using OpenGL.Game;
using OpenGL.UI;
using System.Windows.Forms;

namespace SAE.GPR.Summativ.Daniyal
{
    public class UpdateProgram
    {
        public static UpdateProgram Instance = new UpdateProgram();

        private UpdateProgram()
        {
            if (Instance == null)
                Instance = this;
        }

        public void InitializeMain()
        {
            Time.Initialize();
            Window.CreateWindow("OpenGL - SAE - Summative - S1 | Daniyal |", 800, 600);

            Window.OnReshapeCallbacks.Add(OnResize);

            Window.OnCloseCallbacks.Add(OnClose);

            Gl.Enable(EnableCap.DepthTest);
            Gl.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            Gl.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
        }

        public void InitializeTexture()
        {
            var crateTexture = new Texture("textures/crate.jpg");
            Gl.ActiveTexture(0);
            Gl.BindTexture(crateTexture);

            Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
            TextureParameter.Nearest);

            Gl.Enable(EnableCap.CullFace);
            Gl.CullFace(CullFaceMode.Back);
        }

        public void CreateGameObjects()
            => InitializeGameObject.CreateAllGameObjects();

        public void AddInputKeyAndMouse()
        {
            // Hook to the escape press event using the OpenGL.UI class library
            Input.Subscribe((char)Keys.Escape, Window.OnClose);

            Event evt = new Event(new Event.KeyEvent(OnKeyStateChanged));

            Input.Subscribe((char)Key.W, evt);
            Input.Subscribe((char)Key.S, evt);
            Input.Subscribe((char)Key.D, evt);
            Input.Subscribe((char)Key.A, evt);
            Input.Subscribe((char)Key.Space, evt);
            Input.Subscribe((char)Key.Q, evt);
            Input.Subscribe((char)Key.E, evt);
            Input.Subscribe((char)Key.C, evt);
            Input.Subscribe((char)Key.P, evt);
            Input.Subscribe((char)Key.Up, evt);
            Input.Subscribe((char)Key.Down, evt);
            Input.Subscribe((char)Key.Right, evt);
            Input.Subscribe((char)Key.Left, evt);

            // Make sure to set up mouse event handlers for the window
            Window.OnMouseCallbacks.Add(UserInterface.OnMouseClick);

            Window.OnMouseMoveCallbacks.Add(OnMouseMove);
        }

        public void OnKeyStateChanged(char c, bool pressed)
        {
            Key key = (Key)c;

            if (key == Key.W)
            {
                if (pressed)
                    GameInputs.W = true;
                else
                    GameInputs.W = false;
            }

            else if (key == Key.S)
            {
                if (pressed)
                    GameInputs.S = true;
                else
                    GameInputs.S = false;
            }

            else if (key == Key.D)
            {
                if (pressed)
                    GameInputs.D = true;
                else
                    GameInputs.D = false;
            }

            else if (key == Key.A)
            {
                if (pressed)
                    GameInputs.A = true;
                else
                    GameInputs.A = false;
            }
            else if (key == Key.Space)
            {
                if (pressed && Game.Instance.canJump && Game.Instance.minJump < Game.Instance.maxJump && Physic.Instance.gravityActive)
                {
                    Game.Instance.Jump();
                    Game.Instance.minJump++;
                    if (Game.Instance.minJump > Game.Instance.maxJump)
                        Game.Instance.canJump = false;
                }
            }

            else if (key == Key.P)
            {
                if (pressed && Game.Instance.pause)
                {
                    Time.TimeScale = 0f;
                    Game.Instance.pause = false;
                }
                else if (pressed && !Game.Instance.pause)
                {
                    Time.TimeScale = 1f;
                    Game.Instance.pause = true;
                }
            }

            else if (key == Key.Q)
            {
                if (pressed)
                    GameInputs.Q = true;
                else
                    GameInputs.Q = false;
            }

            else if (key == Key.E)
            {
                if (pressed)
                    GameInputs.E = true;
                else
                    GameInputs.E = false;
            }
        }

        public void StringInputs()
        {
            System.Console.WriteLine(" Hi there\n" +
                " Welcome to my litlle FPS-Simulation Game" +
                " Here are all Game Key Inputs you need:\n" +
                " --------------------------------------------------------\n" +
                " Translation\n" +
                "   - Forward = W\n" +
                "   - Back = S\n" +
                "   - Right = D\n" +
                "   - Left = A\n" +
                "   - Jump = Space\n" +
                "   - Double-Jump = Active\n" +
                " ---------------------\n" +
                " Rotation\n" +
                "   - Left & Right = Mouse X\n" +
                " --------------------------------------------------------\n" +
                " I hope you enjoy it :)");
        }

        public void UpdateFPS_Camera_Inputs()
        {
            if (GameInputs.W)
                FPS_Camera.Position += Game.Instance.MoveForward() * Time.DeltaTime;
            if (GameInputs.S)
                FPS_Camera.Position -= Game.Instance.MoveForward() * Time.DeltaTime;
            if (GameInputs.A)
                FPS_Camera.Position += Game.Instance.MoveLeft() * Time.DeltaTime;
            if (GameInputs.D)
                FPS_Camera.Position -= Game.Instance.MoveRight() * Time.DeltaTime;
        }

        #region Callbacks

        public void OnResize()
        {
            Game.screenWidth = Window.Width;
            Game.screenHeight = Window.Height;

           UserInterface.OnResize(Game.screenWidth, Game.screenHeight);
        }

        public void OnClose()
        {
            // make sure to dispose of everything
            UserInterface.Dispose();
            BMFont.Dispose();
        }

        public void OnPreRenderFrame()
        {
            // set up the OpenGL viewport and clear both the color and depth bits
            Gl.Viewport(0, 0, Window.Width, Window.Height);
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public void OnPostRenderFrame()
        {
            // Draw the user interface after everything else
            UserInterface.Draw();

            // Swap the back buffer to the front so that the screen displays
            Window.SwapBuffers();
        }

        public void OnMouseClick(int button, int state, int x, int y)
        {
            // take care of mapping the Glut buttons to the UI enums
            if (!UserInterface.OnMouseClick(button + 1, (state == 0 ? 1 : 0), x, y))
            {
                // do other picking code here if necessary
            }
        }

        public bool OnMouseMove(int x, int y)
        {
            if (!UserInterface.OnMouseMove(x, y))
            {
                FPS_Camera.Rotation.X = -x / 10;
                //FPS_Camera.Rotation.Y = y;

                //// do other picking code here if necessary
                //System.Console.WriteLine("Camera Pos: " + x + ", " + y);
            }
            return false;
        }

        #endregion
    }
}
using OpenGL;
using OpenGL.Platform;
using OpenGL.Game;
using OpenGL.UI;
using System.Windows.Forms;

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
        Window.CreateWindow("OpenGL SAE Summative Test | Main Aufgabe |", 800, 600);

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

    public void CreateGameObject()
    {
        GameObject rednCube = Game.CreateGameObject("red", new Vector3(1f, 0f, 0f), GoData.vertices, GoData.indices, GoData.uvs, GoData.colors, GoData.normals, 0, 1f);
        rednCube.Transform.Position = new Vector3(-9f, 0f, -10f);
        rednCube.Transform.Rotation = Vector3.Zero;
        rednCube.Transform.Scale = new Vector3(3f, 3f, 3f);
        GameObject greenCube = Game.CreateGameObject("green", new Vector3(0f, 1f, 0f), GoData.vertices, GoData.indices, GoData.uvs, GoData.colors, GoData.normals, 0, .85f);
        greenCube.Transform.Position = new Vector3(-4f, 0f, -10f);
        greenCube.Transform.Rotation = Vector3.Zero;
        greenCube.Transform.Scale = new Vector3(3f, 3f, 3f);
        GameObject blueCube = Game.CreateGameObject("blue", new Vector3(0f, 0f, 1f), GoData.vertices, GoData.indices, GoData.uvs, GoData.colors, GoData.normals, 0, .75f);
        blueCube.Transform.Position = new Vector3(4f, 0f, -10f);
        blueCube.Transform.Rotation = Vector3.Zero;
        blueCube.Transform.Scale = new Vector3(3f, 3f, 3f);
        GameObject yellowCube = Game.CreateGameObject("yellow", new Vector3(1f, 1f, 0f), GoData.vertices, GoData.indices, GoData.uvs, GoData.colors, GoData.normals, 0, .65f);
        yellowCube.Transform.Position = new Vector3(8f, 0f, -10f);
        yellowCube.Transform.Rotation = Vector3.Zero;
        yellowCube.Transform.Scale = new Vector3(3f, 3f, 3f);
        GameObject defCube = Game.CreateGameObject("default", new Vector3(1f, 1f, 1f), GoData.vertices, GoData.indices, GoData.uvs, GoData.colors, GoData.normals, 0, .5f);
        defCube.Transform.Position = new Vector3(0f, 0f, -10f);
        defCube.Transform.Rotation = Vector3.Zero; ;
        defCube.Transform.Scale = new Vector3(3f, 3f, 3f);
        GameObject ground = Game.CreateGameObject("ground", new Vector3(0f, 1f, 0f), GoData.vertices, GoData.indices, GoData.uvs, GoData.colors, GoData.normals, 0, .4f);
        ground.Transform.Position = new Vector3(0f, -5f, 0);
        ground.Transform.Rotation = Vector3.Zero;
        ground.Transform.Scale = new Vector3(30f, 0.1f, 30f);
        GameObject fullSpec = Game.CreateGameObject("fullspec", new Vector3(1f, 1f, 1f), GoData.vertices, GoData.indices, GoData.uvs, GoData.colors, GoData.normals, 0, .2f);
        fullSpec.Transform.Position = new Vector3(12, 0, -10);
        fullSpec.Transform.Rotation = Vector3.Zero;
        fullSpec.Transform.Scale = new Vector3(3, 3, 3);
        GameObject halfSpec = Game.CreateGameObject("halfspec", new Vector3(1, 1, 1), GoData.vertices, GoData.indices, GoData.uvs, GoData.colors, GoData.normals, 0, .000001f);
        halfSpec.Transform.Position = new Vector3(18, 0, -10);
        halfSpec.Transform.Rotation = Vector3.Zero;
        halfSpec.Transform.Scale = new Vector3(3, 3, 3);

        GameObject rednCubeTop = Game.CreateGameObject("redTop", new Vector3(1f, 0f, 0f), GoData.vertices, GoData.indices, GoData.uvs, GoData.colors, GoData.normals, 0, 1f);
        rednCubeTop.Transform.Position = new Vector3(-9f, 5, -10f);
        rednCubeTop.Transform.Rotation = Vector3.Zero;
        rednCubeTop.Transform.Scale = new Vector3(3f, 3f, 3f);
        GameObject greenCubeTop = Game.CreateGameObject("greenTop", new Vector3(0f, 1f, 0f), GoData.vertices, GoData.indices, GoData.uvs, GoData.colors, GoData.normals, 0, 1f);
        greenCubeTop.Transform.Position = new Vector3(-4f, 5, -10f);
        greenCubeTop.Transform.Rotation = Vector3.Zero;
        greenCubeTop.Transform.Scale = new Vector3(3f, 3f, 3f);
        GameObject blueCubeTop = Game.CreateGameObject("blueTop", new Vector3(0f, 0f, 1f), GoData.vertices, GoData.indices, GoData.uvs, GoData.colors, GoData.normals, 0, 1f);
        blueCubeTop.Transform.Position = new Vector3(4f, 5, -10f);
        blueCubeTop.Transform.Rotation = Vector3.Zero;
        blueCubeTop.Transform.Scale = new Vector3(3f, 3f, 3f);
        GameObject yellowCubeTop = Game.CreateGameObject("yellowTop", new Vector3(1f, 1f, 0f), GoData.vertices, GoData.indices, GoData.uvs, GoData.colors, GoData.normals, 0, 1f);
        yellowCubeTop.Transform.Position = new Vector3(8f, 5, -10f);
        yellowCubeTop.Transform.Rotation = Vector3.Zero;
        yellowCubeTop.Transform.Scale = new Vector3(3f, 3f, 3f);
        GameObject defCubeTop = Game.CreateGameObject("defaultTop", new Vector3(1f, 1f, 1f), GoData.vertices, GoData.indices, GoData.uvs, GoData.colors, GoData.normals, 0, 1f);
        defCubeTop.Transform.Position = new Vector3(0f, 5, -10f);
        defCubeTop.Transform.Rotation = Vector3.Zero; ;
        defCubeTop.Transform.Scale = new Vector3(3f, 3f, 3f);
        GameObject fullSpecTop = Game.CreateGameObject("fullspecTop", new Vector3(1f, 1f, 1f), GoData.vertices, GoData.indices, GoData.uvs, GoData.colors, GoData.normals, 0, 1f);
        fullSpecTop.Transform.Position = new Vector3(12, 5, -10);
        fullSpecTop.Transform.Rotation = Vector3.Zero;
        fullSpecTop.Transform.Scale = new Vector3(3, 3, 3);
        GameObject halfSpecTop = Game.CreateGameObject("halfspecTop", new Vector3(1, 1, 1), GoData.vertices, GoData.indices, GoData.uvs, GoData.colors, GoData.normals, 0, 1f);
        halfSpecTop.Transform.Position = new Vector3(18, 5, -10);
        halfSpecTop.Transform.Rotation = Vector3.Zero;
        halfSpecTop.Transform.Scale = new Vector3(3, 3, 3);
    }

    public void AddInputKeyAndMouse()
    {
        // Hook to the escape press event using the OpenGL.UI class library
        Input.Subscribe((char)Keys.Escape, Window.OnClose);

        Event evt = new Event(new OpenGL.Platform.Event.KeyEvent(OnKeyStateChanged));

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
        Window.OnMouseCallbacks.Add(OpenGL.UI.UserInterface.OnMouseClick);

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
            
       //if (GameInputs.Q)
       //    Game.Instance.RotateLeft();
       //if (GameInputs.E)
       //    Game.Instance.RotateRight();
    }

    #region Callbacks

    public void OnResize()
    {
        Game.screenWidth = Window.Width;
        Game.screenHeight = Window.Height;

        OpenGL.UI.UserInterface.OnResize(Game.screenWidth, Game.screenHeight);
    }

    public void OnClose()
    {
        // make sure to dispose of everything
        OpenGL.UI.UserInterface.Dispose();
        OpenGL.UI.BMFont.Dispose();
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
        OpenGL.UI.UserInterface.Draw();

        // Swap the back buffer to the front so that the screen displays
        Window.SwapBuffers();
    }

    public void OnMouseClick(int button, int state, int x, int y)
    {
        // take care of mapping the Glut buttons to the UI enums
        if (!OpenGL.UI.UserInterface.OnMouseClick(button + 1, (state == 0 ? 1 : 0), x, y))
        {
            // do other picking code here if necessary
        }
    }

    public bool OnMouseMove(int x, int y)
    {
        if (!OpenGL.UI.UserInterface.OnMouseMove(x, y))
        {
            FPS_Camera.Rotation.X = x / 2;
            //FPS_Camera.Rotation.Y = y;

            //// do other picking code here if necessary
            //System.Console.WriteLine("Camera Pos: " + x + ", " + y);
        }
        return false;
    }

    #endregion
}

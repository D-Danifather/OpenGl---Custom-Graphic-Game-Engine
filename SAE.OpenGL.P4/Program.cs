using OpenGL.Game;
using OpenGL.Platform;

namespace SAE.GPR.Summativ.Daniyal
{
    static class Program
    {
        static void Main()
        {
            //----------------------------------------
            //          Consoles - Awake
            //----------------------------------------
            UpdateProgram.Instance.InitializeMain();                // Console - Program
            UpdateProgram.Instance.InitializeTexture();             // Texture
            Game.Instance.Awake();                                  // Shader Data
            UpdateProgram.Instance.CreateGameObjects();             // Create all in Game - Objects
            UpdateProgram.Instance.StringInputs();                  // Write Inputs (Black Console)

            //----------------------------------------
            //          Consoles - Running
            //----------------------------------------
            while (Window.Open)
            {
                Window.HandleInput();                               // Windows default Input - Handöer
                UpdateProgram.Instance.OnPreRenderFrame();          // Update Rendering - Frame => using OpenGL   
                Physic.Instance.Update();                           // 1: Add Phyisic to the Game
                Game.Instance.Update();                             // 2: Update the Game - Objects - List
                Game.Instance.Render();                             // 3: Render the Game - Objects - List --> add to Console
                UpdateProgram.Instance.UpdateFPS_Camera_Inputs();   // 4: Update every Input futures => (Input, Cammera etc.)
                UpdateProgram.Instance.AddInputKeyAndMouse();       // 5: Check every Input - Controlls --> while pressed => Do something...
                UpdateProgram.Instance.OnPostRenderFrame();         // OpenGL default UI - Draw per Frame
                Time.Update();                                      // Time in each Frame => while Console Windows running
            }
        }
    }
}

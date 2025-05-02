using System.Collections;
using System.Security.Cryptography;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace MAIN_FILE {
    class Game : GameWindow {
        [Obsolete] // to get rid of warnings
        public Game() : base(GameWindowSettings.Default, new NativeWindowSettings() {Size = new Vector2i(640,360),Title = "a pink window :3"}) {} // window settings
        protected override void OnLoad()
        {
            base.OnLoad();
        }
        protected override void OnRenderFrame(FrameEventArgs args) // rendering and commands to execute to render
        {
            base.OnRenderFrame(args);
            GL.ClearColor(1f,0f,1f,1); // R G B, W
            GL.Clear(ClearBufferMask.ColorBufferBit);
            SwapBuffers();
        }
        protected override void OnUpdateFrame(FrameEventArgs args) // input handling and others
        {
            base.OnUpdateFrame(args);
            if (KeyboardState.IsKeyDown(Keys.Escape)) {
                Close();
            }
        }
        protected override void OnFramebufferResize(FramebufferResizeEventArgs e) // when the window is resized
        {
            base.OnFramebufferResize(e);
            GL.Viewport(0,0,e.Width,e.Height);
        }

        [Obsolete] // to get rid of warnings
        static void Main() { // main function (run the game)
            Haii.haii();
            using (Game app = new Game())
            {
                // i like the stanley parable honestly
                app.Run();
            }
        }
    }
}

using Silk.NET.Core;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
//using Silk.NET.Vulkan;
using System;
using Silk.NET.Windowing;
using System.Security.Cryptography.X509Certificates;
using Silk.NET.Vulkan;
//made with blood, sweat, and tears :3
//weeb engine
public class WeebEngine
{
    //public FuncsAndStuff funcslol;
    //private static IWindow window;

    public static void Main()
    {
        var options = WindowOptions.Default;
        options.Size = new Vector2D<int>(800, 600);
        options.Title = "シット";
        FuncsAndStuff.window = Window.Create(options);
        FuncsAndStuff.window.Load += FuncsAndStuff.OnLoad;
        FuncsAndStuff.window.Update += FuncsAndStuff.OnUpdate;
        FuncsAndStuff.window.Render += FuncsAndStuff.OnRender;
        FuncsAndStuff.window.Run();
        //dispose
        FuncsAndStuff.window.Dispose();
    }
}

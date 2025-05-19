using Silk.NET.Core;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
//using Silk.NET.Vulkan;
using System;
using Silk.NET.Windowing;
//made with blood, sweat, and tears :3
//weeb engine
/*
About
[--Silk.NET--]
The high-speed OpenGL, OpenCL, OpenAL, OpenXR,
GLFW, SDL, Vulkan, Assimp, WebGPU, and DirectX
bindings library your mother warned you about.
*/
public class FuncsAndStuff
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public static IWindow window;
    private static GL gl;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    internal static void OnLoad()
    {
        IInputContext input = window.CreateInput();
        for (int i = 0; i < input.Keyboards.Count; i++)
        {
            input.Keyboards[i].KeyDown += KeyDown;
        }
        //gl = GL.GetApi(window);
        gl = window.CreateOpenGL();
    }
    internal static void OnUpdate(double obj)
    {

    }
    internal static void OnRender(double obj)
    {
        gl.ClearColor(1.0f, 0.0f, 1.0f, 1.0f);
        gl.Clear(ClearBufferMask.ColorBufferBit);
    }
    internal static void KeyDown(IKeyboard arg1, Key arg2, int arg3)
    {
        if (arg2 == Key.Escape)
        {
            window.Close();
        }
    }
}

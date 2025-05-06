using System;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using System.Runtime.CompilerServices;
using OpenTK.Windowing.GraphicsLibraryFramework;

class TriangleWindow : GameWindow
{
    Haiii _haiii = new Haiii();
    private int _vao;
    private int _vbo;
    private int _shaderProgram;

    public TriangleWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
        : base(gameWindowSettings, nativeWindowSettings) { }

    protected override void OnLoad()
    {
        base.OnLoad();

        Half[] vertices = new Half[]
        {
        //   |||VERTICES|||     |||COLORS|||
            (Half)0.0f,  (Half)0.5f, (Half)0.0f, (Half)1.0f,(Half)0.0f,(Half)0.0f,
           (Half)(-0.5f), (Half)(-0.5f), (Half)0.0f, (Half)0.0f,(Half)1.0f,(Half)0.0f,
           (Half) 0.5f, (Half)(-0.5f), (Half)0.0f, (Half)0.0f,(Half)0.0f,(Half)1.0f
        };

        _vao = GL.GenVertexArray();
        GL.BindVertexArray(_vao);

        _vbo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        string vertexShaderSource = @"
        #version 330 core
        layout (location = 0) in vec3 aPos;
        layout (location = 1) in vec3 aColor;
        out vec3 vColor;
        void main()
        {
            vColor = aColor;
            gl_Position = vec4(aPos, 1.0);
        }";

        string fragmentShaderSource = @"
        #version 330 core
        out vec4 FragColor;
        in vec3 vColor;
        void main()
        {
            FragColor = vec4(vColor, 1.0);
        }";
        _shaderProgram = _haiii.CompileShader(vertexShaderSource, fragmentShaderSource);
        GL.UseProgram(_shaderProgram);

        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.HalfFloat, false, 6 * 2, 0);
        GL.EnableVertexAttribArray(0);

        GL.VertexAttribPointer(1, 3, VertexAttribPointerType.HalfFloat, false, 6 * 2, 3 * 2);
        GL.EnableVertexAttribArray(1);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
        GL.Clear(ClearBufferMask.ColorBufferBit);

        GL.UseProgram(_shaderProgram);
        GL.BindVertexArray(_vao);
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

        SwapBuffers();
    }

    protected override void OnUnload()
    {
        GL.DeleteVertexArray(_vao);
        GL.DeleteBuffer(_vbo);
        GL.DeleteProgram(_shaderProgram);
        base.OnUnload();
    }
    
    [Obsolete]
    public static void Main()
    {

        var nativeWindowSettings = new NativeWindowSettings()
        {
            Size = new OpenTK.Mathematics.Vector2i(800, 600),
            Title = "OpenTK Triangle"
        };

        using var window = new TriangleWindow(GameWindowSettings.Default, nativeWindowSettings);
        window.Run();
    }
}

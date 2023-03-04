using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;

namespace FaddleEngine.Graphics
{
    internal readonly struct ShaderUniform
    {
        public readonly string name;
        public readonly int location;
        public readonly ActiveUniformType type;

        public ShaderUniform(string name, int location, ActiveUniformType type) : this()
        {
            this.name = name;
            this.location = location;
            this.type = type;
        }
    }

    internal readonly struct ShaderAttribute
    {
        public readonly string name;
        public readonly int location;
        public readonly ActiveAttribType type;

        public ShaderAttribute(string name, int location, ActiveAttribType type)
        {
            this.name = name;
            this.location = location;
            this.type = type;
        }
    }

    public class Shader
    {
        public readonly int handle;
        public static Shader DEFAULT => new("Default/Shaders/Texture.vert", "Default/Shaders/Texture.frag");

        private readonly ShaderUniform[] uniforms;
        private readonly ShaderAttribute[] attributes;

        private bool disposed;

        public Shader(string vertexPath, string fragmentPath)
        {
            disposed = false;

            int vertexShaderHandle = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShaderHandle, FileSystem.LoadTextFile(vertexPath));
            GL.CompileShader(vertexShaderHandle);

            GL.GetShader(vertexShaderHandle, ShaderParameter.CompileStatus, out int success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(vertexShaderHandle);
                Log.Error(infoLog);
            }

            int fragmentShaderHandle = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShaderHandle, FileSystem.LoadTextFile(fragmentPath));
            GL.CompileShader(fragmentShaderHandle);

            GL.GetShader(fragmentShaderHandle, ShaderParameter.CompileStatus, out success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(fragmentShaderHandle);
                Log.Error(infoLog);
            }

            handle = GL.CreateProgram();
            GL.AttachShader(handle, vertexShaderHandle);
            GL.AttachShader(handle, fragmentShaderHandle);

            GL.LinkProgram(handle);

            GL.GetProgram(handle, GetProgramParameterName.LinkStatus, out success);
            if (success == 0)
            {
                string infoLog = GL.GetProgramInfoLog(handle);
                Log.Error(infoLog);
            }

            GL.DetachShader(handle, vertexShaderHandle);
            GL.DetachShader(handle, fragmentShaderHandle);

            GL.DeleteShader(vertexShaderHandle);
            GL.DeleteShader(fragmentShaderHandle);

            uniforms = CreateUniformList(handle);
            attributes = CreateAttributeList(handle);
        }

        internal void Use()
        {
            GL.UseProgram(handle);
        }

        #region SET UNIFORM

        public void SetUniform(string name, int v)
        {
            if (!GetShaderUniform(name, out ShaderUniform uniform))
            {
                Log.Error($"Could not find uniform {name}.");
            }

            if (uniform.type != ActiveUniformType.Int && uniform.type != ActiveUniformType.Sampler2D)
            {
                Log.Error($"Type of uniform {name} is not int.");
            }

            GL.Uniform1(uniform.location, v);
        }


        public void SetUniform(string name, float v)
        {
            if (!GetShaderUniform(name, out ShaderUniform uniform))
            {
                Log.Error($"Could not find uniform {name}.");
            }

            if (uniform.type != ActiveUniformType.Float)
            {
                Log.Error($"Type of uniform {name} is not float.");
            }

            GL.Uniform1(uniform.location, v);
        }

        public void SetUniform(string name, Vector2 v)
        {
            if (!GetShaderUniform(name, out ShaderUniform uniform))
            {
                Log.Error($"Could not find uniform {name}.");
            }

            if (uniform.type != ActiveUniformType.FloatVec2)
            {
                Log.Error($"Type of uniform {name} is not Vector2.");
            }

            GL.Uniform2(uniform.location, v);
        }

        public void SetUniform(string name, Color c)
        {
            if (!GetShaderUniform(name, out ShaderUniform uniform))
            {
                Log.Error($"Could not find uniform {name}.");
            }

            if (uniform.type != ActiveUniformType.FloatVec4)
            {
                Log.Error($"Type of uniform {name} is not Vector2.");
            }

            GL.Uniform4(uniform.location, (Color4)c);
        }

        public void SetUniform(string name, Matrix4 v)
        {
            if (!GetShaderUniform(name, out ShaderUniform uniform))
            {
                Log.Error($"Could not find uniform {name}.");
            }

            if (uniform.type != ActiveUniformType.FloatMat4)
            {
                Log.Error($"Type of uniform {name} is not Matrix4.");
            }

            GL.UniformMatrix4(uniform.location, true, ref v);
        }

        private bool GetShaderUniform(string name, out ShaderUniform uniform)
        {
            uniform = new ShaderUniform();

            for (int i = 0; i < uniforms.Length; i++)
            {
                uniform = uniforms[i];

                if (name == uniform.name)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region ARRAY CREATION

        internal ShaderUniform[] GetUniformList()
        {
            ShaderUniform[] result = new ShaderUniform[uniforms.Length];
            Array.Copy(uniforms, result, uniforms.Length);
            return result;
        }

        internal ShaderAttribute[] GetAttributeList()
        {
            ShaderAttribute[] result = new ShaderAttribute[attributes.Length];
            Array.Copy(attributes, result, attributes.Length);
            return result;
        }

        internal static ShaderUniform[] CreateUniformList(int handle)
        {
            GL.GetProgram(handle, GetProgramParameterName.ActiveUniforms, out int uniformCount);

            ShaderUniform[] uniforms = new ShaderUniform[uniformCount];

            for (int i = 0; i < uniformCount; i++)
            {
                GL.GetActiveUniform(handle, i, 256, out _, out _, out ActiveUniformType type, out string name);
                int location = GL.GetUniformLocation(handle, name);

                uniforms[i] = new ShaderUniform(name, location, type);
            }

            return uniforms;
        }

        internal static ShaderAttribute[] CreateAttributeList(int handle)
        {
            GL.GetProgram(handle, GetProgramParameterName.ActiveAttributes, out int attribCount);

            ShaderAttribute[] attributes = new ShaderAttribute[attribCount];

            for (int i = 0; i < attribCount; i++)
            {
                GL.GetActiveAttrib(handle, i, 256, out _, out _, out ActiveAttribType type, out string name);
                int location = GL.GetAttribLocation(handle, name);

                attributes[i] = new ShaderAttribute(name, location, type);
            }

            return attributes;
        }

        #endregion

        internal void Dispose()
        {
            if (disposed)
            {
                return;
            }

            GL.UseProgram(0);
            GL.DeleteProgram(handle);

            disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}

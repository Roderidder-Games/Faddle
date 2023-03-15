using OpenTK.Graphics.OpenGL4;
using StbImageSharp;
using System.Collections.Generic;
using System.IO;
using PixelFormat = OpenTK.Graphics.OpenGL4.PixelFormat;

namespace FaddleEngine
{
    public sealed class Texture
    {
        private static readonly List<Texture> textures = new();

        public readonly Vector2Int size;

        public readonly int handle;

        private TextureUnit unit;

        private Color[] texPixels;

        internal FaddleEvent<Texture> onTexUpdate = new();

        private readonly bool point = false;

        public Texture(string path, bool point = false)
        {
            this.point = point;

            handle = GL.GenTexture();

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, handle);

            StbImage.stbi_set_flip_vertically_on_load(1);

            using (Stream stream = File.OpenRead(FileSystem.ToResourcePath(path)))
            {
                ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);

                size = new Vector2Int(image.Width, image.Height);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);
            };

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, point ? (int)TextureMinFilter.Nearest : (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, point ? (int)TextureMagFilter.Nearest : (int)TextureMagFilter.Linear);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            textures.Add(this);
        }
        
        public Texture(Color[] pixels, int width, bool point = false)
        {
            if (pixels.Length % width != 0)
            {
                Log.Error($"Invalid Texture width: {width}.");
            }

            handle = GL.GenTexture();

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, handle);

            byte[] data = new byte[pixels.Length * 4];
            size = new Vector2Int(width, pixels.Length / width);

            int index = 0;

            foreach (Color color in pixels)
            {
                Vector4 bytes = color.ToBytes();

                data[index] = (byte)bytes.x;
                data[index + 1] = (byte)bytes.y;
                data[index + 2] = (byte)bytes.z;
                data[index + 3] = (byte)bytes.w;

                index += 4;
            }

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, size.x, size.y, 0, PixelFormat.Rgba, PixelType.UnsignedByte, data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, point ? (int)TextureMinFilter.Nearest : (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, point ? (int)TextureMagFilter.Nearest : (int)TextureMagFilter.Linear);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            textures.Add(this);
        }

        public Texture Copy()
        {
            if (texPixels == null)
            {
                InitializePixels();
            }

            return new Texture(texPixels, size.x, point);
        }

        public void Replace(Color source, Color target)
        {
            if (texPixels == null)
            {
                InitializePixels();
            }

            for (int i = 0; i < texPixels.Length; i++)
            {
                if (texPixels[i] == source)
                {
                    texPixels[i] = target;
                }
            }

            Apply();
        }

        private void Apply()
        {
            GL.BindTexture(TextureTarget.Texture2D, handle);

            byte[] data = new byte[(size.x * size.y) * 4];

            int index = 0;

            foreach (Color color in texPixels)
            {
                Vector4 bytes = color.ToBytes();

                data[index] = (byte)bytes.x;
                data[index + 1] = (byte)bytes.y;
                data[index + 2] = (byte)bytes.z;
                data[index + 3] = (byte)bytes.w;

                index += 4;
            }

            GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, size.x, size.y, PixelFormat.Rgba, PixelType.UnsignedByte, data);
        }

        private void InitializePixels()
        {
            GL.BindTexture(TextureTarget.Texture2D, handle);

            int fboId = GL.GenFramebuffer();
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, fboId);
            GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0, TextureTarget.Texture2D, handle, 0);

            byte[] pixels = new byte[(size.x * size.y) * 4];
            GL.ReadPixels(0, 0, size.x, size.y, PixelFormat.Rgba, PixelType.UnsignedByte, pixels);

            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
            GL.DeleteFramebuffer(fboId);

            texPixels = new Color[size.x * size.y];

            int index = 0;

            for (int i = 0; i < pixels.Length; i += 4)
            {
                byte r = pixels[i];
                byte g = pixels[i + 1];
                byte b = pixels[i + 2];
                byte a = pixels[i + 3];

                texPixels[index] = new Color(r, g, b, a);

                index++;
            }

            onTexUpdate.Fire(this);
        }

        public Color[] GetPixels(bool clear = false)
        {
            if (clear || texPixels == null)
            {
                InitializePixels();
            }

            return texPixels;
        }

        public Color[] GetPixels(Vector2Int start, Vector2Int dimensions)
        {
            GL.BindTexture(TextureTarget.Texture2D, handle);

            int fboId = GL.GenFramebuffer();
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, fboId);
            GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0, TextureTarget.Texture2D, handle, 0);

            byte[] pixels = new byte[(dimensions.x * dimensions.y) * 4];
            GL.ReadPixels(start.x, start.y, dimensions.x, dimensions.y, PixelFormat.Rgba, PixelType.UnsignedByte, pixels);

            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
            GL.DeleteFramebuffer(fboId);

            Color[] pixelsArray = new Color[dimensions.x * dimensions.y];

            int index = 0;

            for (int i = 0; i < pixels.Length; i += 4)
            {
                byte r = pixels[i];
                byte g = pixels[i + 1];
                byte b = pixels[i + 2];
                byte a = pixels[i + 3];

                pixelsArray[index] = new Color(r, g, b, a);

                index++;
            }

            return pixelsArray;
        }

        public void SetPixels(Vector2Int start, Vector2Int dimensions, Color[] pixels)
        {
            if (texPixels == null)
            {
                InitializePixels();
            }

            for (int y = 0; y < dimensions.y; y++) 
            {
                for (int x = 0; x < dimensions.x; x++)
                {
                    texPixels[(x + start.x) + (y + start.y) * size.x] = pixels[x + y * dimensions.x];
                }
            }

            Apply();
        }

        public void Use(TextureUnit unit)
        {
            this.unit = unit;
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, handle);
        }

        internal static void DisposeAll()
        {
            textures.ForEach(tex => tex.Dispose());
        }

        internal void Dispose()
        {
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.DeleteTexture(handle);
        }
    }
}

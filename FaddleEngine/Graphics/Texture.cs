﻿using OpenTK.Graphics.OpenGL4;
using StbImageSharp;
using System.IO;

namespace FaddleEngine.Graphics
{
    public class Texture
    {
        public readonly Vector2Int size;

        public readonly int handle;

        private TextureUnit unit;

        private readonly ImageResult image;

        public Texture(string path)
        {
            handle = GL.GenTexture();

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, handle);

            StbImage.stbi_set_flip_vertically_on_load(1);

            using (Stream stream = File.OpenRead(FileSystem.ToResourcePath(path)))
            {
                image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);

                size = new Vector2Int(image.Width, image.Height);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);
            };

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }

        public void Use(TextureUnit unit)
        {
            this.unit = unit;
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, handle);
        }

        internal void Dispose()
        {
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.DeleteTexture(handle);
        }
    }
}
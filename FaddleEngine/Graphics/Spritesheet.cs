namespace FaddleEngine
{
    public sealed class Spritesheet
    {
        private readonly Texture[,] sprites;

        public readonly Vector2Int tileSize;

        private Texture[] sprites1D;

        public Spritesheet(Texture source, Vector2Int tileSize)
        {
            if (source.size.x % tileSize.x != 0)
            {
                Log.Error($"Texture width {source.size.x} is not a multiple of tile width {tileSize.x}.");
            }

            if (source.size.y % tileSize.y != 0)
            {
                Log.Error($"Texture width {source.size.x} is not a multiple of tile width {tileSize.x}.");
            }

            this.tileSize = tileSize;

            sprites = new Texture[(source.size.x / tileSize.x), (source.size.y / tileSize.y)];

            for (int y = 0; y < source.size.y; y += tileSize.y)
            {
                for (int x = 0; x < source.size.x; x += tileSize.x)
                {
                    sprites[x / tileSize.x, y / tileSize.y] = new Texture(source.GetPixels(new Vector2Int(x, y), new Vector2Int(tileSize.x, tileSize.y)), tileSize.x);
                }
            }
        }

        public Spritesheet(Texture source, Vector2Int tileSize, Color backgroundColor)
        {
            if (source.size.x % tileSize.x != 0)
            {
                Log.Error($"Texture width {source.size.x} is not a multiple of tile width {tileSize.x}.");
            }

            if (source.size.y % tileSize.y != 0)
            {
                Log.Error($"Texture width {source.size.x} is not a multiple of tile width {tileSize.x}.");
            }

            source.Replace(backgroundColor, new Color(0f, 0f, 0f, 0f));

            this.tileSize = tileSize;

            sprites = new Texture[(source.size.x / tileSize.x), (source.size.y / tileSize.y)];

            for (int y = 0; y < source.size.y; y += tileSize.y)
            {
                for (int x = 0; x < source.size.x; x += tileSize.x)
                {
                    sprites[x / tileSize.x, y / tileSize.y] = new Texture(source.GetPixels(new Vector2Int(x, y), new Vector2Int(tileSize.x, tileSize.y)), tileSize.x);
                }
            }
        }

        public Texture GetSprite(int index)
        {
            return GetSprites()[index];
        }

        public Texture GetSprite(int x, int y)
        {
            return sprites[x, y];
        }

        public int GetSheetLength()
        {
            return sprites.Length;
        }

        public int GetSheetLengthX()
        {
            return sprites.GetLength(0);
        }

        public int GetSheetLengthY()
        {
            return sprites.GetLength(1);
        }

        public Texture[,] GetSprites2D()
        {
            return sprites;
        }

        public Texture[] GetSprites()
        {
            if (sprites1D != null)
            {
                return sprites1D;
            }

            int size = sprites.Length;
            sprites1D = new Texture[size];

            int index = 0;
            for (int y = 0; y < GetSheetLengthY(); y++)
            {
                for (int x = 0; x < GetSheetLengthX(); x++)
                {
                    sprites1D[index++] = sprites[x, y];
                }
            }

            return sprites1D;
        }
    }
}

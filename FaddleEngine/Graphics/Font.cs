using System.Collections.Generic;

namespace FaddleEngine.Graphics
{
    public class Font
    {
        public static readonly Font CASCADIA = new(new Texture("Default/Fonts/Cascadia.bmp"), Vector2Int.One * 32);

        private readonly Spritesheet fontSheet;
        private readonly Dictionary<char, Vector2Int> charToSprite;

        public Font(Texture source, Vector2Int charSize)
        {
            fontSheet = new Spritesheet(source, charSize, Color.Black);
            charToSprite = new Dictionary<char, Vector2Int>();

            Texture[,] textures = fontSheet.GetSprites2D();

            int charIndex = 32;

            for (int y = textures.GetLength(1) - 1; y >= 0 ; y--)
            {
                for (int x = 0; x < textures.GetLength(0); x++)
                {
                    char c = (char)charIndex;
                    charToSprite[c] = new Vector2Int(x, y);
                    charIndex++;
                }
            }
        }

        public Texture GetTexture(char c)
        {
            return fontSheet.GetSprite(charToSprite[c].x, charToSprite[c].y);
        }

        public Spritesheet GetSpritesheet()
        {
            return fontSheet;
        }
    }
}

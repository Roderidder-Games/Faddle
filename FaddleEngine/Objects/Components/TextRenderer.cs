﻿namespace FaddleEngine
{
    [RequireComponent(typeof(MeshRenderer))]
    public sealed class TextRenderer : Component
    {
        private string _text;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                UpdateText();
            }
        }

        private Font _font;
        public Font Font
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
                UpdateText();
            }
        }

        public TextRenderer(string text, Font font)
        {
            _text = text;
            _font = font;
        }

        public override void OnAdd()
        {
            UpdateText();
        }

        public override void OnRemove()
        {
        }

        public override void OnUpdate()
        {
        }

        private void UpdateText()
        {
            int maxColumn = 0;
            int column = 0;
            int lines = 1;

            for (int i = 0; i < _text.Length; i++)
            {
                if (_text[i] == '\n')
                {
                    lines++;
                    column = 0;
                    continue;
                }

                column++;

                if (column > maxColumn)
                {
                    maxColumn = column;
                }
            }

            Vector2Int tileSize = Font.GetSpritesheet().tileSize;
            Vector2Int texSize = new(maxColumn * tileSize.x, lines * tileSize.y);

            Color[] pixels = new Color[texSize.x * texSize.y];

            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = new Color(0, 0, 0, 0);
            }

            Texture texture = new(pixels, texSize.x);

            int xCurrent = 0;
            int yCurrent = 0;

            for (int i = 0; i < _text.Length; i++)
            {
                if (xCurrent + tileSize.x > texSize.x)
                {
                    xCurrent = 0;
                    yCurrent += tileSize.y;
                }

                texture.SetPixels(new Vector2Int(xCurrent, yCurrent), new Vector2Int(tileSize.x, tileSize.y), _font.GetTexture(_text[i]).GetPixels());

                xCurrent += tileSize.x;
            }

            Parent.GetComponent<MeshRenderer>().mesh.SetTexture(texture);
        }
    }
}
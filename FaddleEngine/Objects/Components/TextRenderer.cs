namespace FaddleEngine
{
    [RequireComponent(typeof(MeshRenderer))]
    public class TextRenderer : Component
    {
        private const string fontPath = "LatinBasic.png";
        private const int GlyphsPerLine = 15;
        private const int GlyphLineCount = 8;
        private const int GlyphWidth = 16;

        public TextRenderer(string path)
        {
        }

        public void Draw(string text)
        {
            
        }

        public override void OnAdd()
        {
        }

        public override void OnRemove()
        {
        }

        public override void OnUpdate()
        {
        }
    }
}

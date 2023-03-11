namespace FaddleEngine
{
    public sealed class TextRenderer : Component
    {
        private readonly TextRenderObject textRenderer;

        public string Text
        {
            get => textRenderer.Text;
            set => textRenderer.Text = value;
        }

        public Font Font
        {
            get => textRenderer.Font;
            set => textRenderer.Font = value;
        }

        public TextRenderer(string text, Font font)
        {
            textRenderer = new TextRenderObject(text, font);
        }

        internal override void OnAdd()
        {
            textRenderer.UpdateText();
        }

        internal override void OnRemove()
        {
            textRenderer.Dispose();
        }

        internal override void OnUpdate()
        {
        }

        internal override void OnRender()
        {
            textRenderer.RenderText(Transform.Model);
        }
    }
}

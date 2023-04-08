using OpenTK.Mathematics;

namespace FaddleEngine
{
    public sealed class Button : UIElement
    {
        public bool enabled;

        public Texture BackgroundImage
        {
            get => backgroundRenderer.mesh.texture;
            set => backgroundRenderer.mesh.SetTexture(value);
        }

        private readonly UITextRenderObject textRenderer;
        private readonly UIMeshRenderObject backgroundRenderer;

        public string Text
        {
            get => textRenderer.Text; 
            set => textRenderer.Text = value;
        }

        public Color TextColor
        {
            get => textRenderer.TextColor;
            set => textRenderer.TextColor = value;
        }

        public Button(string text, Transform transform, Font font, Color textColor, Texture backgroundImage, bool enabled = true) : base(transform)
        {
            this.enabled = enabled;
            backgroundRenderer = new UIMeshRenderObject(Mesh.Square, Shader.TEXTURE, false, (int)Transform.Position.z);
            BackgroundImage = backgroundImage;
            textRenderer = new UITextRenderObject(text, font, textColor, (int)Transform.Position.z);
        }

        internal override void OnAdd()
        {
            textRenderer.UpdateText();
        }

        internal override void OnRemove()
        {
            textRenderer.Dispose();
            backgroundRenderer.Dispose();
        }

        internal override void OnUpdate()
        {

        }

        internal override void OnRender()
        {
            backgroundRenderer.SetModel(Transform.Model);
            textRenderer.SetModel(Transform.Model);
            backgroundRenderer.Render();
            textRenderer.Render();
        }
    }
}

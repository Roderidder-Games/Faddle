using OpenTK.Mathematics;

namespace FaddleEngine
{
    public sealed class Button : Component
    {
        public bool enabled;

        private FaddleEvent _onLeftMouseButtonDown = new();
        public FaddleEvent OnLeftMouseButtonDown
        {
            get => _onLeftMouseButtonDown;
            private set => _onLeftMouseButtonDown = value;
        }

        private FaddleEvent _onLeftMouseButtonUp = new();
        public FaddleEvent OnLeftMouseButtonUp
        {
            get => _onLeftMouseButtonUp;
            private set => _onLeftMouseButtonUp = value;
        }

        private FaddleEvent _onRightMouseButtonDown = new();
        public FaddleEvent OnRightMouseButtonDown
        {
            get => _onRightMouseButtonDown;
            private set => _onRightMouseButtonDown = value;
        }

        private FaddleEvent _onRightMouseButtonUp = new();
        public FaddleEvent OnRightMouseButtonUp
        {
            get => _onRightMouseButtonUp;
            private set => _onRightMouseButtonUp = value;
        }

        public Texture BackgroundImage
        {
            get => backgroundRenderer.mesh.texture;
            set => backgroundRenderer.mesh.SetTexture(value);
        }

        private readonly TextRenderObject textRenderer;
        private readonly MeshRenderObject backgroundRenderer;

        private bool clicked = false;

        public string Text
        {
            get => textRenderer.Text; 
            set => textRenderer.Text = value;
        }

        public Button(string text, Font font, Texture backgroundImage, bool enabled = true)
        {
            this.enabled = enabled;
            Input.OnMouseButtonDown.AddListener(MouseClicked);
            Input.OnMouseButtonUp.AddListener(MouseReleased);
            backgroundRenderer = new MeshRenderObject(Mesh.Square, Shader.DEFAULT, false);
            BackgroundImage = backgroundImage;
            textRenderer = new TextRenderObject(text, font);
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
            backgroundRenderer.RenderMesh(Transform.Model * Matrix4.CreateTranslation(0f, 0f, -0.001f));
            textRenderer.RenderText(Transform.Model);
        }

        private void MouseClicked(Mouse button)
        {
            if (!enabled) return;

            if (clicked) return;

            if (!Parent.MouseOver()) return;

            clicked = true;

            if (button == Mouse.Left)
            {
                _onLeftMouseButtonDown.Fire();
            }
            else if (button == Mouse.Right)
            {
                _onRightMouseButtonDown.Fire();
            }
        }

        private void MouseReleased(Mouse button)
        {
            if (!enabled) return;

            if (!clicked) return;

            clicked = false;

            if (button == Mouse.Left)
            {
                _onLeftMouseButtonUp.Fire();
            }
            else if (button == Mouse.Right)
            {
                _onRightMouseButtonUp.Fire();
            }
        }
    }
}

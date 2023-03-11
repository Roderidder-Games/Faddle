using FaddleEngine.Events;
using System.Collections.Generic;

namespace FaddleEngine
{
    public readonly struct AnimationFrame
    {
        public readonly Texture texture;
        public readonly int duration;

        public AnimationFrame(Texture texture, int duration)
        {
            this.texture = texture;
            this.duration = duration;
        }
    }

    public sealed class Animation
    {
        public delegate void OnAnimationFrame();
        public readonly FaddleEvent onAnimationFinished;

        internal readonly AnimationFrame[] frames;

        private readonly Dictionary<int, FaddleEvent> onFrameEvents = new();

        private int passedDuration = 0, currentAnimationFrame = 0;

        private bool finished = false;

        public Animation(params AnimationFrame[] frames)
        {
            this.frames = frames;
            onAnimationFinished = new FaddleEvent();
        }

        internal void OnPlay(Mesh mesh)
        {
            finished = false;
            passedDuration = 0;
            currentAnimationFrame = 0;
            mesh.SetTexture(frames[0].texture);
        }

        internal void Update(Mesh mesh)
        {
            if (finished)
            {
                if (passedDuration > frames[currentAnimationFrame - 1].duration)
                {
                    onAnimationFinished.Fire();
                    return;
                }
            }

            if (!finished && currentAnimationFrame >= frames.Length)
            {
                finished = true;
            }

            if (!finished && passedDuration > frames[currentAnimationFrame].duration)
            {
                currentAnimationFrame++;
                mesh.SetTexture(frames[currentAnimationFrame - 1].texture);
                passedDuration = 0;
            }

            passedDuration++;
        }

        public void OnFrame(int frame, FaddleEvent.EventListener @event)
        {
            if (!onFrameEvents.ContainsKey(frame))
            {
                onFrameEvents[frame] = new FaddleEvent();
            }

            onFrameEvents[frame].AddListener(@event);
        }
    }
}

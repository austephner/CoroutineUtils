using System;
using System.Collections;
using UnityEngine;

namespace CoroutineUtils
{
    public static class CoroutineUtils
    {
        /// <summary>
        /// Invokes an action on the next frame.
        /// </summary>
        public static IEnumerator InvokeNextFrame(Action action)
        {
            yield return new WaitForEndOfFrame();
            action?.Invoke();
        }

        /// <summary>
        /// Invokes an action after the given number of frames
        /// </summary>
        public static IEnumerator InvokeAfterFrames(Action action, int frames)
        {
            var wait = new WaitForEndOfFrame();

            for (int i = 0; i < frames; i++) yield return wait;
            
            action?.Invoke();
        }

        /// <summary>
        /// Invokes an action after the given seconds of real time.
        /// </summary>
        public static IEnumerator InvokeAfterTime(Action action, float time)
        {
            yield return new WaitForSecondsRealtime(time);
            action?.Invoke();
        }

        /// <summary>
        /// Invokes an action once after the given <see cref="conditionalFunction"/> return true.
        /// </summary>
        public static IEnumerator InvokeWhenTrue(Func<bool> conditionalFunction, Action action)
        {
            var wait = new WaitForEndOfFrame();

            while (!conditionalFunction()) yield return wait;

            action?.Invoke();
        }
    }
}
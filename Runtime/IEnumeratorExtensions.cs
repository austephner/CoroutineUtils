using System;
using System.Collections;
using UnityEngine;

namespace CoroutineUtils
{
    public static class IEnumeratorExtensions
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
    
        /// <summary>
        /// Yields this <see cref="enumerator"/> and then yields <see cref="next"/>. Mimics promise-like functionality.
        /// </summary>
        /// <param name="enumerator">This <see cref="IEnumerator"/>.</param>
        /// <param name="next">The "next" <see cref="IEnumerator"/> to yield.</param>
        public static IEnumerator Then(this IEnumerator enumerator, IEnumerator next)
        {
            yield return enumerator;
            yield return next;
        }

        /// <summary>
        /// Yields this <see cref="enumerator"/> and invokes <see cref="next"/>. Mimics promise-like functionality.
        /// </summary>
        /// <param name="enumerator">This <see cref="IEnumerator"/>.</param>
        /// <param name="next">The "next" <see cref="Action"/> to invoke.</param>
        public static IEnumerator Then(this IEnumerator enumerator, Action next)
        {
            yield return enumerator;
            next?.Invoke();
        }
    }
}
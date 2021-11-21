using System;
using System.Collections;

public static class IEnumeratorExtensions
{
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
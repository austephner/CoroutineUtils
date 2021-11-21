# Coroutine Utils
Additional functionality for Unity Coroutines and IEnumerators.

## Coroutine Utilities
### InvokeNextFrame
Invokes an action on the next frame. 
```c#
yield return CoroutineUtils.InvokeNextFrame(() => Debug.Log("Hello World")); 
```

### InvokeAfterFrames
Invokes an action after the given number of frames.
```c#
yield return CoroutineUtils.InvokeAfterFrames(() => Debug.Log("Hello World"), 100); 
```

### InvokeAfterTime
Invokes an action after the given seconds of real time. 
```c#
yield return CoroutineUtils.InvokeAfterFrames(() => Debug.Log("Hello World"), 15.0f);
```

### InvokeWhenTrue
Invokes an action once after the given `conditionalFunction` returns true.
```c#
yield return CoroutineUtils.InvokeWhenTrue(
    () => Random.Range(0.0f, 1.0f) > 0.5f,
    () => Debug.Log("Hello World"));
```

## IEnumerator Extensions
### Then
Yields the return of "this" `IEnumerator` then either yields another `IEnumerator` or invokes an `Action`.
```c#
private void Start() 
{
    StartCoroutine(someEnumerator().Then(someOtherEnumerator);
    StartCoroutine(someEnumerator().Then(someMethod);
}

private IEnumerator someEnumerator() 
{
    Debug.Log("Hello World");
    yield break;
}

private IEnumerator someOtherEnumerator() 
{
    Debug.Log("Hello Again World");
    yield break;
}

private void someMethod() 
{
    Debug.Log("I'm a method!");
}
```
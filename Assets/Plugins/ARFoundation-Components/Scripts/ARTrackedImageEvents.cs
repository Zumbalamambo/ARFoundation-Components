using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ARTrackedImageEvents : MonoBehaviour
{

    [System.Serializable]
    public class TrackedImageEvent : UnityEvent<ARTrackedImage>
    {

    }

    public TrackedImageEvent TrackedImageAdded;

    public TrackedImageEvent TrackedImageUpdated;

    public TrackedImageEvent TrackedImageRemoved;

    private ARTrackedImageManager trackedImageManager;

    private void Awake()
    {

        trackedImageManager = GetComponent<ARTrackedImageManager>();

    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {

        foreach (var trackedImage in eventArgs.added)
        {

            TrackedImageAdded?.Invoke(trackedImage);

        }

        foreach (var trackedImage in eventArgs.updated)
        {

            TrackedImageUpdated?.Invoke(trackedImage);

        }

        foreach (var trackedImage in eventArgs.removed)
        {

            TrackedImageRemoved?.Invoke(trackedImage);

        }

    }

    private void OnEnable()
    {

        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;

    }

    private void OnDisable()
    {

        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;

    }

}

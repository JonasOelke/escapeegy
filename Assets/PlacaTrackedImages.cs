using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacaTrackedImages : MonoBehaviour
{
    // Reference to AR Tracked Image Manager component
    private ARTrackedImageManager _trackImageManager;

    // List of prefabs to instantiate - these should be named the same as their corresponding 2D images in the reference lib
    public GameObject[] ArPrefabs;

    // Keep dictionary array of created prefabs
    private readonly Dictionary<string, GameObject> _instantiatedPrefabs =
        new Dictionary<string, GameObject>();

    void Awake()
    {
        // Cache a reference to the Tracked Image Manager Component
        _trackImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        // Attach event handler when tracked images change
        _trackImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        // Remove event handler
        _trackImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    // Event Handler
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // Loop through all new tracked images that have been detected
        foreach (var trackedImage in eventArgs.added)
        {
            // Get the name of the reference image
            var imageName = trackedImage.referenceImage.name;
            // Now loop over the array of prefabs
            foreach (var curPrefab in ArPrefabs)
            {
                // Check whether this prefab mathes tracked image name and that prefab hasnt already been created
                if (
                    string.Compare(curPrefab.name, imageName, StringComparison.OrdinalIgnoreCase)
                        == 0
                    && !_instantiatedPrefabs.ContainsKey(imageName)
                )
                {
                    // Instantiate the prefab, parenting it to the ARTrackedImage
                    var newPrefab = Instantiate(curPrefab, trackedImage.transform);
                    // Add created prefab to array
                    _instantiatedPrefabs[imageName] = newPrefab;
                }
            }
        }

        // For all prefabs that have been created so far, set them active or not depending on
        // whether their corresponding image is currently being tracked
        foreach (var trackedImage in eventArgs.updated)
        {
            _instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(
                trackedImage.trackingState == TrackingState.Tracking
            );
        }

        // If the AR subsystem has given up looking for a tracked image
        //Test Git
        foreach (var trackedImage in eventArgs.removed)
        {
            // Destroy the prefab, removes object from scene
            Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
            // Also remove the instance from array that keeps track
            _instantiatedPrefabs.Remove(trackedImage.referenceImage.name);
        }
    }
}

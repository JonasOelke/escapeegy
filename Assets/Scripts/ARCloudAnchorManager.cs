using System;
using System.Collections;
using System.Collections.Generic;
using Google.XR.ARCoreExtensions;
using Google.XR.ARCoreExtensions.Samples.PersistentCloudAnchors;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class UnityEventResolver : UnityEvent<Transform> { }

public class ARCloudAnchorManager : MonoBehaviour
{
    /// <summary>
    /// The 3D object that represents a Cloud Anchor.
    /// </summary>
    public GameObject CloudAnchorPrefab;

    /// <summary>
    /// The game object that includes <see cref="MapQualityIndicator"/> to visualize
    /// map quality result.
    /// </summary>
    public GameObject MapQualityIndicatorPrefab;

    /// <summary>
    /// The time between enters AR View and ARCore session starts to host or resolve.
    /// </summary>
    private const float _startPrepareTime = 3.0f;

    /// <summary>
    /// The timer to indicate whether the AR View has passed the start prepare time.
    /// </summary>
    private float _timeSinceStart;

    /// <summary>
    /// The MapQualityIndicator that attaches to the placed object.
    /// </summary>
    private MapQualityIndicator _qualityIndicator = null;

    /// <summary>
    /// The history data that represents the current hosted Cloud Anchor.
    /// </summary>
    private CloudAnchorHistory _hostedCloudAnchor;

    /// <summary>
    /// An ARAnchor indicating the 3D object has been placed on a flat surface and
    /// is waiting for hosting.
    /// </summary>
    private ARAnchor _anchor = null;

    /// <summary>
    /// A list of Cloud Anchors that have been created but are not yet ready to use.
    /// </summary>
    private List<ARCloudAnchor> _pendingCloudAnchors = new List<ARCloudAnchor>();

    /// <summary>
    /// A list for caching all Cloud Anchors.
    /// </summary>
    private List<ARCloudAnchor> _cachedCloudAnchors = new List<ARCloudAnchor>();

    /// <summary>
    /// Get the camera pose for the current frame.
    /// </summary>
    /// <returns>The camera pose of the current frame.</returns>
    public Pose GetCameraPose()
    {
        // return new Pose(Controller.MainCamera.transform.position,
        //   Controller.MainCamera.transform.rotation);
        throw new NotImplementedException();
    }
/*
    /// <summary>
    /// The debug text in bottom snack bar.
    /// </summary>
    public Text DebugText;

    private void UpdatePlaneVisibility(bool visible)
    {
        foreach (var plane in Controller.PlaneManager.trackables)
        {
            plane.gameObject.SetActive(visible);
        }
    }

    /// <summary>
    /// The Unity OnEnable() method.
    /// </summary>
    ///
    public void OnEnable()
    {
        _timeSinceStart = 0.0f;
        // _isReturning = false;
        _anchor = null;
        _qualityIndicator = null;
        _pendingCloudAnchors.Clear();
        _cachedCloudAnchors.Clear();

        UpdatePlaneVisibility(true);
    }
    
    private void ARCoreLifecycleUpdate()
    {
        // Only allow the screen to sleep when not tracking.
        var sleepTimeout = SleepTimeout.NeverSleep;
        if (ARSession.state != ARSessionState.SessionTracking)
        {
            sleepTimeout = SleepTimeout.SystemSetting;
        }

        Screen.sleepTimeout = sleepTimeout;
        
    }
    */


    public static ARCloudAnchor ResolveCloudAnchorId(
        ARAnchorManager anchorManager, string cloudAnchorId)
    {
        if (ARCoreExtensions._instance.currentARCoreSessionHandle == IntPtr.Zero ||
            string.IsNullOrEmpty(cloudAnchorId))
        {
            return null;
        }

        // Create the underlying ARCore Cloud Anchor.
        IntPtr cloudAnchorHandle = SessionApi.ResolveCloudAnchor(
            ARCoreExtensions._instance.currentARCoreSessionHandle,
            cloudAnchorId);
        if (cloudAnchorHandle == IntPtr.Zero)
        {
            return null;
        }

        // Create the GameObject that is the Cloud Anchor.
        ARCloudAnchor cloudAnchor =
            (new GameObject(_cloudAnchorName)).AddComponent<ARCloudAnchor>();
        if (cloudAnchor)
        {
            cloudAnchor.SetAnchorHandle(cloudAnchorHandle);
        }

        // Parent the new Cloud Anchor to the session origin.
        cloudAnchor.transform.SetParent(
            ARCoreExtensions._instance.SessionOrigin.trackablesParent, false);

        return cloudAnchor;
    }
    
    private void ResolvingCloudAnchors()
    {

        // There are pending or finished resolving tasks.
        if (_pendingCloudAnchors.Count > 0 || _cachedCloudAnchors.Count > 0)
        {
            return;
        }

        // ARCore session is not ready for resolving.
        if (ARSession.state != ARSessionState.SessionTracking)
        {
            return;
        }
        
        string cloudAnchorId = "CLOUD ANCHOR ID HERE";
     
            ARCloudAnchor cloudAnchor =
                Controller.AnchorManager.ResolveCloudAnchorId(cloudAnchorId);
           
                _pendingCloudAnchors.Add(cloudAnchor);
           
    }
}

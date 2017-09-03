using UnityEngine;

public class HapticFeedbackExample : MonoBehaviour {
    void Update()
    {
        SteamVR_TrackedObject trackedObject = GetComponent<SteamVR_TrackedObject>();
        var device = SteamVR_Controller.Input((int)trackedObject.index);

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad)) {
            // タッチパッドに触れた
            device.TriggerHapticPulse(500);
        }

        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger)) {
            // トリガーを深く引いている
            device.TriggerHapticPulse(2000);
        }
        else if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
            // トリガーを浅く引いている
            device.TriggerHapticPulse(100);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINotificationManager : MonoBehaviour
{
    public GameObject notification;
    public Transform canvas;
    public int maxNotifications;

    List<GameObject> queuedNotifications = new List<GameObject>();
    List<GameObject> activeNotifications = new List<GameObject>();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject go in activeNotifications){
            if (go == null)
            {
                activeNotifications.Remove(go);

            }
        }
        if (activeNotifications.Count < maxNotifications && queuedNotifications.Count > 0){
            activeNotifications.Add(queuedNotifications[0]);
            PushNotificaton(queuedNotifications[0]);
            queuedNotifications.RemoveAt(0);
        }
    }
    public void CreateNotification(string text, Sprite image, float dTime)
    {
        GameObject newNotification = Instantiate(notification, canvas);
        newNotification.GetComponent<NotificationSelfDestruct>().destroyTime = dTime;
        newNotification.GetComponentInChildren<UnityEngine.UI.Text>().text = text;
        newNotification.GetComponentInChildren<UnityEngine.UI.Image>().sprite = image;
        queuedNotifications.Add(newNotification);
        newNotification.SetActive(false);
    }
    void PushNotificaton(GameObject notification){
        notification.GetComponent<RectTransform>().localPosition = new Vector3(notification.GetComponent<RectTransform>().localPosition.x,notification.GetComponent<RectTransform>().localPosition.y - 67.5f*(activeNotifications.Count-1),0);
        notification.SetActive(true);
        notification.GetComponent<NotificationSelfDestruct>().OnCreation();
    }
}

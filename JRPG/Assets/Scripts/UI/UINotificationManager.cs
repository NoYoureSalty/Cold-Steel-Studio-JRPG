using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINotificationManager : MonoBehaviour
{
    public GameObject spriteNotification;
    public GameObject textNotification;
    public Transform canvas;
    public int maxNotifications;

    public float heightOffset;

    List<GameObject> queuedNotifications = new List<GameObject>();
    List<GameObject> activeNotifications = new List<GameObject>();

    public enum NotificationType
    {
        Text = 0, Sprite = 1
    };

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
    public void CreateNotification(string text, Sprite image, float dTime, NotificationType type)
    {
        GameObject newNotification = null;
        if(type == NotificationType.Sprite)
            newNotification = Instantiate(spriteNotification, canvas);
        if(type == NotificationType.Text)
            newNotification = Instantiate(textNotification, canvas);

        if (type == NotificationType.Sprite)
        {
            newNotification.GetComponentInChildren<Text>().text = text;
            newNotification.GetComponentInChildren<Image>().sprite = image;
        }

        if(type == NotificationType.Text){
            
            newNotification.GetComponent<Text>().text = text;
        }
        newNotification.GetComponent<NotificationSelfDestruct>().destroyTime = dTime;
        queuedNotifications.Add(newNotification);
        newNotification.SetActive(false);
    }
    void PushNotificaton(GameObject notification){
        float currentNotificationBuffer = 0;
        foreach(GameObject tempnotification in activeNotifications){
            currentNotificationBuffer += tempnotification.GetComponent<RectTransform>().rect.height;
        }
        currentNotificationBuffer -= notification.GetComponent<RectTransform>().rect.height;
        notification.GetComponent<RectTransform>().localPosition = new Vector3(notification.GetComponent<RectTransform>().localPosition.x, notification.GetComponent<RectTransform>().localPosition.y - currentNotificationBuffer - heightOffset * activeNotifications.Count, 0);      
        notification.SetActive(true);
        notification.GetComponent<NotificationSelfDestruct>().OnCreation();
    }
}

using System;
using System.Threading.Tasks;
namespace Lab6
{
    /// <summary>
    /// Клас календаря, 
    /// який відповідає за управління подіями, їх створення, видалення, зміну часу та синхронізацію.
    /// </summary>
    public class Calendar
    {
        private string eventName; //назва події
        private DateTime eventDateTime; //дата та час події
        private string eventPlace; //місце проведення події 
        private int eventPriority; //пріоритет події (від 0 до 10)
        private bool synchronisationStatus; //статус синхронізації (True/False)
        private string[] events; // масив подій
        private int eventCount; //кількість подій

        // Асоціація
        private Service service;
        private Ai ai;
        private VisualizationModule visualization;
        private Message message;
        private SecurityControl securityControl;
        private PowerSupply powerSupply;
        private CommunicationModel communicationModel;

        /// <summary>
        /// Властивість
        /// </summary>
        public string EventName
        {
            get
            {
                return eventName;
            }
            set
            {
                this.eventName = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public DateTime EventDateTime
        {
            get
            {
                return eventDateTime;
            }
            set
            {
                eventDateTime = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string EventPlace
        {
            get
            {
                return eventPlace;
            }
            set
            {
                this.eventPlace = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public int EventPriority
        {
            get
            {
                return eventPriority;
            }
            set
            {
                this.eventPriority = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public bool SynchronisationStatus
        {
            get
            {
                return synchronisationStatus;
            }
            set
            {
                this.synchronisationStatus = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string[] Events
        {
            get
            {
                return events;
            }
            set
            {
                this.events = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public int EventCount
        {
            get
            {
                return eventCount;
            }
            set
            {
                this.eventCount = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public Service Service
        {
            get
            {
                return service;
            }
            set
            {
                this.service = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public VisualizationModule Visualization
        {
            get
            {
                return visualization;
            }
            set
            {
                this.visualization = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public Ai Ai
        {
            get
            {
                return ai;
            }
            set
            {
                this.ai = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public Message Message
        {
            get
            {
                return message;
            }
            set
            {
                this.message = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public CommunicationModel CommunicationModel
        {
            get
            {
                return communicationModel;
            }
            set
            {
                this.communicationModel = value;
            }
        }
        /// <summary>
        /// Конструктор 
        /// </summary>
        public Calendar()
        {
            eventName = "";
            eventDateTime = DateTime.Now;
            eventPlace = "";
            eventPriority = 0;
            synchronisationStatus = false;
            events = new string[100];
            eventCount = 0;
        }
        /// <summary>
        /// Метод для створення події в календарі
        /// </summary>
        /// <param name="name"> назва події </param>
        /// <param name="dateTime"> час </param>
        /// <param name="place"> місце події </param>
        /// <param name="priority"> пріоритетніст</param>
        /// <returns> створена подія </returns>
        public string CreateEvent(string name, DateTime dateTime, string place, int priority)
        {
            eventName = name;
            eventDateTime = dateTime;
            eventPlace = place;
            eventPriority = priority;
            if (!CheckValidity())
            {
                service.OutputData("Cannot create event: Invalid data.");
                return null;
            }
            if (eventCount < events.Length)
            {
                string eventEntry = name + "|" + dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "|" + place + "|" + priority;
                events[eventCount] = eventEntry;
                eventCount++;
                string eventDetails = "Event: " + name + ", Time: " + dateTime.ToString("yyyy-MM-dd HH:mm:ss") + ", Place: " + place + ", Priority: " + priority;
                service.OutputData("Event created: " + eventDetails);
                service.WriteData("calendar_log.txt", "Created: " + eventDetails);
                visualization.DisplayData("New event: " + name);
                string aiRecommendation = ai.GetRecommendation("Event created: " + name);
                return aiRecommendation;
            }
            else
            {
                service.OutputData("Event storage full. Cannot create event.");
                return null;
            }
        }
        /// <summary>
        /// Метод для видалення події з календаря
        /// </summary>
        /// <param name="name"> назва події </param>
        public void DeleteEvent(string name)
        {
            bool found = false;
            for (int i = 0; i < eventCount; i++)
            {
                if (events[i] != null && events[i].StartsWith(name + "|")) //якщо подія знайдена
                {
                    found = true;
                    for (int j = i; j < eventCount - 1; j++)
                    {
                        events[j] = events[j + 1];
                    }
                    events[eventCount - 1] = null;
                    eventCount--;
                    service.OutputData("Event deleted: " + name);
                    service.WriteData("calendar_log.txt", "Deleted: " + name);
                    visualization.DisplayData("Deleted event: " + name);
                    break;
                }
            }
            if (!found)
            {
                service.OutputData("Event not found: " + name);
            }
        }
        /// <summary>
        /// Метод для зміни часу події в календарі
        /// </summary>
        /// <param name="name"> назва події </param>
        /// <param name="newDateTime"> новий час </param>
        public void ChangeTimeOfEvent(string name, DateTime newDateTime)
        {
            bool found = false;
            for (int i = 0; i < eventCount; i++)
            {
                if (events[i] != null && events[i].StartsWith(name + "|"))
                {
                    string[] parts = events[i].Split('|');
                    string place = parts[2];
                    int priority = int.Parse(parts[3]);
                    events[i] = name + "|" + newDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "|" + place + "|" + priority;
                    found = true;
                    string details = "Event: " + name + ", New time: " + newDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    service.OutputData("Event time changed: " + details);
                    service.WriteData("calendar_log.txt", "Changed: " + details);
                    visualization.DisplayData("Updated event: " + name);
                    break;
                }
            }
            if (!found)
            {
                service.OutputData("Event not found: " + name);
            }
        }
        /// <summary>
        /// Метод для синхронізації календаря з іншими системами
        /// </summary>
        public void Synchronise()
        {
            service.OutputData("Synchronising events...");
            string messageContent = "Calendar synchronised at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // створення повідомлення про синхронізацію
            message.CreateMessage(messageContent, "Notification", "Calendar", 1);
            synchronisationStatus = true;
            service.OutputData("Synchronisation complete. Status: True");
            service.WriteData("calendar_log.txt", "Synchronised: " + messageContent);
            visualization.DisplayData("Calendar synchronised");
        }
        /// <summary>
        /// Метод для нагадування про події, які відбудуться протягом наступних 30 хвилин
        /// </summary>
        public void EventReminding()
        {
            DateTime now = DateTime.Now;
            for (int i = 0; i < eventCount; i++)
            {
                if (events[i] != null)
                {
                    string[] parts = events[i].Split('|');
                    DateTime eventTime;
                    if (DateTime.TryParse(parts[1], out eventTime))
                    {
                        TimeSpan timeUntilEvent = eventTime - now;
                        if (timeUntilEvent.TotalMinutes > 0 && timeUntilEvent.TotalMinutes <= 30)
                        {
                            Notify(parts[0], eventTime, parts[2], int.Parse(parts[3]));
                        }
                    }
                }
            }
            service.OutputData("Checked for event reminders.");
            service.WriteData("calendar_log.txt", "Reminder check at " + now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        /// <summary>
        /// Метод для перевірки валідності події
        /// </summary>
        /// <returns> відповідь валідності </returns>
        public bool CheckValidity()
        {
            bool isValid = !string.IsNullOrEmpty(eventName);
            if (!isValid)
            {
                service.OutputData("Event name is empty.");
            }
            service.OutputData("Event validity: " + (isValid ? "Valid" : "Invalid")); //якщо назва події не порожня, то валідна
            return isValid;
        }
        /// <summary>
        /// Метод для нагадування про подію, яка відбудеться в майбутньому
        /// </summary>
        /// <param name="name"> назва події </param>
        /// <param name="dateTime"> час </param>
        /// <param name="place"> місце події </param>
        /// <param name="priority"> пріоритетніст</param>
        public void Notify(string name, DateTime dateTime, string place, int priority)
        {
            string details = "Reminder: " + name + " at " + dateTime.ToString("yyyy-MM-dd HH:mm:ss") + ", Place: " + place + ", Priority: " + priority;
            string encryptedDetails = securityControl.EncryptData(details, 128);
            message.CreateMessage(encryptedDetails, "Notification", "Calendar", priority);
            message.SendMessage(encryptedDetails);
            service.OutputData(details);
            service.WriteData("calendar_log.txt", "Notified: " + details);
            visualization.DisplayData(details);
        }
    }
}
using System;
namespace Lab6
{
    /// <summary>
    /// Клас для повідомлення, 
    /// який містить інформацію про тип повідомлення, відправника, час, емоційний тон, пріоритет та стан.
    /// </summary>
    public class Message
    {
        private string messageType; // тип повідомлення (текст, сповіщення, попередження)
        private string sender; // відправник повідомлення
        private string messageTime; // час отримання повідомлення
        private string emotionalTone; // емоційний тон повідомлення (радісний, сумний, нейтральний)
        private int messagePriority; // пріоритет повідомлення (від 1 до 5, де 1 - найвищий)
        private string state; // стан повідомлення (чернетка, надіслано, отримано, помилка)
        private string[] messageHistory; // історія повідомлень (масив рядків)
        private int historyCount; // кількість повідомлень в історії

        // Асоціації
        private Service service;
        private CommunicationModel communication;
        private MoodAnalysis moodAnalysis;
        private VisualizationModule visualization;
        private PowerSupply powerSupply;

        /// <summary>
        /// Властивість
        /// </summary>
        public string MessageType
        {
            get
            {
                return messageType;
            }
            set
            {
                this.messageType = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string Sender
        {
            get
            {
                return sender;
            }
            set
            {
                this.sender = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string MessageTime
        {
            get
            {
                return messageTime;
            }
            set
            {
                this.messageTime = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string EmotionalTone
        {
            get
            {
                return emotionalTone;
            }
            set
            {
                this.emotionalTone = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public int MessagePriority
        {
            get
            {
                return messagePriority;
            }
            set
            {
                this.messagePriority = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                this.state = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string[] MessageHistory
        {
            get
            {
                return messageHistory;
            }
            set
            {
                this.messageHistory = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public int HistoryCount
        {
            get
            {
                return historyCount;
            }
            set
            {
                this.historyCount = value;
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
        public CommunicationModel Communication
        {
            get
            {
                return communication;
            }
            set
            {
                this.communication = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public MoodAnalysis MoodAnalysis
        {
            get
            {
                return moodAnalysis;
            }
            set
            {
                this.moodAnalysis = value;
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
        public PowerSupply PowerSupply
        {
            get
            {
                return powerSupply;
            }
            set
            {
                this.powerSupply = value;
            }
        }
        /// <summary>
        /// Конструктор 
        /// </summary>
        public Message()
        {
            messageType = "";
            sender = "";
            messageTime = "";
            emotionalTone = "";
            messagePriority = -1;
            state = "";
            messageHistory = new string[100];
            historyCount = 0;
        }
        /// <summary>
        /// Метод для отримання повідомлення з комунікаційної моделі.
        /// </summary>
        /// <returns> надана інформація </returns>
        public string GetMessage()
        {
            string data = communication.GetData();
            if (data.StartsWith("Error"))
            {
                service.OutputData("Failed to get message: " + data);
                return data;
            }
            if (historyCount < messageHistory.Length)
            {
                string messageEntry = data + " | Received at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                messageHistory[historyCount] = messageEntry;
                historyCount++;
            }
            else
            {
                service.OutputData("Message history full. Cannot store new message.");
            }
            service.OutputData("Message received: " + data);
            service.WriteData("message_log.txt", "Rece ived: " + data);
            visualization.DisplayData("Message: " + data);
            return data;
        }
        /// <summary>
        /// Метод для створення нового повідомлення з вказаним вмістом, типом, відправником та пріоритетом.
        /// </summary>
        /// <param name="content"> інформація </param>
        /// <param name="type"> тип повідомлення </param>
        /// <param name="sender"> надсилач </param>
        /// <param name="priority"> пріоритетність </param>
        /// <returns> створене повідомлення </returns>
        public string CreateMessage(string content, string type, string sender, int priority)
        {
            string[] validTypes = new string[] { "Text", "Alert", "Notification" };
            bool isValidType = false;
            for (int i = 0; i < validTypes.Length; i++)
            {
                if (validTypes[i] == type)
                {
                    isValidType = true;
                    break;
                }
            }
            if (!isValidType)
            {
                service.OutputData("Invalid message type: " + type);
                return "Error: Invalid message type";
            }
            messageType = type;
            this.sender = sender;
            messageTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            messagePriority = priority;
            state = "Draft";
            string messageEntry = content + " | Type: " + type + " | Sender: " + sender + " | Priority: " + priority;
            string[] filtered = FilterMessages(priority);
            service.OutputData("Message created: " + messageEntry);
            service.WriteData("message_log.txt", "Created: " + messageEntry);
            visualization.DisplayData("New message: " + content);
            return content;
        }
        /// <summary>
        /// Метод для надсилання повідомлення з вказаним вмістом, типом, відправником та пріоритетом.
        /// </summary>
        /// <param name="content"> повідомлення </param>
        public void SendMessage(string content)
        {
            string status = communication.ConnectionChecking();
            if (status != "Connected")
            {
                service.OutputData("Cannot send message: No connection.");
                return;
            }
            communication.SendData(content);
            state = "Sent";
            messageTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            service.OutputData("Message sent: " + content);
            service.WriteData("message_log.txt", "Sent: " + content + " | Time: " + messageTime);
            visualization.DisplayData("Sent: " + content);
        }
        /// <summary>
        /// Метод для фільтрації повідомлень за пріоритетом.
        /// </summary>
        /// <param name="priorityThreshold"> пріоритетність </param>
        /// <returns> фідфільтровані повідомлення </returns>
        public string[] FilterMessages(int priorityThreshold)
        {
            int filteredCount = 0;
            for (int i = 0; i < historyCount; i++)
            {
                string message = messageHistory[i];
                int priority = 1;
                if (message != null && message.Contains("Priority:"))
                {
                    string[] parts = message.Split('|');
                    for (int j = 0; j < parts.Length; j++)
                    {
                        if (parts[j].Contains("Priority:"))
                        {
                            string value = parts[j].Replace("Priority:", "").Trim();
                            int.TryParse(value, out priority);
                            break;
                        }
                    }
                }
                if (priority >= priorityThreshold)
                {
                    filteredCount++;
                }
            }
            string[] filteredMessages = new string[filteredCount];
            int index = 0;
            for (int i = 0; i < historyCount; i++)
            {
                string message = messageHistory[i];
                int priority = 1;
                if (message != null && message.Contains("Priority:"))
                {
                    string[] parts = message.Split('|');
                    for (int j = 0; j < parts.Length; j++)
                    {
                        if (parts[j].Contains("Priority:"))
                        {
                            string value = parts[j].Replace("Priority:", "").Trim();
                            int.TryParse(value, out priority);
                            break;
                        }
                    }
                }
                if (priority >= priorityThreshold)
                {
                    filteredMessages[index] = message;
                    index++;
                }
            }
            service.OutputData("Filtered " + filteredCount + " messages with priority >= " + priorityThreshold);
            service.WriteData("message_log.txt", "Filtered messages: " + filteredCount);
            return filteredMessages;
        }
        /// <summary>
        /// Метод для архівації повідомлення з вказаним вмістом
        /// </summary>
        /// <param name="message"> повідомлення </param>
        /// <returns> архів </returns>
        public string[] ArchiveMessage(string message)
        {
            if (historyCount < messageHistory.Length)
            {
                string archiveEntry = message + " | Archived at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | State: " + state;
                messageHistory[historyCount] = archiveEntry;
                historyCount++;
            }
            else
            {
                service.OutputData("Message history full. Cannot archive message.");
            }
            service.OutputData("Message archived: " + message);
            service.WriteData("message_log.txt", "Archived: " + message);
            return messageHistory;
        }
    }
}
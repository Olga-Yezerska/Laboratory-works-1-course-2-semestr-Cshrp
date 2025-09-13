using System;

namespace Lab6
{
    /// <summary>
    /// Інтерфейс для розумних годинників
    /// </summary>
    public interface ISmartWatch
    {
        /// <summary>
        /// Властивість
        /// </summary>
        int Id 
        { 
            get; 
            set; 
        }
        /// <summary>
        /// Властивість
        /// </summary>
        string SerialNumber 
        { 
            get; 
            set; 
        }
        /// <summary>
        /// Властивість
        /// </summary>
        string Model 
        { 
            get; 
            set; 
        }
        /// <summary>
        /// Властивість
        /// </summary>
        bool PowerStatus 
        { 
            get; 
            set; 
        }
        /// <summary>
        /// Властивість
        /// </summary>
        string FirmwareVersion 
        { 
            get; 
            set; 
        }
        /// <summary>
        /// Властивість
        /// </summary>
        DateTime LastDiagnosisTime 
        { 
            get; 
            set; 
        }
        /// <summary>
        /// Метод для увімкнення/вимкнення годинника
        /// </summary>
        void SwitchOn();
        /// <summary>
        /// Метод для вимкнення годинника
        /// </summary>
        void SwitchOff();
        /// <summary>
        /// Метод для отримання інформації про стан годинника
        /// </summary>
        void Diagnostics();
        /// <summary>
        /// Метод для оновлення прошивки годинника
        /// </summary>
        void FirmwareUpdate();
        /// <summary>
        /// Метод для генерації нової версії прошивки на основі поточної версії
        /// </summary>
        /// <param name="currentVersion"> поточна версія </param>
        /// <returns> нова версія </returns>
        string GenerateNewVersion(string currentVersion);
        /// <summary>
        /// Метод для планування періодичності використання годинника
        /// </summary>
        void PeriodicityPlanning();
    }
}
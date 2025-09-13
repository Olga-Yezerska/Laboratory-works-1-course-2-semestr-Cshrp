using System;

namespace PoliceDepartament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle();
            TrafficService trafficService = new TrafficService();
            TechnicalDevice technicalDevice = new TechnicalDevice();
            PoliceCenter policeCenter = new PoliceCenter();
            CrimeService crimeService = new CrimeService();
            AdministrativeOffense administrativeOffense = new AdministrativeOffense();
            Service service = new Service();
            Client client = new Client();
            TouristSafety safetySystem = new TouristSafety();
            PoliceOfficer officer = new PoliceOfficer();
            LostAndFoundService lostAndFound = new LostAndFoundService();
            Complaint complaint = new Complaint();
            Request request = new Request();

            service.OutputData("Olha Yezerska, Kirochka, Nazar Mishchenko, 1 year, SE-12");
            service.OutputData("Smart Police Deapartament, 51 var.");
            service.OutputData("Version 1");
            service.OutputData("Start imitation");
            Console.WriteLine();


            //============ Сценарій ============

            // Пункт 1. Реєстрація заяви
            policeCenter.DisplayAvailableServices();
            client.Apply();
            policeCenter.RegisterClient();
            policeCenter.SubmitRequest();

            // Пункт 2.А. Сплата штрафу за трафік
            client.Apply();
            trafficService.WriteOffTrafficFine();
            trafficService.WriteOffParkingTicket();
            administrativeOffense.SaveFineData();
            request.Id = 1;
            request.SaveData();

            // Пункт 2.В Отримати довідку щодо транспорту
            client.Apply();
            vehicle.SaveTSData();
            trafficService.ProvideInformation();

            // Пункт 2.С Зареєструвати транспорт
            client.Apply();
            trafficService.Register();
            trafficService.ProvideStatus();
            vehicle.SaveTSData();

            // Пункт 3.А. Отримати туристичну довідку
            client.Apply();
            safetySystem.ProcessRequest();
            safetySystem.ProvideInformation();

            // Пункт 3.В. Отримати консультацію
            client.Apply();
            safetySystem.ProcessRequest();
            safetySystem.ProvideAdvice();

            // Пункт 3.С. Подати скаргу щодо зникнення/пошкодження майна
            client.Apply();
            safetySystem.RegisterComplaint();
            complaint.Type = "Robbery";
            complaint.Description = "Wallet stolen at the market";
            complaint.Status = "Pending review";
            complaint.SaveData();
            safetySystem.RegisterComplaint();

            // Пункт 3.D. Отримати інформацію щодо знайдених речей
            client.Apply();
            safetySystem.ProcessRequest();
            request.Type = "Lost item";
            request.Description = "Blue backpack with documents";
            request.Status = "New";
            request.SaveData();
            lostAndFound.ProcessRequest();

            // Пункт 3.E. Охорона туристів
            client.Apply();
            safetySystem.ProcessRequest();
            safetySystem.AnalyzeZone();
            officer.AssignToEvent();
            safetySystem.AppointSecurity();

            //Реєстрація дивайсу
            technicalDevice.RegisterDevice();

            // Пункт 4.А. Моніторинг статусу скарги
            crimeService.CheckComplaintStatus();

            // Пункт 4.В. Подати повідомлення про злочин
            crimeService.RegisterCrime();

            // Пункт 4.С. Подати кримінальну скаргу
            crimeService.RegisterComplaint();

            // Пункт 4.D Подати запит на відвідування затриманого
            crimeService.RegisterVisiting();

            service.OutputData("End imitation");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

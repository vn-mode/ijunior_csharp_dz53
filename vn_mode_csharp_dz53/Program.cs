using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static void Main(string[] args)
    {
        Hospital hospital = new Hospital();
        hospital.RunHospitalManagementSystem();
    }
}

class Hospital
{
    private const string SortByFullNameOption = "1";
    private const string SortByAgeOption = "2";
    private const string FilterByDiseaseOption = "3";
    private const string ExitOption = "0";

    private readonly List<Patient> _patients;

    public Hospital()
    {
        _patients = new List<Patient>
        {
            new Patient("Иванов Иван Иванович", 35, "Грипп"),
            new Patient("Петров Петр Петрович", 45, "Ангина"),
            new Patient("Сидоров Сидор Сидорович", 30, "Грипп"),
        };
    }

    public void RunHospitalManagementSystem()
    {
        bool isExited = false;

        while (!isExited)
        {
            DisplayMenu();
            string choice = GetUserChoice();

            switch (choice)
            {
                case SortByFullNameOption:
                    DisplayPatientsInfo(_patients.OrderBy(patient => patient.FullName), "Список больных, отсортированный по ФИО:");
                    break;

                case SortByAgeOption:
                    SortPatientsByAge();
                    break;

                case FilterByDiseaseOption:
                    FilterPatientsByDisease();
                    break;

                case ExitOption:
                    isExited = true;
                    break;

                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("Меню:");
        Console.WriteLine($"{SortByFullNameOption}) Отсортировать всех больных по ФИО");
        Console.WriteLine($"{SortByAgeOption}) Отсортировать всех больных по возрасту");
        Console.WriteLine($"{FilterByDiseaseOption}) Вывести больных с определенным заболеванием");
        Console.WriteLine($"{ExitOption}) Выход");
        Console.WriteLine();
    }

    private string GetUserChoice()
    {
        Console.Write("Выберите пункт меню:");
        return Console.ReadLine();
    }

    private void DisplayPatientsInfo(IEnumerable<Patient> patients, string message)
    {
        Console.WriteLine(message);

        foreach (var patient in patients)
        {
            DisplayPatientInfo(patient);
        }
    }

    private void DisplayPatientInfo(Patient patient)
    {
        Console.WriteLine(FormatPatientInfo(patient));
    }

    private string FormatPatientInfo(Patient patient)
    {
        return $"ФИО: {patient.FullName}, Возраст: {patient.Age}, Заболевание: {patient.Disease}";
    }

    private void SortPatientsByAge()
    {
        var sortedPatients = _patients.OrderBy(patient => patient.Age);
        DisplayPatientsInfo(sortedPatients, "Список больных, отсортированный по возрасту:");
    }

    private void FilterPatientsByDisease()
    {
        Console.Write("Введите название заболевания: ");
        string disease = Console.ReadLine();

        var filteredPatients = _patients.Where(patient => patient.Disease == disease);

        if (filteredPatients.Any())
        {
            DisplayPatientsInfo(filteredPatients, $"Список больных с заболеванием '{disease}':");
        }
        else
        {
            Console.WriteLine($"Нет пациентов с диагнозом '{disease}'.");
        }
    }
}

class Patient
{
    public Patient(string fullName, int age, string disease)
    {
        FullName = fullName;
        Age = age;
        Disease = disease;
    }

    public string FullName { get; }
    public int Age { get; }
    public string Disease { get; }
}

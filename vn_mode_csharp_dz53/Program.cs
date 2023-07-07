using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    const string MenuTitle = "Меню:";
    const string MenuPrompt = "Выберите пункт меню:";
    const string SortByFullNameOption = "1";
    const string SortByAgeOption = "2";
    const string FilterByDiseaseOption = "3";
    const string ExitOption = "0";
    const string InvalidChoiceMessage = "Некорректный выбор.";
    const string SortByFullNameMessage = "Список больных, отсортированный по ФИО:";
    const string SortByAgeMessage = "Список больных, отсортированный по возрасту:";
    const string FilterByDiseaseMessage = "Список больных с заболеванием '{0}':";
    const string EnterDiseaseMessage = "Введите название заболевания: ";
    const string PatientInfoFormat = "ФИО: {0}, Возраст: {1}, Заболевание: {2}";
    const string FilteredPatientInfoFormat = "ФИО: {0}, Возраст: {1}";

    static void Main(string[] args)
    {
        List<Patient> patients = new List<Patient>
        {
            new Patient("Иванов Иван Иванович", 35, "Грипп"),
            new Patient("Петров Петр Петрович", 45, "Ангина"),
            new Patient("Сидоров Сидор Сидорович", 30, "Грипп"),
        };

        while (true)
        {
            Console.WriteLine(MenuTitle);
            Console.WriteLine($"{SortByFullNameOption}) Отсортировать всех больных по ФИО");
            Console.WriteLine($"{SortByAgeOption}) Отсортировать всех больных по возрасту");
            Console.WriteLine($"{FilterByDiseaseOption}) Вывести больных с определенным заболеванием");
            Console.WriteLine($"{ExitOption}) Выход");
            Console.WriteLine();

            Console.Write(MenuPrompt);
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case SortByFullNameOption:
                    SortPatientsByFullName(patients);
                    break;

                case SortByAgeOption:
                    SortPatientsByAge(patients);
                    break;

                case FilterByDiseaseOption:
                    FilterPatientsByDisease(patients);
                    break;

                case ExitOption:
                    return;

                default:
                    Console.WriteLine(InvalidChoiceMessage);
                    break;
            }

            Console.WriteLine();
        }
    }

    static void SortPatientsByFullName(List<Patient> patients)
    {
        var sortedPatients = patients.OrderBy(p => p.FullName);
        Console.WriteLine(SortByFullNameMessage);

        foreach (var patient in sortedPatients)
        {
            Console.WriteLine(string.Format(PatientInfoFormat, patient.FullName, patient.Age, patient.Disease));
        }
    }

    static void SortPatientsByAge(List<Patient> patients)
    {
        var sortedPatients = patients.OrderBy(p => p.Age);
        Console.WriteLine(SortByAgeMessage);

        foreach (var patient in sortedPatients)
        {
            Console.WriteLine(string.Format(PatientInfoFormat, patient.FullName, patient.Age, patient.Disease));
        }
    }

    static void FilterPatientsByDisease(List<Patient> patients)
    {
        Console.Write(EnterDiseaseMessage);
        string disease = Console.ReadLine();

        var filteredPatients = patients.Where(p => p.Disease == disease);
        Console.WriteLine(string.Format(FilterByDiseaseMessage, disease));

        foreach (var patient in filteredPatients)
        {
            Console.WriteLine(string.Format(FilteredPatientInfoFormat, patient.FullName, patient.Age));
        }
    }
}

class Patient
{
    public string FullName { get; }
    public int Age { get; }
    public string Disease { get; }

    public Patient(string fullName, int age, string disease)
    {
        FullName = fullName;
        Age = age;
        Disease = disease;
    }
}

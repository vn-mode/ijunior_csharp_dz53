﻿using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private const string MenuTitle = "Меню:";
    private const string MenuPrompt = "Выберите пункт меню:";
    private const string SortByFullNameOption = "1";
    private const string SortByAgeOption = "2";
    private const string FilterByDiseaseOption = "3";
    private const string ExitOption = "0";
    private const string InvalidChoiceMessage = "Некорректный выбор.";
    private const string SortByFullNameMessage = "Список больных, отсортированный по ФИО:";
    private const string SortByAgeMessage = "Список больных, отсортированный по возрасту:";
    private const string FilterByDiseaseMessage = "Список больных с заболеванием '{0}':";
    private const string EnterDiseaseMessage = "Введите название заболевания: ";
    private const string PatientInfoFormat = "ФИО: {0}, Возраст: {1}, Заболевание: {2}";

    private static void Main(string[] args)
    {
        List<Patient> patients = new List<Patient>
        {
            new Patient("Иванов Иван Иванович", 35, "Грипп"),
            new Patient("Петров Петр Петрович", 45, "Ангина"),
            new Patient("Сидоров Сидор Сидорович", 30, "Грипп"),
        };

        bool isExited = false;

        while (!isExited)
        {
            DisplayMenu();
            string choice = GetUserChoice();

            switch (choice)
            {
                case SortByFullNameOption:
                    DisplayPatientsInfo(patients.OrderBy(patient => patient.FullName), SortByFullNameMessage);
                    break;

                case SortByAgeOption:
                    DisplayPatientsInfo(patients.OrderBy(patient => patient.Age), SortByAgeMessage);
                    break;

                case FilterByDiseaseOption:
                    FilterPatientsByDisease(patients);
                    break;

                case ExitOption:
                    isExited = true;
                    break;

                default:
                    Console.WriteLine(InvalidChoiceMessage);
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine(MenuTitle);
        Console.WriteLine($"{SortByFullNameOption}) Отсортировать всех больных по ФИО");
        Console.WriteLine($"{SortByAgeOption}) Отсортировать всех больных по возрасту");
        Console.WriteLine($"{FilterByDiseaseOption}) Вывести больных с определенным заболеванием");
        Console.WriteLine($"{ExitOption}) Выход");
        Console.WriteLine();
    }

    private static string GetUserChoice()
    {
        Console.Write(MenuPrompt);
        return Console.ReadLine();
    }

    private static void DisplayPatientsInfo(IEnumerable<Patient> patients, string message)
    {
        Console.WriteLine(message);

        foreach (var patient in patients)
        {
            Console.WriteLine(string.Format(PatientInfoFormat, patient.FullName, patient.Age, patient.Disease));
        }
    }

    private static void FilterPatientsByDisease(List<Patient> patients)
    {
        Console.Write(EnterDiseaseMessage);
        string disease = Console.ReadLine();

        var filteredPatients = patients.Where(patient => patient.Disease == disease);
        Console.WriteLine(string.Format(FilterByDiseaseMessage, disease));

        foreach (var patient in filteredPatients)
        {
            Console.WriteLine(string.Format(PatientInfoFormat, patient.FullName, patient.Age, patient.Disease));
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

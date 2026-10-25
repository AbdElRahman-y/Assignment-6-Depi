using EmployeeApp;

namespace EmployeeApp;

internal class Program
{
    static int ReadInt(string prompt, int min, int max)
    {
        int value;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            Console.Write($"Please enter a number between {min} and {max}: ");
        return value;
    }

    static decimal ReadSalary(string prompt)
    {
        decimal value;
        Console.Write(prompt);
        while (!decimal.TryParse(Console.ReadLine(), out value) || value < 0)
            Console.Write("Please enter a valid salary (0 or more): ");
        return value;
    }

    static string ReadName(string prompt)
    {
        Console.Write(prompt);
        string? text = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(text))
        {
            Console.Write("Name cannot be empty, try again: ");
            text = Console.ReadLine();
        }
        return text.Trim();
    }

    static Gender ReadGender()
    {
        Console.Write("Gender (M/F): ");
        while (true)
        {
            string input = (Console.ReadLine() ?? "").Trim().ToUpper();
            if (input == "M") return Gender.M;
            if (input == "F") return Gender.F;
            Console.Write("Only M or F is allowed: ");
        }
    }

    static HireDate ReadHireDate()
    {
        while (true)
        {
            int year = ReadInt("Hire year: ", 1900, DateTime.Now.Year);
            int month = ReadInt("Hire month: ", 1, 12);
            int day = ReadInt("Hire day: ", 1, 31);

            if (HireDate.IsValid(day, month, year))
                return new HireDate(day, month, year);

            Console.WriteLine("This date does not exist, enter it again.");
        }
    }

    static Employee ReadEmployee(string title, SecurityLevel level)
    {
        Console.WriteLine();
        Console.WriteLine($"=== {title} ===");

        int id = ReadInt("Id: ", 1, int.MaxValue);
        string name = ReadName("Name: ");
        decimal salary = ReadSalary("Salary: ");
        HireDate hireDate = ReadHireDate();
        Gender gender = ReadGender();

        return new Employee(id, name, level, salary, hireDate, gender);
    }

    static void Main(string[] args)
    {
        Employee[] EmpArr = new Employee[3];

        EmpArr[0] = ReadEmployee("DBA employee", SecurityLevel.DBA);
        EmpArr[1] = ReadEmployee("Guest employee", SecurityLevel.Guest);
        EmpArr[2] = ReadEmployee("Security officer (full permissions)", SecurityLevel.FullAccess);

        Console.WriteLine();
        Console.WriteLine("===== Employees =====");
        foreach (Employee employee in EmpArr)
            Console.WriteLine(employee);
    }
}

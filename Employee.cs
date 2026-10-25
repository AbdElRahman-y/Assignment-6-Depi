namespace EmployeeApp;

public class Employee
{
    private int _id = 1;
    private string _name = "Unknown";
    private decimal _salary;
    private HireDate _hireDate = new HireDate();

    // ---------- Constructors ----------
    public Employee() { }

    public Employee(int id, string name, SecurityLevel securityLevel, decimal salary, HireDate hireDate, Gender gender)
    {
        Id = id;
        Name = name;
        SecurityLevel = securityLevel;
        Salary = salary;
        HireDate = hireDate;
        Gender = gender;
    }

    public int Id
    {
        get => _id;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(Id), "Id must be greater than 0.");
            _id = value;
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.", nameof(Name));
            _name = value.Trim();
        }
    }

    public SecurityLevel SecurityLevel { get; set; }

    public decimal Salary
    {
        get => _salary;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Salary), "Salary cannot be negative.");
            _salary = value;
        }
    }

    public HireDate HireDate
    {
        get => _hireDate;
        set => _hireDate = value ?? throw new ArgumentNullException(nameof(HireDate));
    }

    public Gender Gender { get; set; }

    public override string ToString()
    {
        return string.Format(
            "ID: {0}, Name: {1}, Security: {2}, Salary: {3:C}, Hire Date: {4}, Gender: {5}",
            Id, Name, SecurityLevel, Salary, HireDate, Gender);
    }
}

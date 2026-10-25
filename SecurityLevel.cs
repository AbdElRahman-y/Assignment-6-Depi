namespace EmployeeApp;

[Flags]
public enum SecurityLevel
{
    Guest = 1,
    Developer = 2,
    Secretary = 4,
    DBA = 8,
    FullAccess = Guest | Developer | Secretary | DBA
}

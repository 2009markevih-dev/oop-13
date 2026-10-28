using System;
using System.Collections.Generic;

public class Employee
{
    public string Name { get; protected set; }

    public Employee(string name)
    {
        Name = name;
    }


    public virtual decimal GetSalary()
    {
        return 0;
    }
}


public class FullTimeEmployee : Employee
{
    public decimal MonthlySalary { get; private set;}

    public FullTimeEmployee(string name, decimal monthlySalary) : base(name)
    {
        MonthlySalary = monthlySalary;
    }

    
    public override decimal GetSalary()
    {
        return MonthlySalary;
    }
}


public class PartTimeEmployee : Employee
{
    public int WorkHours { get; private set; }      
    public decimal HourlyRate { get; private set; } 

    public PartTimeEmployee(string name, int workHours, decimal hourlyRate) : base(name)
    {
        WorkHours = workHours;
        HourlyRate = hourlyRate;
    }

    public override decimal GetSalary()
    {
        return WorkHours * HourlyRate;
    }
}


public class ManagerEmployee : Employee
{
    public decimal MonthlySalary { get; private set; }
    public decimal Bonus { get; private set; }

    public ManagerEmployee(string name, decimal monthlySalary, decimal bonus) : base(name)
    {
        MonthlySalary = monthlySalary;
        Bonus = bonus;
    }

    public override decimal GetSalary()
    {
        return MonthlySalary + Bonus;
    }
}


public class HiddenEmployee : Employee
{
    public HiddenEmployee(string name) : base(name)
    {
    }

    
    public new decimal GetSalary()
    {
        return 5000;
    }
}

class Program
{
    static void Main()
    {
    
        List<Employee> employees = new List<Employee>();
        employees.Add(new FullTimeEmployee("Іван", 20000));
        employees.Add(new PartTimeEmployee("Олена", 80, 150));
        employees.Add(new ManagerEmployee("Петро", 30000, 5000));

    
        foreach (Employee e in employees)
        {
            Console.WriteLine(e.Name + ": " + e.GetSalary());
        }

        
        HiddenEmployee hidden = new HiddenEmployee("Тест");
        Employee asBase = hidden;

        Console.WriteLine("Через HiddenEmployee: " + hidden.GetSalary());
        Console.WriteLine("Через Employee: " + asBase.GetSalary());
    }
}

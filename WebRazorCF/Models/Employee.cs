namespace WebRazorCF.Models
{
    public class Employee:User
    {
        public Employee()
        => Employees = new HashSet<Employee>();
        

        public decimal? Salary { get; set; }
        public int? DayOffs { get; set; } = 0;
       
        //Clé étrangère
        public int? ManagerId { get; set; }

        //Propiéte de naviguation côté 1
        public Employee Supervisor { get; set; }

        //Propiéte de naviguation côté plusieurs
        public ICollection<Employee> Employees { get; set;}
    }
}

namespace ModelDesignFirst_L1
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    public class ModelScenariu5 : DbContext
    {
        public ModelScenariu5()
            : base("name=ModelSelfReferences")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .Map<FullTimeEmployee>(m =>
                m.Requires("EmployeeType").HasValue(1))
                .Map<HourlyEmployee>(m =>
                m.Requires("EmployeeType").HasValue(2));
        }
    }

    public abstract class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class FullTimeEmployee : Employee
    {
        public decimal? Salary { get; set; }
    }

    public class HourlyEmployee : Employee
    {
        public decimal? Wage { get; set; }
    }
}
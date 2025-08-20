using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniprojectfinal.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }



        public virtual ICollection<Employee> Employees { get; set; }

        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public override string ToString()
        {
            return $"{Id}: {Name}";

        }
    }
}
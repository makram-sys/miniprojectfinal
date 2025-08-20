
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miniprojectfinal.Models;

namespace miniprojectfinal.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Position { get; set; }

        public DateTime HireDate { get; set; }


        public int? DepartmentId { get; set; }

        // Navigation properties
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public Employee()
        {
            Projects = new HashSet<Project>();
            HireDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Id}: {Name} - {Position} - {Email}";
        }
    }
}
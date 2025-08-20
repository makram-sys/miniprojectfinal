
using miniprojectfinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace miniprojectfinal.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Navigation property
        public virtual ICollection<Employee> Employees { get; set; }

        public Project()
        {
            Employees = new HashSet<Employee>();
            StartDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Id}: {Name} - {Description}";
        }
    }
}
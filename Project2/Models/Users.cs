using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    [Table("Users")]
    public class Users
    {
        [Required]
        [Key]
        public int userID { get; set; }

        [Display(Name = "Email")]
        [Required]
        public String userEmail { get; set; }

        [Display(Name = "Password")]
        [Required]
        public String password { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public String userFName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public String userLName { get; set; }
    }
}
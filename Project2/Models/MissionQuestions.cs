using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    [Table("MissionQuestions")]
    public class MissionQuestions
    {
        [Required]
        [Key]
        public int missionQuestionID { get; set; }

        [Required]
        [Display(Name = "Mission ID")]
        public int missionID { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public int userID { get; set; }

        [Required]
        [Display(Name = "Question")]
        public String question { get; set; }

        [Display(Name = "Answer")]
        public String answer { get; set; }

        [Display(Name = "Answered By")]
        public String answeredBy { get; set; }
    }
}